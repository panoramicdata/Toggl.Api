using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// An organization update DTO.
/// </summary>
public class OrganizationUpdateDto
{
	/// <summary>
	/// The name
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }
}
