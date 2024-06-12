using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/tasks.md#tasks
/// </summary>
public class ProjectTask : NamedIdentifiedItem
{
	/// <summary>
	/// Whether the task is active
	/// </summary>
	[JsonPropertyName("active")]
	public required bool IsActive { get; set; }

	/// <summary>
	/// When the task was created/last modified
	/// </summary>
	[JsonPropertyName("at")]
	public required DateTimeOffset LastModified { get; set; }

	/// <summary>
	/// Estimation time for this task in seconds
	/// </summary>
	[JsonPropertyName("estimated_seconds")]
	public required int? EstimatedSeconds { get; set; }

	/// <summary>
	/// Permissions
	/// </summary>
	[JsonPropertyName("permissions")]
	public required string Permissions { get; set; }

	/// <summary>
	/// Project id
	/// </summary>
	[JsonPropertyName("project_id")]
	public required int ProjectId { get; set; }

	/// <summary>
	/// Whether this is a recurring task
	/// </summary>
	[JsonPropertyName("recurring")]
	public required bool IsRecurring { get; set; }

	/// <summary>
	/// When the task was deleted (or null if not deleted)
	/// </summary>
	[JsonPropertyName("server_deleted_at")]
	public required DateTimeOffset? ServerDeletedAt { get; set; }

	/// <summary>
	/// Task assignee, if set above this will be the toggl_account_id for that user
	/// </summary>
	[JsonPropertyName("toggl_accounts_id")]
	public string? TogglAccountsId { get; set; }

	/// <summary>
	/// The value tracked_seconds is in milliseconds, not in seconds.
	/// </summary>
	[JsonPropertyName("tracked_seconds")]
	public required long? TrackedMilliseconds { get; set; }

	/// <summary>
	/// When the task was deleted (or null if not deleted)
	/// </summary>
	[JsonPropertyName("user_id")]
	public required int? UserId { get; set; }

	/// <summary>
	/// Workspace ID
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public required long? WorkspaceId { get; set; }
}