using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// DTO for creating or updating a favorite
/// https://engineering.toggl.com/docs/api/favorites
/// </summary>
public class FavoriteDto
{
	/// <summary>
	/// Whether the favorite is billable
	/// </summary>
	[JsonPropertyName("billable")]
	public bool? Billable { get; set; }

	/// <summary>
	/// Description of the favorite
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Project ID associated with the favorite
	/// </summary>
	[JsonPropertyName("project_id")]
	public long? ProjectId { get; set; }

	/// <summary>
	/// Tag IDs associated with the favorite
	/// </summary>
	[JsonPropertyName("tag_ids")]
	public ICollection<long>? TagIds { get; set; }

	/// <summary>
	/// Task ID associated with the favorite
	/// </summary>
	[JsonPropertyName("task_id")]
	public long? TaskId { get; set; }

	/// <summary>
	/// Workspace ID associated with the favorite (required)
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public required long WorkspaceId { get; set; }
}
