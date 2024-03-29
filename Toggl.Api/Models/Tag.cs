using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public class Tag : NamedIdentifiedItem
{
	/// <summary>
	/// When was created/last modified
	/// </summary>
	[JsonPropertyName("at")]
	public DateTimeOffset LastModified { get; set; }

	/// <summary>
	/// CreatorID the user who created the tag
	/// </summary>
	[JsonPropertyName("creator_id")]
	public long CreatorId { get; set; }

	/// <summary>
	/// When was deleted
	/// </summary>
	[JsonPropertyName("deleted_at")]
	public DateTimeOffset? Deleted { get; set; }

	/// <summary>
	/// Permissions
	/// </summary>
	[JsonPropertyName("permissions")]
	public string? Permissions { get; set; }

	/// <summary>
	/// The workspace id
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public int WorkspaceId { get; set; }
}
