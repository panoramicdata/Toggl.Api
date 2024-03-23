using Newtonsoft.Json;

namespace Toggl.Api.Models;

public abstract class IdentifiedItem : Item
{
	/// <summary>
	/// The ID
	/// </summary>
	[JsonProperty(PropertyName = "id")]
	public long Id { get; set; }
}
