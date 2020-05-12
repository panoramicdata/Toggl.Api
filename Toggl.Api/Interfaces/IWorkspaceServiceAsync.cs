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
		Task<List<Workspace>> List();

		/// <summary>
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-users
		/// </summary>
		/// <param name="workspaceId"></param>
		Task<List<User>> Users(int workspaceId);

		/// <summary>
		/// Project users
		/// </summary>
		/// <param name="workspaceId"></param>
		Task<List<ProjectUser>> ProjectUsers(int workspaceId);

		/// <summary>
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-clients
		/// </summary>
		/// <param name="workspaceId"></param>
		Task<List<Client>> Clients(int workspaceId);

		/// <summary>
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-projects
		/// </summary>
		/// <param name="workspaceId"></param>
		Task<List<Project>> Projects(int workspaceId);

		/// <summary>
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-tasks
		/// </summary>
		/// <param name="workspaceId"></param>
		Task<List<DataObjects.Task>> Tasks(int workspaceId);

		/// <summary>
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-tags
		/// </summary>
		/// <param name="workspaceId"></param>
		Task<List<Tag>> Tags(int workspaceId);

		/// <summary>
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspace-timeentries
		/// </summary>
		/// <param name="workspaceId"></param>
		/// <param name="workspaceTimeEntryId"></param>
		Task<TimeEntry> GetTimeEntry(int workspaceId, long workspaceTimeEntryId);
	}
}