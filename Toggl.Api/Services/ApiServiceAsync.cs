using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

		public async Task Initialize()
		{
			if (Session != null && !string.IsNullOrEmpty(Session.ApiToken))
			{
				return;
			}

			await GetSession();
		}

		public async Task<Session> GetSession()
		{

			var args = new List<KeyValuePair<string, string>>();

			var response = await Get(ApiRoutes.Session.Me, args);
			Session = response.GetData<Session>();

			ApiToken = Session.ApiToken;

			return Session;
		}

		public async Task<ApiResponse> Get(string url)
		{
			var response = await Get(new ApiRequest
			{
				Url = url
			});
			return response;
		}

		public async Task<ApiResponse> Get(string url, List<KeyValuePair<string, string>> args)
		{
			var response = await Get(new ApiRequest
			{
				Url = url,
				Args = args
			});
			return response;
		}

		public async Task<TResponse> Get<TResponse>(string url, List<KeyValuePair<string, string>> args)
		{
			var response = await Get<TResponse>(new ApiRequest
			{
				Url = url,
				Args = args
			});
			return response;
		}

		public async Task<ApiResponse> Delete(string url)
		{
			var response = await Get(new ApiRequest
			{
				Url = url,
				Method = "DELETE"
			});
			return response;
		}

		public async Task<ApiResponse> Delete(string url, List<KeyValuePair<string, string>> args)
		{
			var response = await Get(new ApiRequest
			{
				Url = url,
				Method = "DELETE",
				Args = args
			});
			return response;
		}

		public async Task<ApiResponse> Post(string url, string data)
		{
			var response = await Get(
				new ApiRequest
				{
					Url = url,
					Method = "POST",
					ContentType = "application/json",
					Data = data
				});
			return response;
		}

		public async Task<ApiResponse> Post(string url, List<KeyValuePair<string, string>> args, string data = "")
		{
			var response = await Get(
				new ApiRequest
				{
					Url = url,
					Args = args,
					Method = "POST",
					ContentType = "application/json",
					Data = data
				});
			return response;
		}

		public async Task<ApiResponse> Put(string url, string data)
		{
			var response = await Get(
				new ApiRequest
				{
					Url = url,
					Method = "PUT",
					ContentType = "application/json",
					Data = data
				});
			return response;
		}

		public async Task<ApiResponse> Put(string url, List<KeyValuePair<string, string>> args, string data = "")
		{
			var response = await Get(
				new ApiRequest
				{
					Url = url,
					Args = args,
					Method = "PUT",
					ContentType = "application/json",
					Data = data
				});
			return response;
		}

		private async Task<TResponse> Get<TResponse>(ApiRequest apiRequest)
		{
			string[] value = {""};

			if (apiRequest.Args != null && apiRequest.Args.Count > 0)
			{
				apiRequest.Args.ForEach(e => value[0] += e.Key + "=" + Uri.EscapeDataString(e.Value) + "&");
				value[0] = value[0].Trim('&');
			}

			if (apiRequest.Method == "GET" && !string.IsNullOrEmpty(value[0]))
			{
				apiRequest.Url += "?" + value[0];
			}

			var authRequest = (HttpWebRequest) WebRequest.Create(apiRequest.Url);

			authRequest.Method = apiRequest.Method;

			authRequest.ContentType = apiRequest.ContentType;

			authRequest.Credentials = CredentialCache.DefaultNetworkCredentials;

			authRequest.Headers.Add(GetAuthHeader());

			var authResponse = (HttpWebResponse)await authRequest.GetResponseAsync();
			string content;
			using (var reader = new StreamReader(authResponse.GetResponseStream(), Encoding.UTF8))
			{
				content = reader.ReadToEnd();
			}

			var rsp = JsonConvert.DeserializeObject<TResponse>(content);
			return rsp;
		}

		private async Task<ApiResponse> Get(ApiRequest apiRequest)
		{
			string[] value = {""};

			if (apiRequest.Args != null && apiRequest.Args.Count > 0)
			{
				apiRequest.Args.ForEach(e => value[0] += e.Key + "=" + Uri.EscapeDataString(e.Value) + "&");
				value[0] = value[0].Trim('&');
			}

			if (apiRequest.Method == "GET" && !string.IsNullOrEmpty(value[0]))
			{
				apiRequest.Url += "?" + value[0];
			}

			var authRequest = (HttpWebRequest) WebRequest.Create(apiRequest.Url);

			authRequest.Method = apiRequest.Method;
			authRequest.ContentType = apiRequest.ContentType;
			authRequest.Credentials = CredentialCache.DefaultNetworkCredentials;

			authRequest.Headers.Add(GetAuthHeader());

			if (apiRequest.Method == "POST" || apiRequest.Method == "PUT")
			{
				var utd8WithoutBom = new UTF8Encoding(false);

				value[0] += apiRequest.Data;
				authRequest.ContentLength = utd8WithoutBom.GetByteCount(value[0]);
				using (var writer = new StreamWriter(authRequest.GetRequestStream(), utd8WithoutBom))
				{
					writer.Write(value[0]);
				}
			}

			var authResponse = (HttpWebResponse) authRequest.GetResponse();
			string content;
			using (var reader = new StreamReader(authResponse.GetResponseStream(), Encoding.UTF8))
			{
				content = reader.ReadToEnd();
			}

			if ((string.IsNullOrEmpty(content)
			     || content.ToLower() == "null")
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
				var rsp = content.ToLower() == "null"
					? new ApiResponse {Data = null}
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
