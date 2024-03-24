using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public class Dashboard : Item
{
	[JsonPropertyName("most_active_user")]
	public MostActiveUser[] MostActiveUser { get; set; } = [];

	[JsonPropertyName("activity")]
	public Activity[] Activity { get; set; } = [];
}