using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public abstract class NamedIdentifiedItem : IdentifiedItem
{
	/// <summary>
	/// The ID
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }
}