using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public class Activity : Item
{
	[JsonPropertyName("user_id")]
	public long UserId { get; set; }

	[JsonPropertyName("project_id")]
	public long ProjectId { get; set; }

	[JsonPropertyName("duration")]
	public int Duration { get; set; }

	[JsonPropertyName("description")]
	public string? Description { get; set; }

	[JsonPropertyName("stop")]
	public DateTimeOffset Stop { get; set; }
}
