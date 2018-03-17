using System.Collections.Generic;
using Toggl.Api.DataObjects;
using Toggl.Api.Interfaces;
using Toggl.Api.Routes;

namespace Toggl.Api.Services
{
	/// <summary>
	///     https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#workspaces
	/// </summary>
	public class WorkspaceService : IWorkspaceService
	{
		public WorkspaceService(string apiKey)
			: this(new ApiService(apiKey))
		{
		}

		public WorkspaceService(IApiService srv)
		{
			ToggleSrv = srv;
		}

		private IApiService ToggleSrv { get; }

		public List<Workspace> List()
		{
			return ToggleSrv.Get(ApiRoutes.Workspace.ListWorkspaceUrl).GetData<List<Workspace>>();
		}

		public List<User> Users(int workspaceId)
		{
			var url = string.Format(ApiRoutes.Workspace.ListWorkspaceUsersUrl, workspaceId);
			return ToggleSrv.Get(url).GetData<List<User>>();
		}


		public List<Client> Clients(int workspaceId)
		{
			var url = string.Format(ApiRoutes.Workspace.ListWorkspaceClientsUrl, workspaceId);
			return ToggleSrv.Get(url).GetData<List<Client>>();
		}

		public List<Project> Projects(int workspaceId)
		{
			var url = string.Format(ApiRoutes.Workspace.ListWorkspaceProjectsUrl, workspaceId);
			return ToggleSrv.Get(url).GetData<List<Project>>();
		}


		public List<Task> Tasks(int workspaceId)
		{
			var url = string.Format(ApiRoutes.Workspace.ListWorkspaceTasksUrl, workspaceId);
			return ToggleSrv.Get(url).GetData<List<Task>>();
		}

		public List<Tag> Tags(int workspaceId)
		{
			var url = string.Format(ApiRoutes.Workspace.ListWorkspaceTagsUrl, workspaceId);
			return ToggleSrv.Get(url).GetData<List<Tag>>();
		}
	}
}