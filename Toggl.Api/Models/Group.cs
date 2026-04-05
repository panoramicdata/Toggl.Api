using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A user group.
/// </summary>
public class Group : NamedItem
{
	/// <summary>
	/// The group identifier
	/// </summary>
	[JsonPropertyName("id")]
	public long? Id { get; set; }

	/// <summary>
	/// The group id
	/// </summary>
	[JsonPropertyName("group_id")]
	public required int GroupId { get; set; }

	/// <summary>
	/// Timestamp of last update
	/// </summary>
	[JsonPropertyName("at")]
	public required DateTimeOffset LastModified { get; set; }

	/// <summary>
	/// The workspace ids
	/// </summary>
	[JsonPropertyName("workspaces")]
	public required ICollection<int> Workspaces { get; set; }

	/// <summary>
	/// The users
	/// </summary>
	[JsonPropertyName("users")]
	public required ICollection<GroupUser> Users { get; set; }

	/// <summary>
	/// Whether the group has users
	/// </summary>
	[JsonPropertyName("has_users")]
	public bool? HasUsers { get; set; }

	/// <summary>
	/// The workspace id
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public long? WorkspaceId { get; set; }

	/// <summary>
	/// Total count of items in the response (only populated when listing)
	/// </summary>
	[JsonPropertyName("total_count")]
	public int? TotalCount { get; set; }

	/// <summary>
	/// Group permissions payload
	/// </summary>
	[JsonPropertyName("permissions")]
	public JsonElement? Permissions { get; set; }
}