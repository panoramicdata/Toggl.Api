using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Represents a user's favorite time entry template
/// https://engineering.toggl.com/docs/api/favorites
/// </summary>
public class Favorite : IdentifiedItem
{
	/// <summary>
	/// Whether the favorite is billable
	/// </summary>
	[JsonPropertyName("billable")]
	public bool? Billable { get; set; }

	/// <summary>
	/// Client ID associated with the favorite
	/// </summary>
	[JsonPropertyName("client_id")]
	public long? ClientId { get; set; }

	/// <summary>
	/// Client name (read-only, populated when meta=true)
	/// </summary>
	[JsonPropertyName("client_name")]
	public string? ClientName { get; set; }

	/// <summary>
	/// When was created
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTimeOffset? CreatedAt { get; set; }

	/// <summary>
	/// When was deleted, null if not deleted
	/// </summary>
	[JsonPropertyName("deleted_at")]
	public DateTimeOffset? DeletedAt { get; set; }

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
	/// Project name (read-only, populated when meta=true)
	/// </summary>
	[JsonPropertyName("project_name")]
	public string? ProjectName { get; set; }

	/// <summary>
	/// Project color (read-only, populated when meta=true)
	/// </summary>
	[JsonPropertyName("project_color")]
	public string? ProjectColor { get; set; }

	/// <summary>
	/// Project is active (read-only, populated when meta=true)
	/// </summary>
	[JsonPropertyName("project_active")]
	public bool? ProjectActive { get; set; }

	/// <summary>
	/// Tag IDs associated with the favorite
	/// </summary>
	[JsonPropertyName("tag_ids")]
	public ICollection<long>? TagIds { get; set; }

	/// <summary>
	/// Tag names (read-only, populated when meta=true)
	/// </summary>
	[JsonPropertyName("tags")]
	public ICollection<string>? Tags { get; set; }

	/// <summary>
	/// Task ID associated with the favorite
	/// </summary>
	[JsonPropertyName("task_id")]
	public long? TaskId { get; set; }

	/// <summary>
	/// Task name (read-only, populated when meta=true)
	/// </summary>
	[JsonPropertyName("task_name")]
	public string? TaskName { get; set; }

	/// <summary>
	/// When was last updated
	/// </summary>
	[JsonPropertyName("updated_at")]
	public DateTimeOffset? UpdatedAt { get; set; }

	/// <summary>
	/// User ID who owns this favorite
	/// </summary>
	[JsonPropertyName("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Workspace ID associated with the favorite
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public required long WorkspaceId { get; set; }

	/// <summary>
	/// Workspace name (read-only, populated when meta=true)
	/// </summary>
	[JsonPropertyName("workspace_name")]
	public string? WorkspaceName { get; set; }
}
