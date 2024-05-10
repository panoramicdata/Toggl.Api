using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;

namespace Toggl.Api.Interfaces;

public interface IProjects
{
	/// <summary>
	/// Get projects for given workspace.
	/// https://engineering.toggl.com/docs/api/projects#get-workspaceprojects
	/// </summary>
	/// <param name="workspaceId">Numeric ID of the workspace</param>
	/// <param name="isActive">active</param>
	/// <param name="since">Retrieve projects created/modified/deleted since this date using UNIX timestamp.</param>
	/// <param name="isBillable">billable</param>
	/// <param name="userIds">user_ids</param>
	/// <param name="clientIds">client_ids</param>
	/// <param name="groupIds">group_ids</param>
	/// <param name="statuses">statuses</param>
	/// <param name="nameContains">name</param>
	/// <param name="page">page</param>
	/// <param name="sortField">sort_field</param>
	/// <param name="sortOrder">sort_order</param>
	/// <param name="onlyTemplates">only_templates</param>
	/// <param name="perPage">Number of items per page, default 151. Cannot exceed 200.</param>
	/// <param name="cancellationToken">A cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/workspaces/{workspace_id}/projects")]
	Task<ICollection<Project>> GetPageAsync(
		[AliasAs("workspace_id")] long workspaceId,
		[AliasAs("isActive")] bool? isActive,
		[AliasAs("since")] long? since,
		[AliasAs("billable")] bool? isBillable,
		[AliasAs("user_ids")] ICollection<int>? userIds,
		[AliasAs("client_ids")] ICollection<int>? clientIds,
		[AliasAs("group_ids")] ICollection<int>? groupIds,
		[AliasAs("statuses")] ICollection<ProjectStatus>? statuses,
		[AliasAs("name")] string nameContains,
		[AliasAs("page")] int page,
		[AliasAs("sort_field")] string sortField,
		[AliasAs("sort_order")] SortDirection sortOrder,
		[AliasAs("only_templates")] bool onlyTemplates,
		[AliasAs("per_page")][Range(1, 200)] int? perPage,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Get project for given workspace.
	/// https://engineering.toggl.com/docs/api/projects#get-workspaceproject
	/// </summary>
	/// <param name="workspaceId">Numeric ID of the workspace</param>
	/// <param name="projectId">Numeric ID of the project</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/workspaces/{workspace_id}/projects/{project_id}")]
	Task<Project> GetAsync(
		[AliasAs("workspace_id")] long workspaceId,
		[AliasAs("project_id")] long projectId,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Returns project users.
	/// https://engineering.toggl.com/docs/api/projects#get-get-workspace-projects-users
	/// </summary>
	/// <param name="workspaceId">The workspace id</param>
	/// <param name="projectIds">Numeric IDs of projects</param>
	/// <param name="withGroupMembers">Include group members</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/workspaces/{workspace_id}/project_users")]
	Task<ICollection<ProjectUser>> GetUsersAsync(
		[AliasAs("workspace_id")] long workspaceId,
		[AliasAs("project_ids")] ICollection<long>? projectIds,
		[AliasAs("with_group_members")] bool? withGroupMembers,
		CancellationToken cancellationToken
		);
}