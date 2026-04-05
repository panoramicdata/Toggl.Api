using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A dashboard.
/// </summary>
public class Dashboard : Item
{
	/// <summary>
	/// The most active users.
	/// </summary>
	[JsonPropertyName("most_active_user")]
	public MostActiveUser[] MostActiveUser { get; set; } = [];

	/// <summary>
	/// The activity entries.
	/// </summary>
	[JsonPropertyName("activity")]
	public Activity[] Activity { get; set; } = [];
}