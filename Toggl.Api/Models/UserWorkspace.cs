using Newtonsoft.Json;

namespace Toggl.Api.Models;

/// <summary>
///	https://engineering.toggl.com/docs/api/organizations#get-list-of-users-in-organization
/// </summary>
public class UserWorkspace : NamedItem
{
	/// <summary>
	/// Whether requestor is an admin of the workspace
	/// </summary>
	[JsonProperty(PropertyName = "admin")]
	public bool IsAdmin { get; set; }

	/// <summary>
	/// Whether requestor is inactive
	/// </summary>
	[JsonProperty(PropertyName = "inactive")]
	public bool IsInactive { get; set; }

	/// <summary>
	/// The user's role in the workspace
	/// </summary>
	[JsonProperty(PropertyName = "role")]
	public required string Role { get; set; }

	/// <summary>
	/// The workspace id
	/// </summary>
	[JsonProperty(PropertyName = "workspace_id")]
	public long WorkspaceId { get; set; }
}