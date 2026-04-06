using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Workspace membership details returned for a created invitation.
/// </summary>
public class InvitationWorkspaceInfo
{
	/// <summary>
	/// Workspace ID.
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public long? WorkspaceId { get; set; }

	/// <summary>
	/// Workspace user ID created for the invitee.
	/// </summary>
	[JsonPropertyName("workspace_user_id")]
	public long? WorkspaceUserId { get; set; }

	/// <summary>
	/// User ID for the invitee.
	/// </summary>
	[JsonPropertyName("user_id")]
	public long? UserId { get; set; }
}