using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A Time entry group
/// </summary>
public class DetailedReportTimeEntryGroup
{
	/// <summary>
	/// The User ID
	/// </summary>
	[JsonPropertyName("user_id")]
	public int UserId { get; set; }

	/// <summary>
	/// The username
	/// </summary>
	[JsonPropertyName("username")]
	public required string Username { get; set; }

	/// <summary>
	/// The project id
	/// </summary>
	[JsonPropertyName("project_id")]
	public int? ProjectId { get; set; }

	/// <summary>
	/// The task id, if set
	/// </summary>
	[JsonPropertyName("task_id")]
	public int? TaskId { get; set; }

	/// <summary>
	/// Whether the time is billable
	/// </summary>
	[JsonPropertyName("billable")]
	public required bool IsBillable { get; set; }

	/// <summary>
	/// The description
	/// </summary>
	[JsonPropertyName("description")]
	public required string Description { get; set; }

	/// <summary>
	/// The tag ids
	/// </summary>
	[JsonPropertyName("tag_ids")]
	public required ICollection<int> TagIds { get; set; }

	/// <summary>
	/// The billable amount in cents
	/// </summary>
	[JsonPropertyName("billable_amount_in_cents")]
	public int? BillableAmountInCents { get; set; }

	/// <summary>
	/// The hourly rate in cents
	/// </summary>
	[JsonPropertyName("hourly_rate_in_cents")]
	public int? HourlyRateInCents { get; set; }

	/// <summary>
	/// The currency
	/// </summary>
	[JsonPropertyName("currency")]
	public required string Currency { get; set; }

	/// <summary>
	/// The time entries
	/// </summary>
	[JsonPropertyName("time_entries")]
	public required ICollection<DetailedReportTimeEntry> TimeEntries { get; set; }

	/// <summary>
	/// The row number
	/// </summary>
	[JsonPropertyName("row_number")]
	public required int RowNumber { get; set; }
}
