using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// An organization user update DTO.
/// </summary>
public class OrganizationUserUpdateDto : NamedItem
{
	/// <summary>
	/// Email
	/// </summary>
	[JsonPropertyName("email")]
	public required string Email { get; set; }

	/// <summary>
	/// Group ids
	/// </summary>
	[JsonPropertyName("groups")]
	public required ICollection<int> Groups { get; set; }

	/// <summary>
	/// Whether the user is inactive
	/// </summary>
	[JsonPropertyName("inactive")]
	public required bool IsInactive { get; set; }

	/// <summary>
	/// Whether the user is an organization admin
	/// </summary>
	[JsonPropertyName("organization_admin")]
	public bool IsOrganizationAdmin { get; set; }

	/// <summary>
	/// Workspaces that the user belongs to
	/// </summary>
	[JsonPropertyName("workspaces")]
	public required ICollection<UserWorkspace> Workspaces { get; set; }
}
