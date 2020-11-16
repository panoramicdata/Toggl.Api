using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Toggl.Api.DataObjects;
using Toggl.Api.Interfaces;
using Toggl.Api.Requests;
using Toggl.Api.Responses;
using Toggl.Api.Routes;
using Task = System.Threading.Tasks.Task;

namespace Toggl.Api.Services
{
	public class ApiServiceAsync : IApiServiceAsync
	{
		private string ApiToken { get; set; }

		public Session Session { get; set; }

		public ApiServiceAsync(string apiToken)
		{
			ApiToken = apiToken;
		}

		public async Task InitializeAsync()
		{
			if (Session != null && !string.IsNullOrEmpty(Session.ApiToken))
			{
				return;
			}

			await GetSessionAsync().ConfigureAwait(false);
		}

		public async Task<Session> GetSessionAsync()
		{
			var args = new List<KeyValuePair<string, string>>();

			var response = await GetAsync(ApiRoutes.Session.Me, args).ConfigureAwait(false);
			Session = response.GetData<Session>();

			ApiToken = Session.ApiToken;

			return Session;
		}

		public async Task<ApiResponse> GetAsync(string url)
		{
			var response = await GetAsync(new ApiRequest
			{
				Url = url
			}).ConfigureAwait(false);
			return response;
		}

		public async Task<ApiResponse> GetAsync(string url, List<KeyValuePair<string, string>> args)
		{
			var response = await GetAsync(new ApiRequest
			{
				Url = url,
				Args = args
			}).ConfigureAwait(false);
			return response;
		}

		public async Task<TResponse> GetAsync<TResponse>(string url, List<KeyValuePair<string, string>> args)
		{
			var response = await GetAsync<TResponse>(new ApiRequest
			{
				Url = url,
				Args = args
			}).ConfigureAwait(false);
			return response;
		}

		public async Task<ApiResponse> DeleteAsync(string url)
		{
			var response = await GetAsync(new ApiRequest
			{
				Url = url,
				Method = "DELETE"
			}).ConfigureAwait(false);
			return response;
		}

		public async Task<ApiResponse> DeleteAsync(string url, List<KeyValuePair<string, string>> args)
		{
			var response = await GetAsync(new ApiRequest
			{
				Url = url,
				Method = "DELETE",
				Args = args
			}).ConfigureAwait(false);
			return response;
		}

		public async Task<ApiResponse> PostAsync(string url, string data)
		{
			var response = await GetAsync(
				new ApiRequest
				{
					Url = url,
					Method = "POST",
					ContentType = "application/json",
					Data = data
				}).ConfigureAwait(false);
			return response;
		}

		public async Task<ApiResponse> PostAsync(string url, List<KeyValuePair<string, string>> args, string data = "")
		{
			var response = await GetAsync(
				new ApiRequest
				{
					Url = url,
					Args = args,
					Method = "POST",
					ContentType = "application/json",
					Data = data
				}).ConfigureAwait(false);
			return response;
		}

		public async Task<ApiResponse> PutAsync(string url, string data)
		{
			var response = await GetAsync(
				new ApiRequest
				{
					Url = url,
					Method = "PUT",
					ContentType = "application/json",
					Data = data
				}).ConfigureAwait(false);
			return response;
		}

		public async Task<ApiResponse> PutAsync(string url, List<KeyValuePair<string, string>> args, string data = "")
		{
			var response = await GetAsync(
				new ApiRequest
				{
					Url = url,
					Args = args,
					Method = "PUT",
					ContentType = "application/json",
					Data = data
				}).ConfigureAwait(false);
			return response;
		}

