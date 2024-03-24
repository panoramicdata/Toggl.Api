using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/clients#get-list-clients
/// </summary>
public class Client : NamedIdentifiedItem
{
	/// <summary>
	/// IsArchived is true if the client is archived
	/// </summary>
	[JsonPropertyName("archived")]
	public bool IsArchived { get; set; }

	/// <summary>
	/// When was the last update
	/// </summary>
	[JsonPropertyName("at")]
	public DateTime? LastModified { get; set; }

	/// <summary>
	/// CreatorID is the ID of the user who created the client
	/// </summary>
	[JsonPropertyName("creator_id")]
	public double? CreatorId { get; set; }

	/// <summary>
	/// List of authorization permissions for this client.
	/// </summary>
	[JsonPropertyName("permissions")]
	public string? permissions { get; set; }

	/// <summary>
	/// When was deleted, null if not deleted
	/// </summary>
	[JsonPropertyName("server_deleted_at")]
	public DateTimeOffset? DeletedAt { get; set; }

	/// <summary>
	/// Workspace ID
	/// </summary>
	[JsonPropertyName("wid")]
	public long WorkspaceId { get; set; }

	public override string ToString()
		=> string.Format(CultureInfo.InvariantCulture, "Id: {0}, Name: {1} {2}", Id, Name, DeletedAt == null ? string.Empty : "[DELETED]");
}