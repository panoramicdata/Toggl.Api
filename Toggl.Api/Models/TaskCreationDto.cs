using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// DTO for creating a task
/// https://engineering.toggl.com/docs/api/tasks#post-workspaceprojecttasks
/// </summary>
public class TaskCreationDto
{
	/// <summary>
	/// Task name
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// Whether the task is active, optional, default true
	/// </summary>
	[JsonPropertyName("active")]
	public bool? Active { get; set; }

	/// <summary>
	/// Estimated duration in seconds, optional
	/// </summary>
	[JsonPropertyName("estimated_seconds")]
	public long? EstimatedSeconds { get; set; }

	/// <summary>
	/// Project ID
	/// </summary>
	[JsonPropertyName("project_id")]
	public required long ProjectId { get; set; }

	/// <summary>
	/// User ID to assign task to, optional
	/// </summary>
	[JsonPropertyName("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Workspace ID
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public required long WorkspaceId { get; set; }
}
