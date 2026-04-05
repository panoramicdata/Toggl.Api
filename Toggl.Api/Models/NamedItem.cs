using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A named item.
/// </summary>
public abstract class NamedItem : Item
{
	/// <summary>
	/// The name
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }
}
