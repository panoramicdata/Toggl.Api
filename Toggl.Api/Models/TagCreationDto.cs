using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// DTO for creating a tag
/// https://engineering.toggl.com/docs/api/tags#post-create-tag
/// </summary>
public class TagCreationDto
{
	/// <summary>
	/// Tag name
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// Workspace ID
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public required long WorkspaceId { get; set; }
}
