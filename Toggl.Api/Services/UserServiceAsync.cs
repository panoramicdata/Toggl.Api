using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Toggl.Api.DataObjects;
using Toggl.Api.Extensions;
using Toggl.Api.Interfaces;
using Toggl.Api.Routes;

namespace Toggl.Api.Services
{
	public class UserServiceAsync : IUserServiceAsync
	{

		private IApiServiceAsync ToggleSrv { get; set; }


		public UserServiceAsync(string apiKey)
			: this(new ApiServiceAsync(apiKey))
		{

		}

		public UserServiceAsync(IApiServiceAsync srv)
		{
			ToggleSrv = srv;
		}


		public async Task<User> GetCurrent()
		{
			var url = ApiRoutes.User.CurrentUrl;

			var response = await ToggleSrv.Get(url);
			var obj = response.GetData<User>();

			return obj;
		}

		public async Task<UserExtended> GetCurrentExtended()
		{
			var url = ApiRoutes.User.CurrentExtendedUrl;

			var response = await ToggleSrv.Get(url);
			var obj = response.GetData<UserExtended>();

			return obj;
		}

		public async Task<UserExtended> GetCurrentChanged(DateTime since)
		{
			var url = string.Format(ApiRoutes.User.CurrentSinceUrl, since.ToUnixTime());

			var response = await ToggleSrv.Get(url);
			var obj = response.GetData<UserExtended>();

			return obj;
		}

		public async Task<User> Edit(User u)
		{
			var url = string.Format(ApiRoutes.User.EditUrl);
			var data = u.ToJson();

			var response = await ToggleSrv.Put(url, data);
			u = response.GetData<User>();

			return u;
		}

		public async Task<string> ResetApiToken()
		{
			var url = ApiRoutes.User.ResetApiTokenUrl;

			var response = await ToggleSrv.Post(url, null);
			var apiToken = response.GetData<string>();

			return apiToken;
		}

		public async Task<List<User>> GetForWorkspace(int id)
		{
			var url = string.Format(ApiRoutes.Workspace.ListWorkspaceUsersUrl, id);
			var response = await ToggleSrv.Get(url);
			var data = response.GetData<List<User>>();
			return data;
		}

		public async Task<User> Add(User u)
		{
			var url = string.Format(ApiRoutes.User.AddUrl);
			var data = u.ToJson();

			var response = await ToggleSrv.Post(url, data);
			u = response.GetData<User>();

			return u;
		}
	}
}
