using System.Collections.Generic;
using System.Threading.Tasks;
using Toggl.Api.DataObjects;

namespace Toggl.Api.Interfaces
{
	/// <summary>
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#workspaces
	/// </summary>
	public interface IWorkspaceServiceAsync
	{
		/// <summary>
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspaces
		/// </summary>
		Task<List<Workspace>> GetAllAsync();

		/// <summary>
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-users
		/// </summary>
		/// <param name="workspaceId"></param>
		Task<List<User>> GetUsersAsync(long workspaceId);

		/// <summary>
		/// Project users
		/// </summary>
		/// <param name="workspaceId"></param>
		Task<List<ProjectUser>> GetProjectUsersAsync(long workspaceId);

		/// <summary>
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-clients
		/// </summary>
		/// <param name="workspaceId"></param>
		Task<List<Client>> GetClientsAsync(long workspaceId);

		/// <summary>
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-projects
		/// </summary>
		/// <param name="workspaceId"></param>
		Task<List<Project>> GetProjectsAsync(long workspaceId);

		/// <summary>
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-tasks
		/// </summary>
		/// <param name="workspaceId"></param>
		Task<List<DataObjects.Task>> GetTasksAsync(long workspaceId);

		/// <summary>
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-tags
		/// </summary>
		/// <param name="workspaceId"></param>
		Task<List<Tag>> GetTagsAsync(long workspaceId);

		/// <summary>
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-timeentries
		/// </summary>
		/// <param name="workspaceId"></param>
		/// <param name="workspaceTimeEntryId"></param>
		Task<TimeEntry> GetTimeEntryAsync(long workspaceId, long workspaceTimeEntryId);
	}
}