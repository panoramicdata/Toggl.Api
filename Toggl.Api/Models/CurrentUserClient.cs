using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/me#get-clients
/// </summary>
public class CurrentUserClient : NamedIdentifiedItem
{
	/// <summary>
	/// IsArchived is true if the client is archived
	/// </summary>
	[JsonPropertyName("archived")]
	public required bool IsArchived { get; set; }

	/// <summary>
	/// When was the last update
	/// </summary>
	[JsonPropertyName("at")]
	public required DateTimeOffset LastModified { get; set; }

	/// <summary>
	/// CreatorID is the ID of the user who created the client

	/// </summary>
	[JsonPropertyName("creator_id")]
	public required int CreatorId { get; set; }

	/// <summary>
	/// List of authorization permissions for this client.
	/// </summary>
	[JsonPropertyName("permissions")]
	public string? Permissions { get; set; }

	/// <summary>
	/// When was deleted, null if not deleted
	/// </summary>
	[JsonPropertyName("server_deleted_at")]
	public DateTimeOffset? ServerDeletedAt { get; set; }

	/// <summary>
	/// Workspace ID
	/// </summary>
	[JsonPropertyName("wid")]
	public long WorkspaceId { get; set; }

	/// <summary>
	/// Total count of items in the response (only populated when listing)
	/// </summary>
	[JsonPropertyName("total_count")]
	public int? TotalCount { get; set; }
}