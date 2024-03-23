using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;

namespace Toggl.Api.Interfaces;

public interface ITimeEntries
{
	/// <summary>
	/// List recent time entry services
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md#get-time-entries-started-in-a-specific-time-range
	/// </summary>
	/// <returns></returns>
	Task<List<TimeEntry>> ListRecent(CancellationToken cancellationToken);

	/// <summary>
	/// List time entry services
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md#get-time-entries-started-in-a-specific-time-range
	/// </summary>
	/// <returns></returns>
	Task<List<TimeEntry>> GetAllAsync(CancellationToken cancellationToken);

	/// <summary>
	/// List time entries
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md#get-time-entries-started-in-a-specific-time-range
	/// </summary>
	/// <param name="obj"></param>
	/// <returns></returns>
	Task<List<TimeEntry>> GetAllAsync(QueryObjects.TimeEntryParams obj, CancellationToken cancellationToken);

	/// <summary>
	/// Get the current time entry
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md#get-running-time-entry
	/// </summary>
	/// <returns></returns>
	Task<TimeEntry> GetCurrentAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Get a time entry
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md#get-time-entry-details
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	Task<TimeEntry> GetAsync(long id, CancellationToken cancellationToken);

	/// <summary>
	/// Add a time entry
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md#create-a-time-entry
	/// </summary>
	/// <param name="obj"></param>
	/// <returns></returns>
	Task<TimeEntry> CreateAsync(TimeEntry obj, CancellationToken cancellationToken);

	/// <summary>
	/// Start a TimeEntry
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md#start-a-time-entry
	/// </summary>
	/// <param name="obj">A TimeEntry object.</param>
	/// <returns>The runnig TimeEntry.</returns>
	Task<TimeEntry> StartAsync(TimeEntry obj, CancellationToken cancellationToken);

	/// <summary>
	/// Stop a TimeEntry
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md#stop-a-time-entry
	/// </summary>
	/// <param name="obj">A TimeEntry object.</param>
	/// <returns>The stopped TimeEntry.</returns>
	Task<TimeEntry> StopAsync(TimeEntry obj, CancellationToken cancellationToken);

	/// <summary>
	/// Edit a time entry
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md#update-a-time-entry
	/// </summary>
	/// <param name="obj"></param>
	/// <returns></returns>
	Task<TimeEntry> UpdateAsync(TimeEntry obj, CancellationToken cancellationToken);

	/// <summary>
	/// Delete a time entry
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/time_entries.md#delete-a-time-entry
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	Task<bool> DeleteAsync(long id, CancellationToken cancellationToken);
}