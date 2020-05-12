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
		private IApiServiceAsync TogglSrv { get; set; }

		public UserServiceAsync(string apiKey)
			: this(new ApiServiceAsync(apiKey))
		{
		}

		public UserServiceAsync(IApiServiceAsync srv)
		{
			TogglSrv = srv;
		}

		public async Task<User> GetCurrent()
		{
			var response = await TogglSrv
				.Get(ApiRoutes.User.CurrentUrl)
				.ConfigureAwait(false);
			return response.GetData<User>();
		}

		public async Task<UserExtended> GetCurrentExtended()
		{
			var response = await TogglSrv
				.Get(ApiRoutes.User.CurrentExtendedUrl)
				.ConfigureAwait(false);
			return response.GetData<UserExtended>();
		}

		public async Task<UserExtended> GetCurrentChanged(DateTime since)
		{
			var response = await TogglSrv
				.Get(string.Format(ApiRoutes.User.CurrentSinceUrl, since.ToUnixTime()))
				.ConfigureAwait(false);
			return response.GetData<UserExtended>();
		}

		public async Task<User> Edit(User u)
		{
			var data = u.ToJson();

			var response = await TogglSrv
				.Put(string.Format(ApiRoutes.User.EditUrl), data)
				.ConfigureAwait(false);
			return response.GetData<User>();
		}

		public async Task<string> ResetApiToken()
		{
			var response = await TogglSrv
				.Post(ApiRoutes.User.ResetApiTokenUrl, null)
				.ConfigureAwait(false);
			return response.GetData<string>();
		}

		public async Task<List<User>> ForWorkspace(int id)
		{
			var url = string.Format(ApiRoutes.Workspace.ListWorkspaceUsersUrl, id);
			var response = await TogglSrv
				.Get(url)
				.ConfigureAwait(false);
			return response.GetData<List<User>>();
		}

		public async Task<User> Add(User u)
		{
			var url = string.Format(ApiRoutes.User.AddUrl);
			var data = u.ToJson();

			var response = await TogglSrv
				.Post(url, data)
				.ConfigureAwait(false);
			return response.GetData<User>();
		}
	}
}
