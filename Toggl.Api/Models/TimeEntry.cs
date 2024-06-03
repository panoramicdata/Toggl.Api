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
	/// When was last updated
	/// </summary>
	[JsonPropertyName("at")]
	public required DateTimeOffset At { get; set; }

	/// <summary>
	/// Whether the time entry is marked as billable
	/// </summary>
	[JsonPropertyName("billable")]
	public required bool Billable { get; set; }

	/// <summary>
	/// Related entities meta fields - if requested
	/// </summary>
	[JsonPropertyName("client_name")]
	public string? ClientName { get; set; }

	/// <summary>
	/// Time Entry description, null if not provided at creation/update
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Time entry duration. For running entries should be negative, preferable -1
	/// </summary>
	[JsonPropertyName("duration")]
	public required long Duration { get; set; }

	/// <summary>
	/// Used to create a TE with a duration but without a stop time, this field is deprecated for GET endpoints where the value will always be true.
	/// </summary>
	[JsonPropertyName("duronly")]
	public required bool Duronly { get; set; }

	/// <summary>
	/// Permission list
	/// </summary>
	[JsonPropertyName("permissions")]
	public ICollection<string>? Permissions { get; set; }

	/// <summary>
	/// Project ID, legacy field
	/// </summary>
	[JsonPropertyName("pid")]
	public required long Pid { get; set; }

	/// <summary>
	/// Is Project Active
	/// </summary>
	[JsonPropertyName("project_active")]
	public bool? ProjectActive { get; set; }

	/// <summary>
	/// Project Color
	/// </summary>
	[JsonPropertyName("project_color")]
	public bool? ProjectColor { get; set; }

	/// <summary>
	/// Project ID. Can be null if project was not provided or project was later deleted
	/// </summary>
	[JsonPropertyName("project_id")]
	public long? ProjectId { get; set; }

	/// <summary>
	/// Project Name
	/// </summary>
	[JsonPropertyName("project_name")]
	public string? ProjectName { get; set; }

	/// <summary>
	/// When was deleted, null if not deleted
	/// </summary>
	[JsonPropertyName("server_deleted_at")]
	public DateTimeOffset? ServerDeletedAt { get; set; }

	/// <summary>
	/// Indicates who the time entry has been shared with
	/// </summary>
	[JsonPropertyName("shared_with")]
	public TimeEntrySharedWith? SharedWith { get; set; }

	/// <summary>
	/// Start time in UTC
	/// </summary>
	[JsonPropertyName("start")]
	public DateTimeOffset? Start { get; set; }

	/// <summary>
	/// Stop time in UTC, can be null if it's still running or created with "duration" and "duronly" fields
	/// </summary>
	[JsonPropertyName("stop")]
	public DateTimeOffset? Stop { get; set; }

	/// <summary>
	/// Tag IDs, null if tags were not provided or were later deleted
	/// </summary>
	[JsonPropertyName("tag_ids")]
	public ICollection<long>? TagIds { get; set; }

	/// <summary>
	/// Tag names, null if tags were not provided or were later deleted
	/// </summary>
	[JsonPropertyName("tags")]
	public ICollection<string>? Tags { get; set; }

	/// <summary>
	/// Task ID. Can be null if task was not provided or project was later deleted
	/// </summary>
	[JsonPropertyName("task_id")]
	public long? TaskId { get; set; }

	/// <summary>
	/// Task Name
	/// </summary>
	[JsonPropertyName("task_name")]
	public string? TaskName { get; set; }

	/// <summary>
	/// Task ID, legacy field
	/// </summary>
	[JsonPropertyName("tid")]
	public long? Tid { get; set; }

	/// <summary>
	/// Time Entry creator ID, legacy field
	/// </summary>
	[JsonPropertyName("uid")]
	public long? Uid { get; set; }

	/// <summary>
	/// Avatar URL of the User
	/// </summary>
	[JsonPropertyName("user_avatar_url")]
	public string? UserAvatarUrl { get; set; }

	/// <summary>
	/// Time Entry creator ID
	/// </summary>
	[JsonPropertyName("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Time Entry creator ID
	/// </summary>
	[JsonPropertyName("user_name")]
	public string? UserName { get; set; }

	/// <summary>
	/// Workspace ID, legacy field
	/// </summary>
	[JsonPropertyName("wid")]
	public long? Wid { get; set; }

	/// <summary>
	/// Workspace ID
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public long? WorkspaceId { get; set; }

	public override string ToString() => string.Format(CultureInfo.InvariantCulture, "Id: {0}, Start: {1}, Stop: {2}, TaskId: {3}", Id, Start, Stop, TaskId);

	public record TimeEntrySharedWith
	{
		/// <summary>
		/// Is Accepted
		/// </summary>
		[JsonPropertyName("accepted")]
		public required bool Accepted { get; set; }

		/// <summary>
		/// User Id
		/// </summary>
		[JsonPropertyName("user_id")]
		public required long UserId { get; set; }

		/// <summary>
		/// User Name
		/// </summary>
		[JsonPropertyName("user_name")]
		public required string UserName { get; set; }
	}
}
