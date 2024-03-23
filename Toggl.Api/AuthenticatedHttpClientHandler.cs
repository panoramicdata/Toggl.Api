using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Toggl.Api;
internal class AuthenticatedHttpClientHandler : HttpClientHandler
{
	private readonly TogglClientOptions _options;
	private readonly ILogger _logger;

	public AuthenticatedHttpClientHandler(TogglClientOptions options)
	{
		_options = options;
		_logger = options.Logger ?? NullLogger.Instance;
	}

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
			request.Headers.Add("Authorization", "Authorization: Basic " + (string?)Convert.ToBase64String(Encoding.ASCII.GetBytes(_options.Key + ":api_token")));
		}

		while (true)
		{
			try
			{
				var httpResponse = await base
					.SendAsync(request, cancellationToken)
					.ConfigureAwait(false);

				if ((int)httpResponse.StatusCode == 429)    // Too many requests
				{
					await Task.Delay(5000, default).ConfigureAwait(false);
					continue;
				}

				// Success
				return httpResponse;
			}
			catch (WebException ex) when (ex.Message.Contains("(429)"))
			{
				await Task.Delay(5000, default).ConfigureAwait(false);
				continue;
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
}