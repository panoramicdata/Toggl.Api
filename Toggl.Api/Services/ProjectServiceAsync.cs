using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Toggl.Api.DataObjects;
using Toggl.Api.Interfaces;
using Toggl.Api.Routes;

namespace Toggl.Api.Services;

public class ProjectServiceAsync : IProjectServiceAsync
{
	private readonly string _projectsUrl = ApiRoutes.Project.ProjectsUrl;

	private IApiServiceAsync TogglSrv { get; }

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
	public async Task<List<Project>> ListAsync()
	{
		var allProjects = new List<Project>();
		var apiResponse = await TogglSrv.GetAsync(ApiRoutes.Workspace.ListWorkspaceUrl).ConfigureAwait(false);
		var workspaces = apiResponse.GetData<List<Workspace>>();
		foreach (var workspace in workspaces)
		{
			var workspaceProjects = await GetForWorkspaceAsync(workspace.Id)
				.ConfigureAwait(false);
			allProjects.AddRange(workspaceProjects);
		}
		return allProjects;
	}

	public async Task<List<Project>> GetForWorkspaceAsync(long id)
	{
		var url = string.Format(ApiRoutes.Workspace.ListWorkspaceProjectsUrl, id);
		var response = await TogglSrv.GetAsync(url).ConfigureAwait(false);
		return response.GetData<List<Project>>();
	}

	public async Task<List<Project>> GetForClientAsync(Client client)
	{
		if (!client.Id.HasValue)
		{
			throw new InvalidOperationException("Client Id not set");
		}

		return await GetForClientAsync(client.Id.Value).ConfigureAwait(false);
	}

	public async Task<List<Project>> GetForClientAsync(long id)
	{
		var response = await TogglSrv.GetAsync(string.Format(ApiRoutes.Client.ClientProjectsUrl, id)).ConfigureAwait(false);
		var data = response.GetData<List<Project>>();
		return data;
	}

	public async Task<Project> GetAsync(long id)
	{
		var result = await ListAsync().ConfigureAwait(false);
		return result.Find(w => w.Id == id);
	}

	/// <summary>
	/// Add a project
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#create-project
	/// </summary>
	/// <param name="project"></param>
	public async Task<Project> AddAsync(Project project)
	{
		var response = await TogglSrv.PostAsync(_projectsUrl, project.ToJson()).ConfigureAwait(false);
		var data = response.GetData<Project>();
		return data;
	}

	/// <summary>
	/// Delete a project
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#delete-a-project
	/// </summary>
	/// <param name="id"></param>
	public async Task<bool> DeleteAsync(int id)
	{
		var url = string.Format(ApiRoutes.Project.DetailUrl, id);
		var rsp = await TogglSrv.DeleteAsync(url).ConfigureAwait(false);
		return rsp.StatusCode == HttpStatusCode.OK;
	}

	public async Task<bool> DeleteIfAnyAsync(int[] ids)
	{
		if (ids.Length == 0 || ids == null)
		{
			return true;
		}

		return await DeleteAsync(ids).ConfigureAwait(false);
	}

	public async Task<bool> DeleteAsync(int[] ids)
	{
		if (ids.Length == 0 || ids == null)
		{
			throw new ArgumentNullException(nameof(ids));
		}

		var url = string.Format(
			ApiRoutes.Project.ProjectsBulkDeleteUrl,
			string.Join(",", ids.Select(id => id.ToString()).ToArray()));

		var rsp = await TogglSrv.DeleteAsync(url).ConfigureAwait(false);
		return rsp.StatusCode == HttpStatusCode.OK;
	}
}