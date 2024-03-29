using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A time entry
/// </summary>
public class TimeEntry : IdentifiedItem
{
	/// <summary>
	/// The Project ID
	/// </summary>
	[JsonPropertyName("project_id")]
	public required long? ProjectId { get; set; }

	/// <summary>
	/// The Task ID
	/// </summary>
	[JsonPropertyName("task_id")]
	public long? TaskId { get; set; }

	/// <summary>
	/// Whether this item is billable
	/// </summary>
	[JsonPropertyName("billable")]
	public required bool IsBillable { get; set; }

	/// <summary>
	/// The Start time
	/// </summary>
	[JsonPropertyName("start")]
	public required string Start { get; set; }

	/// <summary>
	/// The Stop time
	/// </summary>
	[JsonPropertyName("stop")]
	public required string Stop { get; set; }

	/// <summary>
	/// The duration in seconds
	/// </summary>
	[JsonPropertyName("duration")]
	public required long DurationSeconds { get; set; }

	/// <summary>
	/// The Description
	/// </summary>
	[JsonPropertyName("description")]
	public required string Description { get; set; }

	/// <summary>
	/// The tags
	/// </summary>
	[JsonPropertyName("tags")]
	public required ICollection<string> TagNames { get; set; }

	/// <summary>
	/// The tag ids
	/// </summary>
	[JsonPropertyName("tag_ids")]
	public required ICollection<int> TagIds { get; set; }

	/// <summary>
	/// When it was last updated
	/// </summary>
	[JsonPropertyName("at")]
	public required DateTimeOffset? LastModified { get; set; }

	/// <summary>
	/// When it was deleted (or null if not deleted)
	/// </summary>
	[JsonPropertyName("server_deleted_at")]
	public required DateTimeOffset? DeletedAt { get; set; }

	/// <summary>
	/// Whether to show the duration only
	/// </summary>
	[JsonPropertyName("duronly")]
	public required bool ShowDurationOnly { get; set; }

	/// <summary>
	/// The workspace ID
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public required long WorkspaceId { get; set; }

	/// <summary>
	/// The workspace ID (again, for some reason)
	/// </summary>
	[JsonPropertyName("wid")]
	public required long WorkspaceId2 { get; set; }

	/// <summary>
	/// The user ID
	/// </summary>
	[JsonPropertyName("user_id")]
	public required long UserId { get; set; }

	/// <summary>
	/// The user ID (again, for some reason)
	/// </summary>
	[JsonPropertyName("uid")]
	public required long UserId2 { get; set; }

	public override string ToString() => string.Format(CultureInfo.InvariantCulture, "Id: {0}, Start: {1}, Stop: {2}, TaskId: {3}", Id, Start, Stop, TaskId);
}