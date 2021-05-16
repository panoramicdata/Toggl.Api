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
		private IApiServiceAsync TogglSrv { get; }

		public UserServiceAsync(string apiKey)
			: this(new ApiServiceAsync(apiKey))
		{
		}

		public UserServiceAsync(IApiServiceAsync srv)
		{
			TogglSrv = srv;
		}

		public async Task<User> GetCurrentAsync()
		{
			var response = await TogglSrv
				.GetAsync(ApiRoutes.User.CurrentUrl)
				.ConfigureAwait(false);
			return response.GetData<User>();
		}

		public async Task<UserExtended> GetCurrentExtendedAsync()
		{
			var response = await TogglSrv
				.GetAsync(ApiRoutes.User.CurrentExtendedUrl)
				.ConfigureAwait(false);
			return response.GetData<UserExtended>();
		}

		public async Task<UserExtended> GetCurrentChangedAsync(DateTime since)
		{
			var response = await TogglSrv
				.GetAsync(string.Format(ApiRoutes.User.CurrentSinceUrl, since.ToUnixTime()))
				.ConfigureAwait(false);
			return response.GetData<UserExtended>();
		}

		public async Task<User> UpdateAsync(User u)
		{
			var data = u.ToJson();

			var response = await TogglSrv
				.PutAsync(string.Format(ApiRoutes.User.EditUrl), data)
				.ConfigureAwait(false);
			return response.GetData<User>();
		}

		public async Task<string> ResetApiTokenAsync()
		{
			var response = await TogglSrv
				.PostAsync(ApiRoutes.User.ResetApiTokenUrl, null)
				.ConfigureAwait(false);
			return response.GetData<string>();
		}

		public async Task<List<User>> GetForWorkspaceAsync(int id)
		{
			var url = string.Format(ApiRoutes.Workspace.ListWorkspaceUsersUrl, id);
			var response = await TogglSrv
				.GetAsync(url)
				.ConfigureAwait(false);
			return response.GetData<List<User>>();
		}

		public async Task<User> CreateAsync(User u)
		{
			var url = string.Format(ApiRoutes.User.AddUrl);
			var data = u.ToJson();

			var response = await TogglSrv
				.PostAsync(url, data)
				.ConfigureAwait(false);
			return response.GetData<User>();
		}
	}
}
