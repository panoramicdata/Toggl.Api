using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A report time entry.
/// </summary>
public class ReportTimeEntry : IdentifiedItem
{
	/// <summary>
	/// The project ID.
	/// </summary>
	[JsonPropertyName("pid")]
	public long? ProjectId { get; set; }

	/// <summary>
	/// The project name.
	/// </summary>
	[JsonPropertyName("project")]
	public string? ProjectName { get; set; }

	/// <summary>
	/// The client name.
	/// </summary>
	[JsonPropertyName("client")]
	public string? ClientName { get; set; }

	/// <summary>
	/// The task ID.
	/// </summary>
	[JsonPropertyName("tid")]
	public long? TaskId { get; set; }

	/// <summary>
	/// The task name.
	/// </summary>
	[JsonPropertyName("task")]
	public string? TaskName { get; set; }

	/// <summary>
	/// The user ID.
	/// </summary>
	[JsonPropertyName("uid")]
	public long? UserId { get; set; }

	/// <summary>
	/// The user name.
	/// </summary>
	[JsonPropertyName("user")]
	public string? UserName { get; set; }

	/// <summary>
	/// The description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// The start time.
	/// </summary>
	[JsonPropertyName("start")]
	public string? Start { get; set; }

	/// <summary>
	/// The stop time.
	/// </summary>
	[JsonPropertyName("end")]
	public string? Stop { get; set; }

	/// <summary>
	/// The duration in milliseconds.
	/// </summary>
	[JsonPropertyName("dur")]
	public long? Duration { get; set; }

	/// <summary>
	/// The last updated time.
	/// </summary>
	[JsonPropertyName("updated")]
	public string? Updated { get; set; }

	/// <summary>
	/// Whether to use stop time.
	/// </summary>
	[JsonPropertyName("use_stop")]
	public bool? UseStop { get; set; }

	/// <summary>
	/// Whether the entry is billable.
	/// </summary>
	[JsonPropertyName("is_billable")]
	public bool? IsBillable { get; set; }

	/// <summary>
	/// The billable amount.
	/// </summary>
	[JsonPropertyName("billable")]
	public long? Billable { get; set; }

	/// <summary>
	/// The tag names.
	/// </summary>
	[JsonPropertyName("tags")]
	public List<string>? TagNames { get; set; }

	/// <inheritdoc />
	public override string ToString() => string.Format(CultureInfo.InvariantCulture, "Id: {0}, Start: {1}, Stop: {2}, TaskId: {3}", Id, Start, Stop, TaskId);
}