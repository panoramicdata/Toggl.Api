using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// DTO for creating a time entry
/// https://engineering.toggl.com/docs/api/time_entries#post-timeentries
/// </summary>
public class TimeEntryCreationDto
{
	/// <summary>
	/// Whether the time entry is marked as billable, optional, default false
	/// </summary>
	[JsonPropertyName("billable")]
	public bool? Billable { get; set; }

	/// <summary>
	/// Must be provided when creating a time entry and should identify the service/application used to create it
	/// </summary>
	[JsonPropertyName("created_with")]
	public required string CreatedWith { get; set; }

	/// <summary>
	/// Time entry description, optional
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Time entry duration. For running entries should be negative, preferable -1
	/// </summary>
	[JsonPropertyName("duration")]
	public required long Duration { get; set; }

	/// <summary>
	/// Deprecated: Used to create a TE with a duration but without a stop time
	/// </summary>
	[JsonPropertyName("duronly")]
	public bool? Duronly { get; set; }

	/// <summary>
	/// Project ID, optional
	/// </summary>
	[JsonPropertyName("project_id")]
	public long? ProjectId { get; set; }

	/// <summary>
	/// Start time in UTC, required, RFC3339 format
	/// </summary>
	[JsonPropertyName("start")]
	public required DateTimeOffset Start { get; set; }

	/// <summary>
	/// Stop time in UTC, optional, RFC3339 format
	/// </summary>
	[JsonPropertyName("stop")]
	public DateTimeOffset? Stop { get; set; }

	/// <summary>
	/// IDs of tags to add to the time entry
	/// </summary>
	[JsonPropertyName("tag_ids")]
	public ICollection<long>? TagIds { get; set; }

	/// <summary>
	/// Names of tags to add to the time entry
	/// </summary>
	[JsonPropertyName("tags")]
	public ICollection<string>? Tags { get; set; }

	/// <summary>
	/// Task ID, optional
	/// </summary>
	[JsonPropertyName("task_id")]
	public long? TaskId { get; set; }

	/// <summary>
	/// Time Entry creator ID, if omitted will use the requester user ID
	/// </summary>
	[JsonPropertyName("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Workspace ID, required
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public required long WorkspaceId { get; set; }
}
