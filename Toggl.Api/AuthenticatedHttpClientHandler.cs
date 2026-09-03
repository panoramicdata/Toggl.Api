using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Globalization;
using System.Net;
using System.Text;

namespace Toggl.Api;

internal sealed class AuthenticatedHttpClientHandler(TogglClientOptions options) : HttpClientHandler
{
	private readonly TogglClientOptions _options = options;
	private readonly ILogger _logger = options.Logger ?? NullLogger.Instance;

	private const string QuotaRemainingHeader = "X-Toggl-Quota-Remaining";
	private const string ResetsInHeader = "X-Toggl-Quota-Resets-In";

	/// <summary>
	/// Toggl uses 429 Too Many Requests to indicate rate limiting for bursts, and does not say
	/// for how long to back off, so a fixed delay is used.
	/// </summary>
	private static readonly TimeSpan TooManyRequestsDelay = TimeSpan.FromSeconds(5);

	/// <summary>
	/// Override of the base method that is used to handle the sending of a request
	/// </summary>
	/// <param name="request">The request that is to be sent</param>
	/// <param name="cancellationToken">A cancellation token for the operation</param>
	/// <returns>The response to the request that was sent</returns>
	protected override async Task<HttpResponseMessage> SendAsync(
	HttpRequestMessage request,
		CancellationToken cancellationToken)
	{
		if (request.Headers.Authorization is null)
		{
			request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(_options.Key + ":api_token")));
		}

		return await ProcessRequestAsync(
			request,
			cancellationToken)
			.ConfigureAwait(false);
	}

	private async Task<HttpResponseMessage> ProcessRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		var requestId = Guid.NewGuid();
		using var requestScope = _logger.BeginScope("RequestId: {RequestId}", requestId);
		while (true)
		{
			await LogRequestAsync(request, cancellationToken).ConfigureAwait(false);

			var response = await base
				.SendAsync(request, cancellationToken)
				.ConfigureAwait(false);

			await LogResponseAsync(response, cancellationToken).ConfigureAwait(false);

			var retryDelay = GetRateLimitRetryDelay(response);
			if (retryDelay is null)
			{
				// Success, or a status code that is left for the caller to handle
				return response;
			}

			await Task
				.Delay(retryDelay.Value, cancellationToken)
				.ConfigureAwait(false);
		}
	}

	/// <summary>
	/// Determines how long to wait before retrying, for the status codes that Toggl uses to
	/// indicate rate limiting.
	/// </summary>
	/// <returns>The delay to wait before retrying, or <see langword="null"/> if the response should be returned as-is.</returns>
	private TimeSpan? GetRateLimitRetryDelay(HttpResponseMessage response)
	{
		if (!_options.HandleRateLimiting)
		{
			return null;
		}

		switch (response.StatusCode)
		{
			case HttpStatusCode.TooManyRequests:
				_logger.LogWarning(
					"Toggl API rate limit reached (429).  Waiting {DelaySeconds} seconds before retrying.",
					TooManyRequestsDelay.TotalSeconds);

				return TooManyRequestsDelay;

			// Toggl uses 402 Payment Required to indicate rate limiting.
			// This is incorrect usage of the HTTP spec, but we have to deal with it.
			// Documentation: https://support.toggl.com/api-webhook-limits
			case HttpStatusCode.PaymentRequired:
				return GetPaymentRequiredRetryDelay(response);

			default:
				return null;
		}
	}

	/// <summary>
	/// Reads the quota headers that accompany a 402 response to determine how long to back off for.
	/// </summary>
	private TimeSpan GetPaymentRequiredRetryDelay(HttpResponseMessage response)
	{
		var quotaRemainingHeader = GetSingleHeaderValue(response, QuotaRemainingHeader);

		if (!int.TryParse(quotaRemainingHeader, NumberStyles.Integer, CultureInfo.InvariantCulture, out var quotaRemainingCount) || quotaRemainingCount != 0)
		{
			throw new FormatException($"Toggl 402/429 reponses do not contain a valid {QuotaRemainingHeader}.  Received '{quotaRemainingHeader}'");
		}

		var resetsInHeader = GetSingleHeaderValue(response, ResetsInHeader);
		if (!int.TryParse(resetsInHeader, NumberStyles.Integer, CultureInfo.InvariantCulture, out var resetsInSeconds))
		{
			throw new FormatException($"Toggl 402/429 reponses do not contain a valid {ResetsInHeader}.  Received '{resetsInHeader}'");
		}

		_logger.LogWarning(
			"Toggl API rate limit reached.  Quota remaining: {QuotaRemaining}.  Waiting {ResetsInSeconds} seconds before retrying.",
			quotaRemainingCount,
			resetsInSeconds);

		return TimeSpan.FromSeconds(resetsInSeconds);
	}

	private static string GetSingleHeaderValue(HttpResponseMessage response, string headerName)
	{
		if (!response
			.Headers
			.TryGetValues(headerName, out var headerValues)
			|| headerValues.Count() != 1
		)
		{
			throw new FormatException($"Toggl 402/429 reponses do not contain a single {headerName} header.");
		}

		return headerValues.First();
	}

	private async Task LogRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		if (!_logger.IsEnabled(LogLevel.Debug))
		{
			return;
		}

		// Log request, including headers and content
		_logger.LogDebug(
			"Sending request: {Method} {Uri}\n" +
			"Headers: {Headers}\n" +
			"{RequestContent}",
			request.Method,
			request.RequestUri,
			request.Headers.ToDebugString(),
			request.Content is null
				? string.Empty
				: await request.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false)
		);
	}

	private async Task LogResponseAsync(HttpResponseMessage response, CancellationToken cancellationToken)
	{
		if (!_logger.IsEnabled(LogLevel.Debug))
		{
			return;
		}

		_logger.LogDebug(
			"Response: {Status}\n" +
			"Headers: {Headers}\n" +
			"{ResponseContent}",
			response.StatusCode,
			response.Headers.ToDebugString(),
			response.Content is null
				? string.Empty
				: await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false)
		);
	}
}
