using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A time entry bulk edit DTO.
/// </summary>
public class TimeEntryBulkEditDto
{
	/// <summary>
	/// The operation.
	/// </summary>
	[JsonPropertyName("op")]
	public required string op { get; set; }

	/// <summary>
	/// The path.
	/// </summary>
	[JsonPropertyName("path")]
	public required string path { get; set; }

	/// <summary>
	/// The value.
	/// </summary>
	[JsonPropertyName("value")]
	public required object value { get; set; }
}
