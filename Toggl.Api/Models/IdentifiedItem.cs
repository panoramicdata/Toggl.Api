using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// An identified item with an ID.
/// </summary>
public abstract class IdentifiedItem : Item
{
	/// <summary>
	/// The ID
	/// </summary>
	[JsonPropertyName("id")]
	public long Id { get; set; }
}
