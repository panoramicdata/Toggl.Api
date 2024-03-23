using Newtonsoft.Json;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/me#get-me
/// </summary>
public class MeOptions
{
	/// <summary>
	/// Additional properties
	/// </summary>
	[JsonProperty(PropertyName = "additionalProperties")]
	public required object AdditionalProperties { get; set; }
}
