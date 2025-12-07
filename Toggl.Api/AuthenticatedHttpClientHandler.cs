using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Toggl.Api;

internal sealed class AuthenticatedHttpClientHandler(TogglClientOptions options) : HttpClientHandler
{
	private static readonly JsonSerializerOptions _prettyPrintJsonSerializerOptions = new() { WriteIndented = true };
	private readonly TogglClientOptions _options = options;
	private readonly ILogger _logger = options.Logger ?? NullLogger.Instance;

	private const string QuotaRemainingHeader = "X-Toggl-Quota-Remaining";
	private const string ResetsInHeader = "X-Toggl-Quota-Resets-In";

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
			if (_logger.IsEnabled(LogLevel.Debug))
			{
				// Log request, including headers and content
				_logger.LogDebug(
					"Sending request: {Method} {Uri}\n" +
					"Headers: {Headers}\n" +
					"{RequestContent}",
					request.Method,
					request.RequestUri,
					string.Join(
						"; ",
						request
							.Headers
							.Select(h => $"{h.Key}={string.Join(",", h.Value)}")
					),
					request.Content is null
						? string.Empty
						: await request.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false)
				);
			}

			var response = await base
				.SendAsync(request, cancellationToken)
				.ConfigureAwait(false);

			if (_logger.IsEnabled(LogLevel.Debug))
			{
				_logger.LogDebug(
					"Response: {Status}\n" +
					"Headers: {Headers}\n" +
					"{ResponseContent}",
					response.StatusCode,
					string.Join(
						"; ",
						response
							.Headers
							.Select(h => $"{h.Key}={string.Join(",", h.Value)}")
					),
					response.Content is null
						? string.Empty
						: await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false)
				);
			}

			if ((int)response.StatusCode is 402 or 429 && _options.HandleRateLimiting) // Payment reqired or Too many requests
			{
				// Determine the delay from the response headers
				if (!response
					.Headers
					.TryGetValues(QuotaRemainingHeader, out var quotaRemainingHeaders)
					|| quotaRemainingHeaders.Count() != 1
				)
				{
					throw new FormatException($"Toggl 402/429 reponses do not contain a single {QuotaRemainingHeader} header.");
				}

				var quotaRemainingHeader = quotaRemainingHeaders.First();

				if (!int.TryParse(quotaRemainingHeader, NumberStyles.Integer, CultureInfo.InvariantCulture, out var quotaRemainingCount) || quotaRemainingCount != 0)
				{
					throw new FormatException($"Toggl 402/429 reponses do not contain a valid {QuotaRemainingHeader}.  Received '{quotaRemainingHeader}'");
				}

				if (!response
					.Headers
					.TryGetValues(ResetsInHeader, out var resetsInHeaders)
					|| resetsInHeaders.Count() != 1
				)
				{
					throw new FormatException($"Toggl 402/429 reponses do not contain a single {ResetsInHeader} header.");
				}

				var resetsInHeader = resetsInHeaders.First();
				if (!int.TryParse(resetsInHeader, NumberStyles.Integer, CultureInfo.InvariantCulture, out var resetsInSeconds))
				{
					throw new FormatException($"Toggl 402/429 reponses do not contain a valid {ResetsInHeader}.  Received '{resetsInHeader}'");
				}

				_logger.LogWarning(
					"Toggl API rate limit reached.  Quota remaining: {QuotaRemaining}.  Waiting {ResetsInSeconds} seconds before retrying.",
					quotaRemainingCount,
					resetsInSeconds);

				await Task
					.Delay(TimeSpan.FromSeconds(resetsInSeconds), cancellationToken)
					.ConfigureAwait(false);

				continue;
			}

			// Success
			return response;
		}
	}
}