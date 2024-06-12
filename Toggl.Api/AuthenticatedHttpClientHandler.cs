using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Net;
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

		using var scope = _logger.BeginScope("Request: {Method} {Uri}", request.Method, request.RequestUri);
		if (_logger.IsEnabled(LogLevel.Debug))
		{
			_logger.LogDebug(
				"Request: {Method} {Uri}\n{RequestContent}",
				request.Method,
				request.RequestUri,
				request.Content is null
					? string.Empty
					: PrettyPrintJson(await request.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false))
			);
		}

		while (true)
		{
			try
			{
				var response = await base
					.SendAsync(request, cancellationToken)
					.ConfigureAwait(false);

				if ((int)response.StatusCode == 429)    // Too many requests
				{
					await Task.Delay(5000, default).ConfigureAwait(false);
					continue;
				}

				if (_logger.IsEnabled(LogLevel.Debug))
				{
					_logger.LogDebug(
						"Response: {Status}\n{ResponseContent}",
						response.StatusCode,
						response.Content is null
							? string.Empty
							: PrettyPrintJson(await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false))
					);
				}

				// Success
				return response;
			}
			catch (WebException ex) when (ex.Message.Contains("(429)"))
			{
				await Task.Delay(5000, default).ConfigureAwait(false);
			}
		}
	}

	//public async Task<List<T>> GetAllUsingPagingAsync<T>(string baseUrl, CancellationToken cancellationToken)
	//{
	//	var allProjects = new List<T>();
	//	var pageIndex = 0;
	//	while (true)
	//	{
	//		// Paging
	//		var url = baseUrl + "?page=" + pageIndex++ + "&per_page=200";
	//		var response = await SendAsync(url, cancellationToken).ConfigureAwait(false);
	//		var projects = response.GetData<List<T>>();
	//		allProjects.AddRange(projects);
	//		if (projects.Count == 0 || projects.Count < 200)
	//		{
	//			return allProjects;
	//		}
	//	}
	//}

	public static string PrettyPrintJson(string jsonString)
	{
		if (string.IsNullOrWhiteSpace(jsonString))
		{
			return string.Empty;
		}

		using var jsonDoc = JsonDocument.Parse(jsonString);
		return JsonSerializer.Serialize(jsonDoc, _prettyPrintJsonSerializerOptions);
	}
}