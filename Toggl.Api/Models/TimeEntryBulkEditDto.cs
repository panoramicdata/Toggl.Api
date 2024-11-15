using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A time entry bulk edit DTO.
/// </summary>
public class TimeEntryBulkEditDto
{
	[JsonPropertyName("op")]
	public required string op { get; set; }

	[JsonPropertyName("path")]
	public required string path { get; set; }

	[JsonPropertyName("value")]
	public required object value { get; set; }
}
