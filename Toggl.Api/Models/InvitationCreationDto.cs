using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Invitation creation request
/// https://engineering.toggl.com/docs/api/invitations#post-creates-a-new-invitation-for-the-user
/// </summary>
public class InvitationCreationDto
{
	/// <summary>
	/// List of emails to invite
	/// </summary>
	[JsonPropertyName("emails")]
	public required ICollection<string> Emails { get; set; }

	/// <summary>
	/// Workspace IDs to invite users to
	/// </summary>
	[JsonPropertyName("workspace_ids")]
	public ICollection<long>? WorkspaceIds { get; set; }

	/// <summary>
	/// Whether the invitation is for SSO
	/// </summary>
	[JsonPropertyName("sso")]
	public bool? IsSso { get; set; }
}
