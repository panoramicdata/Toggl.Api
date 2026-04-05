using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A most active user entry.
/// </summary>
public class MostActiveUser : Item
{
	/// <summary>
	/// The user ID.
	/// </summary>
	[JsonPropertyName("user_id")]
	public long UserId { get; set; }

	/// <summary>
	/// The duration in seconds.
	/// </summary>
	[JsonPropertyName("duration")]
	public int Duration { get; set; }
}