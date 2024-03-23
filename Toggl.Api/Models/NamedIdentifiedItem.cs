using Newtonsoft.Json;

namespace Toggl.Api.Models;

public abstract class NamedIdentifiedItem : IdentifiedItem
{
	/// <summary>
	/// The ID
	/// </summary>
	[JsonProperty(PropertyName = "name")]
	public required string Name { get; set; }
}