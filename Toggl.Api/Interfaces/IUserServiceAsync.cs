using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Toggl.Api.DataObjects;

namespace Toggl.Api.Interfaces
{
	/// <summary>
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/users.md#users
	/// </summary>
	public interface IUserServiceAsync
	{
		/// <summary>
		/// Method to get basic information about a user.
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/users.md#get-current-user-data
		/// </summary>
		Task<User> GetCurrentAsync();

		/// <summary>
		/// Method to get basic information about a user and to get all the workspaces, clients, projects,
		/// tasks, time entries and tags which the user can see
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/users.md#get-current-user-data
		/// </summary>
		Task<UserExtended> GetCurrentExtendedAsync();

		/// <summary>
		/// Method to get basic information about a user and to get all the workspaces, clients, projects,
		/// tasks, time entries and tags which the user can see which have changed after certain time,
		/// add since parameter to the query.
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/users.md#get-current-user-data
		/// </summary>
		Task<UserExtended> GetCurrentChangedAsync(DateTime since);

		/// <summary>
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/users.md#update-user-data
		/// </summary>
		/// <param name="u">UserEdit</param>
		/// <returns>User</returns>
		Task<User> UpdateAsync(User u);

		/// <summary>
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/users.md#reset-api-token
		/// </summary>
		Task<string> ResetApiTokenAsync();

		/// <summary>
		///  Get list of users for a workspace
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-users
		/// </summary>
		/// <param name="id"></param>
		Task<List<User>> GetForWorkspaceAsync(long id);

		/// <summary>
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/users.md#get-workspace-users
		/// </summary>
		/// <param name="u"></param>
		Task<User> CreateAsync(User u);
	}
}