		private async Task<TResponse> GetAsync<TResponse>(ApiRequest apiRequest)
		{
			string[] value = { "" };

			if (apiRequest.Args?.Count > 0)
			{
				apiRequest.Args.ForEach(e => value[0] += e.Key + "=" + Uri.EscapeDataString(e.Value) + "&");
				value[0] = value[0].Trim('&');
			}

			if (apiRequest.Method == "GET" && !string.IsNullOrEmpty(value[0]))
			{
				apiRequest.Url += "?" + value[0];
			}

			var authRequest = (HttpWebRequest)WebRequest.Create(apiRequest.Url);

			authRequest.Method = apiRequest.Method;

			authRequest.ContentType = apiRequest.ContentType;

			authRequest.Credentials = CredentialCache.DefaultNetworkCredentials;

			authRequest.Headers.Add(GetAuthHeader());

			var authResponse = (HttpWebResponse)await authRequest
				.GetResponseAsync()
				.ConfigureAwait(false);
			string content;
			using (var reader = new StreamReader(authResponse.GetResponseStream(), Encoding.UTF8))
			{
				content = reader.ReadToEnd();
			}

			var rsp = JsonConvert.DeserializeObject<TResponse>(content);
			return rsp;
		}

		private async Task<ApiResponse> GetAsync(ApiRequest apiRequest)
		{
			string[] value = { "" };

			if (apiRequest.Args?.Count > 0)
			{
				apiRequest.Args.ForEach(e => value[0] += e.Key + "=" + Uri.EscapeDataString(e.Value) + "&");
				value[0] = value[0].Trim('&');
			}

			if (apiRequest.Method == "GET" && !string.IsNullOrEmpty(value[0]))
			{
				apiRequest.Url += "?" + value[0];
			}

			var authRequest = (HttpWebRequest)WebRequest.Create(apiRequest.Url);

			authRequest.Method = apiRequest.Method;
			authRequest.ContentType = apiRequest.ContentType;
			authRequest.Credentials = CredentialCache.DefaultNetworkCredentials;

			authRequest.Headers.Add(GetAuthHeader());

			if (apiRequest.Method == "POST" || apiRequest.Method == "PUT")
			{
				var utd8WithoutBom = new UTF8Encoding(false);

				value[0] += apiRequest.Data;
				authRequest.ContentLength = utd8WithoutBom.GetByteCount(value[0]);
				using var writer = new StreamWriter(authRequest.GetRequestStream(), utd8WithoutBom);
				writer.Write(value[0]);
			}

			var authResponse = (HttpWebResponse)await authRequest
				.GetResponseAsync()
				.ConfigureAwait(false);
			string content;
			using (var reader = new StreamReader(authResponse.GetResponseStream(), Encoding.UTF8))
			{
				content = reader.ReadToEnd();
			}

			if ((string.IsNullOrEmpty(content)
				  || string.Equals(content, "null", StringComparison.OrdinalIgnoreCase))
				 && authResponse.StatusCode == HttpStatusCode.OK
				 && authResponse.Method == "DELETE")
			{
				var rsp = new ApiResponse
				{
					Data = new JObject(),
					RelatedDataUpdatedAt = DateTime.Now,
					StatusCode = authResponse.StatusCode,
					Method = authResponse.Method
				};

				return rsp;
			}

			try
			{
				var rsp = string.Equals(content, "null", StringComparison.OrdinalIgnoreCase)
					? new ApiResponse { Data = null }
					: JsonConvert.DeserializeObject<ApiResponse>(content);

				rsp.StatusCode = authResponse.StatusCode;
				rsp.Method = authResponse.Method;
				return rsp;
			}
			catch (Exception)
			{
				var token = JToken.Parse(content);
				var rsp = new ApiResponse
				{
					Data = token,
					RelatedDataUpdatedAt = DateTime.Now,
					StatusCode = authResponse.StatusCode,
					Method = authResponse.Method
				};
				return rsp;
			}
		}

		private string GetAuthHeader()
		{
			var encodedApiKey = Convert.ToBase64String(Encoding.ASCII.GetBytes(ApiToken + ":api_token"));
			return "Authorization: Basic " + encodedApiKey;
		}
	}
}
