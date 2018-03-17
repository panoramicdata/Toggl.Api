using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;
using Toggl.Api.DataObjects;

namespace Toggl.Api
{
	public class TogglApiViaRestSharp
	{
		private readonly string _username;
		private readonly string _password;

		/// <summary>
		/// Creates an TogglApi .Net client
		/// </summary>
		/// <param name="username">Provide username, or use "api" to authenticate by api token</param>
		/// <param name="password">Password</param>
		public TogglApiViaRestSharp(string username, string password)
		{
			_username = username ?? throw new ArgumentNullException("username");
			_password = password ?? throw new ArgumentNullException("password");			
		}
		
		public T Execute<T>(RestRequest request) where T : new()
		{
			var client = new RestClient
			{
				BaseUrl = new Uri("https://www.toggl.com/api/v8"),
				Authenticator = new HttpBasicAuthenticator(_username, _password)
			};

			var response = client.Execute<T>(request);

			if (response.Content == "null") // Toggl returns "null", when no elements found
				return default(T);

			if (response.ErrorException != null)
			{
				const string message = "Error retrieving response.  Check inner details for more info.";
				var togglException = new ApplicationException(message, response.ErrorException);
				throw togglException;
			}

			if (response.StatusCode != HttpStatusCode.OK)
				throw new ApplicationException(
					string.Format(
						"Response status code: {0}, Response content: {1}",
						response.StatusCode, 
						response.Content ?? "empty"));
	
			return response.Data;
		}

		public UserRestSharp GetUserInfo()
		{
			var request = new RestRequest
			{
				Resource = "me",
				RootElement = "data"
			};

			return Execute<UserRestSharp>(request);
		}

		public List<ClientRestSharp> GetClientsVisibleToUser()
		{
			var request = new RestRequest
			{
				Resource = "clients"
			};

			var result = Execute<List<ClientRestSharp>>(request);

			if (result == null)
				return new List<ClientRestSharp>();

			return result;
		}

		public ClientRestSharp CreateClient(ClientRestSharp clientToAdd)
		{
			var request = new RestRequest
			{
				Resource = "clients",
				Method = Method.POST,
				RootElement = "data",
				RequestFormat = DataFormat.Json
			};
			request.AddBody(new { client = clientToAdd });
			
			return Execute<ClientRestSharp>(request);			
		}

		public ClientRestSharp GetClientDetails(int id)
		{
			var request = new RestRequest
			{
				Resource = "clients/{client_id}",
				Method = Method.GET,
				RootElement = "data",
				RequestFormat = DataFormat.Json
			};
			request.AddParameter("client_id", id, ParameterType.UrlSegment);

			return Execute<ClientRestSharp>(request);
		}

		public List<WorkspaceRestSharp> GetWorkspaces()
		{
			var request = new RestRequest
			{
				Resource = "workspaces"
			};
			var result = Execute<List<WorkspaceRestSharp>>(request);
			return result ?? new List<WorkspaceRestSharp>();
		}

		public ClientRestSharp UpdateClient(ClientRestSharp updatedClient)
		{
			var request = new RestRequest
			{
				Resource = "clients/{client_id}",
				Method = Method.PUT,
				RootElement = "data",
				RequestFormat = DataFormat.Json
			};
			request.AddBody(new { client = updatedClient });
			if (updatedClient.id != null)
			{
				request.AddParameter("client_id", updatedClient.id.Value, ParameterType.UrlSegment);
			}

			return Execute<ClientRestSharp>(request);		
		}

		public void DeleteClient(int id)
		{
			var request = new RestRequest
			{
				Resource = "clients/{client_id}",
				Method = Method.DELETE,
				RootElement = "data",
				RequestFormat = DataFormat.Json
			};
			request.AddParameter("client_id", id, ParameterType.UrlSegment);
			Execute<object>(request);	
		}
	}
}