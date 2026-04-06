using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Workspace settings for an invitation request.
/// </summary>
public class InvitationWorkspace
{
	/// <summary>
	/// Workspace ID to invite the user to.
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public required long WorkspaceId { get; set; }
}