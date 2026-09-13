using System;
using System.Collections.Generic;
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
	public bool? IsActive { get; set; }

	/// <summary>
	/// When the task was created/last modified
	/// </summary>
	[JsonPropertyName("at")]
	public DateTimeOffset? LastModified { get; set; }

	/// <summary>
	/// Estimation time for this task in seconds
	/// </summary>
	[JsonPropertyName("estimated_seconds")]
	public int? EstimatedSeconds { get; set; }

	/// <summary>
	/// Permissions.  Toggl documents this as an array of strings, and omits it entirely
	/// from most responses.
	/// </summary>
	[JsonPropertyName("permissions")]
	public ICollection<string>? Permissions { get; set; }

	/// <summary>
	/// Project id
	/// </summary>
	[JsonPropertyName("project_id")]
	public int? ProjectId { get; set; }

	/// <summary>
	/// Whether the parent project is private.
	/// </summary>
	[JsonPropertyName("project_is_private")]
	public bool? ProjectIsPrivate { get; set; }

	/// <summary>
	/// Whether this is a recurring task
	/// </summary>
	[JsonPropertyName("recurring")]
	public bool? IsRecurring { get; set; }

	/// <summary>
	/// When the task was deleted (or null if not deleted)
	/// </summary>
	[JsonPropertyName("server_deleted_at")]
	public DateTimeOffset? ServerDeletedAt { get; set; }

	/// <summary>
	/// Task assignee, if set above this will be the toggl_account_id for that user
	/// </summary>
	[JsonPropertyName("toggl_accounts_id")]
	public string? TogglAccountsId { get; set; }

	/// <summary>
	/// The value tracked_seconds is in milliseconds, not in seconds.
	/// </summary>
	[JsonPropertyName("tracked_seconds")]
	public long? TrackedMilliseconds { get; set; }

	/// <summary>
	/// When the task was deleted (or null if not deleted)
	/// </summary>
	[JsonPropertyName("user_id")]
	public int? UserId { get; set; }

	/// <summary>
	/// Workspace ID
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public long? WorkspaceId { get; set; }
}