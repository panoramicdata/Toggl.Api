using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// DTO for updating a group
/// https://engineering.toggl.com/docs/api/groups#put-update-group
/// </summary>
public class GroupUpdateDto
{
	/// <summary>
	/// Group name
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// User IDs in the group
	/// </summary>
	[JsonPropertyName("users")]
	public ICollection<long>? UserIds { get; set; }

	/// <summary>
	/// Workspace IDs to assign the group to
	/// </summary>
	[JsonPropertyName("workspaces")]
	public ICollection<long>? WorkspaceIds { get; set; }
}
