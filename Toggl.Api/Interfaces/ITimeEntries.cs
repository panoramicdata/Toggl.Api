using Refit;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;


namespace Toggl.Api.Interfaces;

public interface ITimeEntries
{
	/// <summary>
	/// Lists latest time entries.
	/// https://engineering.toggl.com/docs/api/time_entries#get-timeentries
	/// </summary>
	/// <param name="includeMetaEntityData">Should the response contain data for meta entities</param>
	/// <param name="includeSharingDetails">Include sharing details in the response</param>
	/// <param name="since">Get entries modified since this date using UNIX timestamp, including deleted ones.</param>
	/// <param name="before">Get entries with start time, before given date</param>
	/// <param name="startDate">Get entries with start time, before this value</param>
	/// <param name="endDate">	Get entries with start time, until this value</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/me/time_entries")]
	Task<ICollection<TimeEntry>> GetAsync(
		[AliasAs("meta")] bool includeMetaEntityData,
		[AliasAs("include_sharing")] bool includeSharingDetails,
		[AliasAs("since")] DateTimeOffset? since,
		[AliasAs("before")] DateTimeOffset? before,
		[AliasAs("start_date"), Query(Format = "yyyy-MM-dd'T'HH:mm:ss.fffK")] DateTimeOffset? startDate,
		[AliasAs("end_date"), Query(Format = "yyyy-MM-dd'T'HH:mm:ss.fffK")] DateTimeOffset? endDate,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Load running time entry for user ID.
	/// https://engineering.toggl.com/docs/api/time_entries#get-get-current-time-entry
	/// </summary>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/me/time_entries/current")]
	Task<TimeEntry> GetAsync(
		CancellationToken cancellationToken
		);

    /// <summary>
    /// Load time entry by ID that is accessible by the current user.
    /// https://engineering.toggl.com/docs/api/time_entries#get-get-a-time-entry-by-id
    /// </summary>
    /// <param name="timeEntryId">TimeEntry ID</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns></returns>
    [Get("/api/v9/me/time_entries/{time_entry_id}")]
	Task<TimeEntry> GetAsync(
		[AliasAs("time_entry_id")] long timeEntryId,
		CancellationToken cancellationToken
		);

    /// <summary>
    /// In short: http://tools.ietf.org/html/rfc6902 and http://tools.ietf.org/html/rfc6901 with some additions. Patch will be executed partially when there are errors with some records. No transaction, no rollback.
    /// https://engineering.toggl.com/docs/api/time_entries#patch-bulk-editing-time-entries
    /// </summary>
    /// <param name="workspaceId">Numeric ID of the workspace</param>
    /// <param name="timeEntryIds">Numeric IDs of time_entries, separated by comma. E.g.: 204301830,202700150,202687559. The limit is 100 IDs per request.</param>
    /// <param name="array">Array of batch operations</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns></returns>
    [Patch("/api/v9/workspaces/{workspace_id}/time_entries/{time_entry_ids}")]
    Task PatchAsync(
        [AliasAs("workspace_id")] long workspaceId,
        [AliasAs("time_entry_ids")] string timeEntryIds,
        [Body] ICollection<TimeEntryBulkEditDto> array,
        CancellationToken cancellationToken
        );
}