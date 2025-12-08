using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Project statistics
/// https://engineering.toggl.com/docs/api/projects
/// </summary>
public class ProjectStatistics
{
	/// <summary>
	/// Billable amount in cents
	/// </summary>
	[JsonPropertyName("billable_amount_in_cents")]
	public long? BillableAmountInCents { get; set; }

	/// <summary>
	/// Billable seconds
	/// </summary>
	[JsonPropertyName("billable_seconds")]
	public long? BillableSeconds { get; set; }

	/// <summary>
	/// Earliest time entry start date
	/// </summary>
	[JsonPropertyName("earliest_time_entry_date")]
	public string? EarliestTimeEntryDate { get; set; }

	/// <summary>
	/// Labour cost in cents
	/// </summary>
	[JsonPropertyName("labour_cost_in_cents")]
	public long? LabourCostInCents { get; set; }

	/// <summary>
	/// Latest time entry date
	/// </summary>
	[JsonPropertyName("latest_time_entry_date")]
	public string? LatestTimeEntryDate { get; set; }

	/// <summary>
	/// Number of tasks
	/// </summary>
	[JsonPropertyName("tasks_count")]
	public int? TasksCount { get; set; }

	/// <summary>
	/// Total seconds tracked
	/// </summary>
	[JsonPropertyName("tracked_seconds")]
	public long? TrackedSeconds { get; set; }
}
