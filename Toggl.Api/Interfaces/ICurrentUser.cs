using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;


namespace Toggl.Api.Interfaces;

/// <summary>
/// https://engineering.toggl.com/docs/api/me
/// </summary>
public interface ICurrentUser
{
	/// <summary>
	/// Returns details for the current user.
	/// https://engineering.toggl.com/docs/api/me#get-me
	/// </summary>
	/// <param name="withRelatedData">Retrieve user related data (clients, projects, tasks, tags, workspaces, time entries, etc.)</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/me")]
	Task<CurrentUser> GetAsync(
		[AliasAs("with_related_data")] bool withRelatedData,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Updates details for the current user.
	/// https://engineering.toggl.com/docs/api/me#put-me
	/// </summary>
	/// <param name="meUpdateDto">Update information</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Put("/api/v9/me")]
	Task<CurrentUser> UpdateAsync(
		[Body] MeUpdateDto meUpdateDto,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Get Clients.
	/// https://engineering.toggl.com/docs/api/me#get-clients
	/// </summary>
	/// <param name="sinceUnixTimestampSeconds">Retrieve clients created/modified/deleted since this date using UNIX timestamp.</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/me/clients")]
	Task<ICollection<CurrentUserClient>> GetClientsAsync(
		[AliasAs("since")] long? sinceUnixTimestampSeconds,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Get features.
	/// https://engineering.toggl.com/docs/api/me#get-features
	/// </summary>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/me/features")]
	Task<ICollection<WorkspaceFeature>> GetFeaturesAsync(
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Returns the client's IP-based location. If no data is present, empty response will be yielded.
	/// https://engineering.toggl.com/docs/api/me#get-users-last-known-location
	/// </summary>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/me/location")]
	Task<Location?> GetLastKnownLocationAsync(
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Used to check if authentication works.
	/// https://engineering.toggl.com/docs/api/me#get-logged
	/// </summary>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/me/logged")]
	Task GetLoggedAsync(
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Get all organizations a given user is part of.
	/// https://engineering.toggl.com/docs/api/me#get-organizations-that-a-user-is-part-of
	/// </summary>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/me/organizations")]
	Task<ICollection<Organization>> GetOrganizationsAsync(
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Get projects
	/// https://engineering.toggl.com/docs/api/me#get-projects
	/// </summary>
	/// <param name="includeArchived">Include archived projects.</param>
	/// <param name="since">Retrieve projects modified since this date using UNIX timestamp, including deleted ones.</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/me/projects")]
	Task<ICollection<Project>> GetProjectsAsync(
		[AliasAs("include_archived")] bool includeArchived,
		[AliasAs("since")] long? sinceUnixTimestampSeconds,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Get paginated projects.
	/// https://engineering.toggl.com/docs/api/me#get-projectspaginated
	/// </summary>
	/// <param name="startProjectId">Project ID to resume the next pagination from.</param>
	/// <param name="sinceUnixTimestampSeconds">Retrieve projects created/modified/deleted since this date using UNIX timestamp.</param>
	/// <param name="perPage">Number of items per page, default 201.</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/me/projects/paginated")]
	Task<ICollection<Project>> GetProjectsPaginatedAsync(
		[AliasAs("since")] long? sinceUnixTimestampSeconds,
		[AliasAs("start_project_id")] int? startProjectId,
		[AliasAs("per_page")] int? perPage,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Returns tags for the current user.
	/// https://engineering.toggl.com/docs/api/me#get-tags
	/// </summary>
	/// <param name="sinceUnixTimestampSeconds">Retrieve projects created/modified/deleted since this date using UNIX timestamp.</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/me/tags")]
	Task<ICollection<Tag>> GetTagsAsync(
		[AliasAs("since")] long? sinceUnixTimestampSeconds,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Returns tasks from projects in which the user is participating.
	/// https://engineering.toggl.com/docs/api/me#get-tasks
	/// </summary>
	/// <param name="sinceUnixTimestampSeconds">Retrieve projects created/modified/deleted since this date using UNIX timestamp.</param>
	/// <param name="includeInactive">	Include tasks marked as done.</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/me/tasks")]
	Task<ICollection<Models.ProjectTask>> GetTasksAsync(
		[AliasAs("since")] long? sinceUnixTimestampSeconds,
		[AliasAs("include_not_active")] bool includeInactive,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Get web timer.
	/// https://engineering.toggl.com/docs/api/me#get-webtimer
	/// </summary>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/me/web-timer")]
	Task GetWebTimerAsync(
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Lists workspaces for given user.
	/// https://engineering.toggl.com/docs/api/me#get-workspaces
	/// </summary>
	/// <param name="sinceUnixTimestampSeconds">Retrieve projects created/modified/deleted since this date using UNIX timestamp.</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/me/workspaces")]
	Task<ICollection<Workspace>> GetWorkspacesAsync(
		[AliasAs("since")] long? sinceUnixTimestampSeconds,
		CancellationToken cancellationToken
		);
}