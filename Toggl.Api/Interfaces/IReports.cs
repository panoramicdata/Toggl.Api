using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;

namespace Toggl.Api.Interfaces;

public interface IReports
{
	/// <summary>
	/// Returns summary user projects.
	/// https://engineering.toggl.com/docs/reports/summary_reports#post-list-project-users
	/// </summary>
	/// <param name="workspaceId">The workspace id</param>
	/// <param name="reportRequest">The report request</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Post("/reports/api/v3/workspace/{workspace_id}/projects/summary")]
	Task<ICollection<WorkspaceProjectReportItem>> GetWorkspaceProjectSummaryAsync(
		[AliasAs("workspace_id")] long workspaceId,
		[Body] ReportRequest reportRequest,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Returns project's summary.
	/// https://engineering.toggl.com/docs/reports/summary_reports#post-load-project-summary
	/// </summary>
	/// <param name="workspaceId">The workspace id</param>
	/// <param name="projectId">The project id</param>
	/// <param name="reportRequest">The report request</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Post("/reports/api/v3/workspace/{workspace_id}/projects/{project_id}/summary")]
	Task<ProjectSummaryReportItem> GetProjectSummaryAsync(
		[AliasAs("workspace_id")] long workspaceId,
		[AliasAs("project_id")] long projectId,
		[Body] ReportRequest reportRequest,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Returns project's summary.
	/// https://engineering.toggl.com/docs/reports/summary_reports#post-load-project-summary
	/// </summary>
	/// <param name="workspaceId">The workspace id</param>
	/// <param name="reportRequest">The report request</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Post("/reports/api/v3/workspace/{workspace_id}/search/time_entries")]
	Task<ICollection<DetailedReportTimeEntryGroup>> GetDetailsAsync(
		[AliasAs("workspace_id")] long workspaceId,
		[Body] DetailedReportRequest reportRequest,
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
	Task<ICollection<ProjectUser>> GetProjectUsersAsync(
		[AliasAs("workspace_id")] long workspaceId,
		[AliasAs("project_ids")] long? projectIds,
		[AliasAs("with_group_members")] bool? withGroupMembers,
		CancellationToken cancellationToken
		);
}