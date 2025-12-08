using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Organization invitation
/// https://engineering.toggl.com/docs/api/invitations
/// </summary>
public class Invitation : IdentifiedItem
{
	/// <summary>
	/// Email address of the invitee
	/// </summary>
	[JsonPropertyName("email")]
	public required string Email { get; set; }

	/// <summary>
	/// Invitation code
	/// </summary>
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	/// <summary>
	/// Organization ID for the invitation
	/// </summary>
	[JsonPropertyName("organization_id")]
	public long OrganizationId { get; set; }

	/// <summary>
	/// Workspace IDs the user will be invited to
	/// </summary>
	[JsonPropertyName("workspace_ids")]
	public long[]? WorkspaceIds { get; set; }

	/// <summary>
	/// User ID of the inviter
	/// </summary>
	[JsonPropertyName("inviter_id")]
	public long? InviterId { get; set; }

	/// <summary>
	/// Name of the inviter
	/// </summary>
	[JsonPropertyName("inviter_name")]
	public string? InviterName { get; set; }

	/// <summary>
	/// Workspace name (for single workspace invites)
	/// </summary>
	[JsonPropertyName("workspace_name")]
	public string? WorkspaceName { get; set; }

	/// <summary>
	/// Organization name
	/// </summary>
	[JsonPropertyName("organization_name")]
	public string? OrganizationName { get; set; }

	/// <summary>
	/// When the invitation was created
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTimeOffset? Created { get; set; }

	/// <summary>
	/// When the invitation expires
	/// </summary>
	[JsonPropertyName("expires_at")]
	public DateTimeOffset? ExpiresAt { get; set; }

	/// <summary>
	/// Whether the invitation is for SSO
	/// </summary>
	[JsonPropertyName("sso")]
	public bool? IsSso { get; set; }

	/// <summary>
	/// Total count of items in the response (only populated when listing)
	/// </summary>
	[JsonPropertyName("total_count")]
	public int? TotalCount { get; set; }
}
