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
	/// <param name="timeEntryId">Should the response contain data for meta entities</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/me/time_entries/{time_entry_id}")]
	Task<TimeEntry> GetAsync(
		[AliasAs("time_entry_id")] long timeEntryId,
		CancellationToken cancellationToken
		);
}
