using Newtonsoft.Json;
using System.Collections.Generic;

namespace Toggl.Api.Models;

/// <summary>
/// An organization update DTO.
/// </summary>
public class OrganizationUser : NamedIdentifiedItem
{
	/// <summary>
	/// Whether the user is an admin
	/// </summary>
	[JsonProperty(PropertyName = "admin")]
	public bool IsAdmin { get; set; }

	/// <summary>
	/// The avatar url
	/// </summary>
	[JsonProperty(PropertyName = "avatar_url")]
	public required string AvatarUrl { get; set; }

	/// <summary>
	/// Whether the user's email can be edited
	/// </summary>
	[JsonProperty(PropertyName = "can_edit_email")]
	public bool CanEditEmail { get; set; }

	/// <summary>
	/// Groups
	/// </summary>
	[JsonProperty(PropertyName = "groups")]
	public required ICollection<UserGroup> Groups { get; set; }

	/// <summary>
	/// Whether the user is inactive
	/// </summary>
	[JsonProperty(PropertyName = "inactive")]
	public bool IsInactive { get; set; }

	/// <summary>
	/// Invitation code
	/// </summary>
	[JsonProperty(PropertyName = "invitation_code")]
	public bool InvitationCode { get; set; }

	/// <summary>
	/// Whether the user is joined
	/// </summary>
	[JsonProperty(PropertyName = "joined")]
	public bool IsJoined { get; set; }

	/// <summary>
	/// Whether the requesting user is a the owner
	/// </summary>
	[JsonProperty(PropertyName = "owner")]
	public bool IsOwner { get; set; }

	/// <summary>
	/// The user id
	/// </summary>
	[JsonProperty(PropertyName = "user_id")]
	public bool UserId { get; set; }

	/// <summary>
	/// Workspaces that the user belongs to
	/// </summary>
	[JsonProperty(PropertyName = "workspaces")]
	public required ICollection<UserWorkspace> Workspaces { get; set; }
}
