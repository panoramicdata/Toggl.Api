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

	/// <summary>
	/// Returns a list of track reminders.
	/// https://engineering.toggl.com/docs/api/me#get-trackreminders
	/// </summary>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/me/track_reminders")]
	Task<ICollection<TrackReminder>> GetTrackRemindersAsync(
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Returns the timesheets for the current user.
	/// https://engineering.toggl.com/docs/api/me#get-timesheets
	/// </summary>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/me/timesheets")]
	Task<ICollection<Timesheet>> GetTimesheetsAsync(
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Resets API token for the current user.
	/// https://engineering.toggl.com/docs/api/authentication#post-reset-token
	/// </summary>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The new API token</returns>
	[Post("/api/v9/me/reset_token")]
	Task<string> ResetTokenAsync(
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Accepts the last version of the Terms of Service for the current user.
	/// https://engineering.toggl.com/docs/api/me#post-accept-tos
	/// </summary>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Post("/api/v9/me/accept_tos")]
	Task AcceptTosAsync(
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Returns the local Track user ID for the authenticated user.
	/// https://engineering.toggl.com/docs/api/me#get-me-id
	/// </summary>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The user ID</returns>
	[Get("/api/v9/me/id")]
	Task<long> GetIdAsync(
		CancellationToken cancellationToken
		);

	#region Favorites

	/// <summary>
	/// Gets all favorites for the requesting user.
	/// https://engineering.toggl.com/docs/api/favorites#get-favorites
	/// </summary>
	/// <param name="sinceUnixTimestampSeconds">Retrieve favorites created/deleted since this date using UNIX timestamp.</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>List of favorites</returns>
	[Get("/api/v9/me/favorites")]
	Task<ICollection<Favorite>> GetFavoritesAsync(
		[AliasAs("since")] long? sinceUnixTimestampSeconds,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Creates a new favorite.
	/// https://engineering.toggl.com/docs/api/favorites#post-favorites
	/// </summary>
	/// <param name="includeMeta">Should the response contain data for meta entities</param>
	/// <param name="favorite">Favorite details</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The created favorite</returns>
	[Post("/api/v9/me/favorites")]
	Task<Favorite> CreateFavoriteAsync(
		[AliasAs("meta")] bool? includeMeta,
		[Body] FavoriteDto favorite,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Updates an array of favorites.
	/// https://engineering.toggl.com/docs/api/favorites#put-favorites
	/// </summary>
	/// <param name="includeMeta">Should the response contain data for meta entities</param>
	/// <param name="favorites">Favorite details to update</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The updated favorites</returns>
	[Put("/api/v9/me/favorites")]
	Task<ICollection<Favorite>> UpdateFavoritesAsync(
		[AliasAs("meta")] bool? includeMeta,
		[Body] ICollection<FavoriteDto> favorites,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Deletes a favorite.
	/// https://engineering.toggl.com/docs/api/favorites#delete-favorites
	/// </summary>
	/// <param name="favoriteId">Numerical ID of the favorite</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Delete("/api/v9/me/favorites/{favorite_id}")]
	Task DeleteFavoriteAsync(
		[AliasAs("favorite_id")] long favoriteId,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Generates and returns a list of suggested favorites.
	/// https://engineering.toggl.com/docs/api/favorites#post-favorites-suggestions
	/// </summary>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>List of suggested favorites</returns>
	[Post("/api/v9/me/favorites/suggestions")]
	Task<ICollection<Favorite>> GetFavoritesSuggestionsAsync(
		CancellationToken cancellationToken
		);

	#endregion

	#region Flags

	/// <summary>
	/// Returns flags for the current user.
	/// https://engineering.toggl.com/docs/api/me#get-me-flags
	/// </summary>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>User flags as key-value pairs</returns>
	[Get("/api/v9/me/flags")]
	Task<UserFlags> GetFlagsAsync(
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Add flags for the current user.
	/// https://engineering.toggl.com/docs/api/me#post-me-flags
	/// </summary>
	/// <param name="flags">Flags to add</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>Updated user flags</returns>
	[Post("/api/v9/me/flags")]
	Task<UserFlags> PostFlagsAsync(
		[Body] UserFlags flags,
		CancellationToken cancellationToken
		);

	#endregion

	#region Preferences

	/// <summary>
	/// Returns user preferences and alpha features.
	/// https://engineering.toggl.com/docs/api/preferences#get-preferences
	/// </summary>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>User preferences</returns>
	[Get("/api/v9/me/preferences")]
	Task<UserPreferences> GetPreferencesAsync(
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Update the preferences for the current user.
	/// https://engineering.toggl.com/docs/api/preferences#post-preferences
	/// </summary>
	/// <param name="preferences">Preferences to update</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Post("/api/v9/me/preferences")]
	Task PostPreferencesAsync(
		[Body] UserPreferences preferences,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Returns user preferences for a specific client.
	/// https://engineering.toggl.com/docs/api/preferences#get-preferences-client
	/// </summary>
	/// <param name="client">Client type (desktop, web)</param>
	/// <param name="sinceUnixTimestampSeconds">Retrieve preference modified since this date using UNIX timestamp.</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>User preferences for the client</returns>
	[Get("/api/v9/me/preferences/{client}")]
	Task<UserPreferences> GetPreferencesAsync(
		string client,
		[AliasAs("since")] long? sinceUnixTimestampSeconds,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Update the preferences for a specific client.
	/// https://engineering.toggl.com/docs/api/preferences#post-preferences-client
	/// </summary>
	/// <param name="client">Client type (desktop, web)</param>
	/// <param name="preferences">Preferences to update</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Post("/api/v9/me/preferences/{client}")]
	Task PostPreferencesAsync(
		string client,
		[Body] UserPreferences preferences,
		CancellationToken cancellationToken
		);

	#endregion

	#region Export

	/// <summary>
	/// Get a list of objects to be downloaded for a user.
	/// https://engineering.toggl.com/docs/api/exports#get-me-export
	/// </summary>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>List of download request records</returns>
	[Get("/api/v9/me/export")]
	Task<ICollection<DownloadRequestRecord>> GetExportsAsync(
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Post an object which data to be downloaded.
	/// https://engineering.toggl.com/docs/api/exports#post-me-export
	/// </summary>
	/// <param name="exportPayload">Objects to export</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Post("/api/v9/me/export")]
	Task PostExportAsync(
		[Body] ExportPayload exportPayload,
		CancellationToken cancellationToken
		);

	#endregion

	#region Quota

	/// <summary>
	/// Returns the API quota for the current user for all the organizations they are part of.
	/// https://engineering.toggl.com/docs/api/me#get-quota
	/// </summary>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>List of quota information per organization</returns>
	[Get("/api/v9/me/quota")]
	Task<ICollection<Quota>> GetQuotaAsync(
		CancellationToken cancellationToken
		);

	#endregion

	#region Account Management

	/// <summary>
	/// Close the current user's account.
	/// https://engineering.toggl.com/docs/api/me#post-close-account
	/// </summary>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Post("/api/v9/me/close_account")]
	Task CloseAccountAsync(
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Disable product emails using a disable code.
	/// https://engineering.toggl.com/docs/api/me#post-me-disable-product-emails
	/// </summary>
	/// <param name="disableCode">Disable code</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Post("/api/v9/me/disable_product_emails/{disable_code}")]
	Task DisableProductEmailsAsync(
		[AliasAs("disable_code")] string disableCode,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Disable weekly report using a weekly report code.
	/// https://engineering.toggl.com/docs/api/me#post-me-disable-weekly-report
	/// </summary>
	/// <param name="weeklyReportCode">Weekly report code</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Post("/api/v9/me/disable_weekly_report/{weekly_report_code}")]
	Task DisableWeeklyReportAsync(
		[AliasAs("weekly_report_code")] string weeklyReportCode,
		CancellationToken cancellationToken
		);

	#endregion

	#region Push Services

	/// <summary>
	/// Get list of firebase tokens registered for current user.
	/// https://engineering.toggl.com/docs/api/me#get-push-services
	/// </summary>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>List of firebase tokens</returns>
	[Get("/api/v9/me/push_services")]
	Task<ICollection<string>> GetPushServicesAsync(
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Register Firebase token for current user.
	/// https://engineering.toggl.com/docs/api/me#post-push-services
	/// </summary>
	/// <param name="token">Firebase token</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Post("/api/v9/me/push_services")]
	Task PostPushServiceAsync(
		[Body] PushServiceToken token,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Unregister Firebase token for current user.
	/// https://engineering.toggl.com/docs/api/me#delete-push-services
	/// </summary>
	/// <param name="token">Firebase token</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Delete("/api/v9/me/push_services")]
	Task DeletePushServiceAsync(
		[Body] PushServiceToken token,
		CancellationToken cancellationToken
		);

	#endregion
}