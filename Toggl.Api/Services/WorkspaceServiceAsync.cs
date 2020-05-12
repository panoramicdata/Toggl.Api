using System.Collections.Generic;
using System.Threading.Tasks;
using Toggl.Api.DataObjects;
using Toggl.Api.Interfaces;
using Toggl.Api.Routes;

namespace Toggl.Api.Services
{
	/// <summary>
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#workspaces
	/// </summary>
	public class WorkspaceServiceAsync : IWorkspaceServiceAsync
	{
		private IApiServiceAsync TogglSrv { get; set; }

		public WorkspaceServiceAsync(string apiKey)
			: this(new ApiServiceAsync(apiKey))
		{
		}

		public WorkspaceServiceAsync(IApiServiceAsync srv)
		{
			TogglSrv = srv;
		}

		public async Task<List<Workspace>> List()
		{
			var response = await TogglSrv.Get(ApiRoutes.Workspace.ListWorkspaceUrl).ConfigureAwait(false);
			return response.GetData<List<Workspace>>();
		}

		public async Task<List<User>> Users(int workspaceId)
		{
			var url = string.Format(ApiRoutes.Workspace.ListWorkspaceUsersUrl, workspaceId);
			var response = await TogglSrv.Get(url).ConfigureAwait(false);
			return response.GetData<List<User>>();
		}

		public async Task<List<ProjectUser>> ProjectUsers(int workspaceId)
		{
			var url = string.Format(ApiRoutes.Workspace.ListWorkspaceProjectUsersUrl, workspaceId);
			var response = await TogglSrv.Get(url).ConfigureAwait(false);
			return response.GetData<List<ProjectUser>>();
		}

		public async Task<List<Client>> Clients(int workspaceId)
		{
			var url = string.Format(ApiRoutes.Workspace.ListWorkspaceClientsUrl, workspaceId);
			var response = await TogglSrv.Get(url).ConfigureAwait(false);
			return response.GetData<List<Client>>();
		}

		public async Task<List<Project>> Projects(int workspaceId)
		{
			var url = string.Format(ApiRoutes.Workspace.ListWorkspaceProjectsUrl, workspaceId);
			var response = await TogglSrv.Get(url).ConfigureAwait(false);
			return response.GetData<List<Project>>();
		}

		public async Task<List<DataObjects.Task>> Tasks(int workspaceId)
		{
			var url = string.Format(ApiRoutes.Workspace.ListWorkspaceTasksUrl, workspaceId);
			var response = await TogglSrv.Get(url).ConfigureAwait(false);
			return response.GetData<List<DataObjects.Task>>();
		}

		public async Task<List<Tag>> Tags(int workspaceId)
		{
			var url = string.Format(ApiRoutes.Workspace.ListWorkspaceTagsUrl, workspaceId);
			var response = await TogglSrv.Get(url).ConfigureAwait(false);
			return response.GetData<List<Tag>>();
		}

		public async Task<TimeEntry> GetTimeEntry(int workspaceId, long workspaceTimeEntryId)
		{
			var url = string.Format(ApiRoutes.Workspace.GetWorkspaceTimeEntry, workspaceId, workspaceTimeEntryId);
			var response = await TogglSrv.Get(url).ConfigureAwait(false);
			var data = response.GetData<TimeEntry>();
			return data;
		}

		Task<List<DataObjects.Task>> IWorkspaceServiceAsync.Tasks(int workspaceId) => throw new System.NotImplementedException();
	}
}