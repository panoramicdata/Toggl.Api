using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A named identified item.
/// </summary>
public abstract class NamedIdentifiedItem : IdentifiedItem
{
	/// <summary>
	/// The ID
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }
}