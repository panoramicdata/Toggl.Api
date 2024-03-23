using Newtonsoft.Json;
using System.Collections.Generic;

namespace Toggl.Api.Models;

/// <summary>
/// An organization user update DTO.
/// </summary>
public class OrganizationUserUpdateDto : NamedItem
{
	/// <summary>
	/// Email
	/// </summary>
	[JsonProperty(PropertyName = "email")]
	public required string Email { get; set; }

	/// <summary>
	/// Group ids
	/// </summary>
	[JsonProperty(PropertyName = "groups")]
	public required ICollection<int> Groups { get; set; }

	/// <summary>
	/// Whether the user is inactive
	/// </summary>
	[JsonProperty(PropertyName = "inactive")]
	public required bool IsInactive { get; set; }

	/// <summary>
	/// Whether the user is an organization admin
	/// </summary>
	[JsonProperty(PropertyName = "organization_admin")]
	public bool IsOrganizationAdmin { get; set; }

	/// <summary>
	/// Workspaces that the user belongs to
	/// </summary>
	[JsonProperty(PropertyName = "workspaces")]
	public required ICollection<UserWorkspace> Workspaces { get; set; }
}
