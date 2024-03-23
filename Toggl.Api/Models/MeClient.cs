using Newtonsoft.Json;
using System;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/me#get-clients
/// </summary>
public class MeClient : NamedIdentifiedItem
{
	/// <summary>
	/// IsArchived is true if the client is archived
	/// </summary>
	[JsonProperty(PropertyName = "archived")]
	public required bool IsArchived { get; set; }

	/// <summary>
	/// When was the last update
	/// </summary>
	[JsonProperty(PropertyName = "at")]
	public required DateTimeOffset LastModified { get; set; }

	/// <summary>
	/// CreatorID is the ID of the user who created the client

	/// </summary>
	[JsonProperty(PropertyName = "creator_id")]
	public required int CreatorId { get; set; }

	/// <summary>
	/// List of authorization permissions for this client.
	/// </summary>
	[JsonProperty(PropertyName = "permissions")]
	public required string permissions { get; set; }

	/// <summary>
	/// When was deleted, null if not deleted
	/// </summary>
	[JsonProperty(PropertyName = "server_deleted_at")]
	public DateTimeOffset? ServerDeletedAt { get; set; }

	/// <summary>
	/// Workspace ID
	/// </summary>
	[JsonProperty(PropertyName = "wid")]
	public long WorkspaceId { get; set; }
}