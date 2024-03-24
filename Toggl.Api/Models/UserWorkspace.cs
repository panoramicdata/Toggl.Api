using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
///	https://engineering.toggl.com/docs/api/organizations#get-list-of-users-in-organization
/// </summary>
public class UserWorkspace : NamedItem
{
	/// <summary>
	/// Whether requestor is an admin of the workspace
	/// </summary>
	[JsonPropertyName("admin")]
	public bool IsAdmin { get; set; }

	/// <summary>
	/// Whether requestor is inactive
	/// </summary>
	[JsonPropertyName("inactive")]
	public bool IsInactive { get; set; }

	/// <summary>
	/// The user's role in the workspace
	/// </summary>
	[JsonPropertyName("role")]
	public required string Role { get; set; }

	/// <summary>
	/// The workspace id
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public long WorkspaceId { get; set; }
}