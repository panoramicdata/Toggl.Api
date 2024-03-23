using Newtonsoft.Json;
using System;
using System.Globalization;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/clients#get-list-clients
/// </summary>
public class Client : NamedIdentifiedItem
{
	/// <summary>
	/// IsArchived is true if the client is archived
	/// </summary>
	[JsonProperty(PropertyName = "archived")]
	public bool IsArchived { get; set; }

	/// <summary>
	/// When was the last update
	/// </summary>
	[JsonProperty(PropertyName = "at")]
	public DateTime? LastModified { get; set; }

	/// <summary>
	/// CreatorID is the ID of the user who created the client
	/// </summary>
	[JsonProperty(PropertyName = "creator_id")]
	public double? CreatorId { get; set; }

	/// <summary>
	/// List of authorization permissions for this client.
	/// </summary>
	[JsonProperty(PropertyName = "permissions")]
	public string? permissions { get; set; }

	/// <summary>
	/// When was deleted, null if not deleted
	/// </summary>
	[JsonProperty(PropertyName = "server_deleted_at")]
	public DateTimeOffset? DeletedAt { get; set; }

	/// <summary>
	/// Workspace ID
	/// </summary>
	[JsonProperty(PropertyName = "wid")]
	public long WorkspaceId { get; set; }

	public override string ToString()
		=> string.Format(CultureInfo.InvariantCulture, "Id: {0}, Name: {1} {2}", Id, Name, DeletedAt == null ? string.Empty : "[DELETED]");
}