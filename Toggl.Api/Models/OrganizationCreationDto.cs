using Newtonsoft.Json;

namespace Toggl.Api.Models;

/// <summary>
/// An organization creation DTO.
/// </summary>
public class OrganizationCreationDto
{
	/// <summary>
	/// The name
	/// </summary>
	[JsonProperty(PropertyName = "name")]
	public required string Name { get; set; }

	/// <summary>
	/// The workspace name
	/// </summary>
	[JsonProperty(PropertyName = "workspace_name")]
	public required string WorkspaceName { get; set; }
}