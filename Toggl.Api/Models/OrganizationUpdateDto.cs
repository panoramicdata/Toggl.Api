using Newtonsoft.Json;

namespace Toggl.Api.Models;

/// <summary>
/// An organization update DTO.
/// </summary>
public class OrganizationUpdateDto
{
	/// <summary>
	/// The name
	/// </summary>
	[JsonProperty(PropertyName = "name")]
	public required string Name { get; set; }
}
