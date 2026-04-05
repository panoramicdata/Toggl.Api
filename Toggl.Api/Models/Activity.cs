using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// An activity entry.
/// </summary>
public class Activity : Item
{
	/// <summary>
	/// The user ID.
	/// </summary>
	[JsonPropertyName("user_id")]
	public long UserId { get; set; }

	/// <summary>
	/// The project ID.
	/// </summary>
	[JsonPropertyName("project_id")]
	public long ProjectId { get; set; }

	/// <summary>
	/// The duration in seconds.
	/// </summary>
	[JsonPropertyName("duration")]
	public int Duration { get; set; }

	/// <summary>
	/// The description.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// The stop time.
	/// </summary>
	[JsonPropertyName("stop")]
	public DateTimeOffset Stop { get; set; }
}
