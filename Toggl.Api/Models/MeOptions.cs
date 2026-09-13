using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/me#get-me
/// </summary>
public class MeOptions
{
	/// <summary>
	/// Additional properties
	/// </summary>
	[JsonPropertyName("additionalProperties")]
	public object? AdditionalProperties { get; set; }
}
