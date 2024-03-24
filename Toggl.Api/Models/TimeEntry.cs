using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Globalization;

namespace Toggl.Api.Models;

public class TimeEntry : IdentifiedItem
{
	/// <summary>
	/// The workspace ID
	/// </summary>
	[JsonPropertyName("wid")]
	public long? WorkspaceId { get; set; }

	/// <summary>
	/// The Project ID
	/// </summary>
	[JsonPropertyName("pid")]
	public long? ProjectId { get; set; }

	/// <summary>
	/// The Task ID
	/// </summary>
	[JsonPropertyName("tid")]
	public long? TaskId { get; set; }

	/// <summary>
	/// Whether this item is billable
	/// </summary>
	[JsonPropertyName("billable")]
	public bool? IsBillable { get; set; }

	/// <summary>
	/// The Start time
	/// </summary>
	[JsonPropertyName("start")]
	public string? Start { get; set; }

	/// <summary>
	/// The Stop time
	/// </summary>
	[JsonPropertyName("stop")]
	public string? Stop { get; set; }

	/// <summary>
	/// The duration in seconds
	/// </summary>
	[JsonPropertyName("duration")]
	public long? Duration { get; set; }

	/// <summary>
	/// The Description
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// The tags
	/// </summary>
	[JsonPropertyName("tags")]
	public List<string>? TagNames { get; set; }

	/// <summary>
	/// When it was last updated
	/// </summary>
	[JsonPropertyName("at")]
	public string? UpdatedOn { get; set; }

	/// <summary>
	/// When it was created
	/// </summary>
	[JsonPropertyName("created_at")]
	public string? CreatedOn { get; set; }

	[JsonPropertyName("task")]
	public string? TaskName { get; set; }

	[JsonPropertyName("created_with")]
	public string? CreatedWith { get; set; }

	[JsonPropertyName("duronly")]
	public bool? ShowDurationOnly { get; set; }

	public override string ToString() => string.Format(CultureInfo.InvariantCulture, "Id: {0}, Start: {1}, Stop: {2}, TaskId: {3}", Id, Start, Stop, TaskId);
}