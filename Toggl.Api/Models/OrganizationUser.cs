using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// An organization update DTO.
/// </summary>
public class OrganizationUser : NamedIdentifiedItem
{
	/// <summary>
	/// Whether the user is an admin
	/// </summary>
	[JsonPropertyName("admin")]
	public bool IsAdmin { get; set; }

	/// <summary>
	/// The avatar url
	/// </summary>
	[JsonPropertyName("avatar_url")]
	public required string AvatarUrl { get; set; }

	/// <summary>
	/// Whether the user's email can be edited
	/// </summary>
	[JsonPropertyName("can_edit_email")]
	public bool CanEditEmail { get; set; }

	/// <summary>
	/// Groups
	/// </summary>
	[JsonPropertyName("groups")]
	public required ICollection<UserGroup> Groups { get; set; }

	/// <summary>
	/// Whether the user is inactive
	/// </summary>
	[JsonPropertyName("inactive")]
	public bool IsInactive { get; set; }

	/// <summary>
	/// Invitation code
	/// </summary>
	[JsonPropertyName("invitation_code")]
	public string? InvitationCode { get; set; }

	/// <summary>
	/// Whether the user is joined
	/// </summary>
	[JsonPropertyName("joined")]
	public bool IsJoined { get; set; }

	/// <summary>
	/// Whether the requesting user is a the owner
	/// </summary>
	[JsonPropertyName("owner")]
	public bool IsOwner { get; set; }

	/// <summary>
	/// The user id
	/// </summary>
	[JsonPropertyName("user_id")]
	public int UserId { get; set; }

	/// <summary>
	/// Workspaces that the user belongs to
	/// </summary>
	[JsonPropertyName("workspaces")]
	public required ICollection<UserWorkspace> Workspaces { get; set; }
}
