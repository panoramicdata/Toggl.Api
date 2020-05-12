using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Toggl.Api.DataObjects;
using Toggl.Api.Interfaces;
using Toggl.Api.Routes;

namespace Toggl.Api.Services
{
	public class ProjectServiceAsync : IProjectServiceAsync
	{
		private readonly string _projectsUrl = ApiRoutes.Project.ProjectsUrl;

		private IApiServiceAsync TogglSrv { get; set; }

		public ProjectServiceAsync(string apiKey)
			: this(new ApiServiceAsync(apiKey))
		{
		}

		public ProjectServiceAsync(IApiServiceAsync srv)
		{
			TogglSrv = srv;
		}

		/// <summary>
		/// List projects
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md
		/// </summary>
		public async Task<List<Project>> List()
		{
			var lstProj = new List<Project>();
			var response = await TogglSrv.Get(ApiRoutes.Workspace.ListWorkspaceUrl).ConfigureAwait(false);
			var lstWrkSpc = response.GetData<List<Workspace>>();
			lstWrkSpc.ForEach(async e =>
			{
				var projs = await ForWorkspace(e.Id).ConfigureAwait(false);
				lstProj.AddRange(projs);
			});
			return lstProj;
		}

		public async Task<List<Project>> ForWorkspace(int id)
		{
			var url = string.Format(ApiRoutes.Workspace.ListWorkspaceProjectsUrl, id);
			var response = await TogglSrv.Get(url).ConfigureAwait(false);
			return response.GetData<List<Project>>();
		}

		public async Task<List<Project>> ForClient(Client client)
		{
			if (!client.Id.HasValue)
				throw new InvalidOperationException("Client Id not set");
			return await ForClient(client.Id.Value).ConfigureAwait(false);
		}

		public async Task<List<Project>> ForClient(int id)
		{
			var response = await TogglSrv.Get(string.Format(ApiRoutes.Client.ClientProjectsUrl, id)).ConfigureAwait(false);
			var data = response.GetData<List<Project>>();
			return data;
		}

		public async Task<Project> Get(int id)
		{
			var result = await List().ConfigureAwait(false);
			return result.FirstOrDefault(w => w.Id == id);
		}

		/// <summary>
		/// Add a project
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#create-project
		/// </summary>
		/// <param name="project"></param>
		public async Task<Project> Add(Project project)
		{
			var response = await TogglSrv.Post(_projectsUrl, project.ToJson()).ConfigureAwait(false);
			var data = response.GetData<Project>();
			return data;
		}

		/// <summary>
		/// Delete a project
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#delete-a-project
		/// </summary>
		/// <param name="id"></param>
		public async Task<bool> Delete(int id)
		{
			var url = string.Format(ApiRoutes.Project.DetailUrl, id);
			var rsp = await TogglSrv.Delete(url).ConfigureAwait(false);
			return rsp.StatusCode == HttpStatusCode.OK;
		}

		public async Task<bool> DeleteIfAny(int[] ids)
		{
			if (ids.Length == 0 || ids == null)
				return true;
			return await Delete(ids).ConfigureAwait(false);
		}

		public async Task<bool> Delete(int[] ids)
		{
			if (ids.Length == 0 || ids == null)
				throw new ArgumentNullException(nameof(ids));

			var url = string.Format(
				ApiRoutes.Project.ProjectsBulkDeleteUrl,
				string.Join(",", ids.Select(id => id.ToString()).ToArray()));

			var rsp = await TogglSrv.Delete(url).ConfigureAwait(false);
			return rsp.StatusCode == HttpStatusCode.OK;
		}
	}
}