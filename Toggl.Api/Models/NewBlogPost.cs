using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public class NewBlogPost : Item
{
	[JsonPropertyName("title")]
	public string? Title { get; set; }

	[JsonPropertyName("url")]
	public string? Url { get; set; }

	[JsonPropertyName("category")]
	public string? Category { get; set; }

	[JsonPropertyName("pub_date")]
	public string? PubDate { get; set; }
}