using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Result of creating invitations
/// https://engineering.toggl.com/docs/api/invitations#post-creates-a-new-invitation-for-the-user
/// </summary>
public class InvitationResult
{
	/// <summary>
	/// Emails that were successfully sent invitations
	/// </summary>
	[JsonPropertyName("data")]
	public ICollection<InvitationResultItem>? Data { get; set; }

	/// <summary>
	/// Invitation metadata returned alongside the created invitations.
	/// </summary>
	[JsonPropertyName("invitations")]
	public ICollection<Invitation>? Invitations { get; set; }

	/// <summary>
	/// Messages about the invitation process
	/// </summary>
	[JsonPropertyName("messages")]
	public ICollection<string>? Messages { get; set; }
}

/// <summary>
/// Individual invitation result item
/// </summary>
public class InvitationResultItem
{
	/// <summary>
	/// Email address that was invited
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// Invitation ID
	/// </summary>
	[JsonPropertyName("invitation_id")]
	public long? InvitationId { get; set; }

	/// <summary>
	/// Invite URL
	/// </summary>
	[JsonPropertyName("invite_url")]
	public string? InviteUrl { get; set; }

	/// <summary>
	/// Organization ID for the invitation.
	/// </summary>
	[JsonPropertyName("organization_id")]
	public long? OrganizationId { get; set; }

	/// <summary>
	/// Sender user ID.
	/// </summary>
	[JsonPropertyName("sender_id")]
	public long? SenderId { get; set; }

	/// <summary>
	/// Recipient user ID.
	/// </summary>
	[JsonPropertyName("recipient_id")]
	public long? RecipientId { get; set; }

	/// <summary>
	/// Organization user ID if already a member
	/// </summary>
	[JsonPropertyName("organization_user_id")]
	public long? OrganizationUserId { get; set; }

	/// <summary>
	/// User ID if already a member
	/// </summary>
	[JsonPropertyName("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Workspace assignments created for the invitation.
	/// </summary>
	[JsonPropertyName("workspaces")]
	public ICollection<InvitationWorkspaceInfo>? Workspaces { get; set; }
}
