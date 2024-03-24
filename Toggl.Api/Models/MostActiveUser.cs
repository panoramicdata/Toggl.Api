using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public class MostActiveUser : Item
{
	[JsonPropertyName("user_id")]
	public long UserId { get; set; }

	[JsonPropertyName("duration")]
	public int Duration { get; set; }
}