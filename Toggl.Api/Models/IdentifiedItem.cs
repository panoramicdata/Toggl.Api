using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public abstract class IdentifiedItem : Item
{
	/// <summary>
	/// The ID
	/// </summary>
	[JsonPropertyName("id")]
	public long Id { get; set; }
}
