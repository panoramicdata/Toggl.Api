using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A new blog post.
/// </summary>
public class NewBlogPost : Item
{
	/// <summary>
	/// The title.
	/// </summary>
	[JsonPropertyName("title")]
	public string? Title { get; set; }

	/// <summary>
	/// The URL.
	/// </summary>
	[JsonPropertyName("url")]
	public string? Url { get; set; }

	/// <summary>
	/// The category.
	/// </summary>
	[JsonPropertyName("category")]
	public string? Category { get; set; }

	/// <summary>
	/// The publication date.
	/// </summary>
	[JsonPropertyName("pub_date")]
	public string? PubDate { get; set; }
}