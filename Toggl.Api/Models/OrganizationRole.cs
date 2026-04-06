using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Organization role information
/// https://engineering.toggl.com/docs/api/organizations#get-organization-roles
/// </summary>
public class OrganizationRole : IdentifiedItem
{
	/// <summary>
	/// Name of the role
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// Description of the role
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Whether this is a built-in role
	/// </summary>
	[JsonPropertyName("builtin")]
	public bool IsBuiltin { get; set; }

	/// <summary>
	/// Organization ID this role belongs to
	/// </summary>
	[JsonPropertyName("organization_id")]
	public long OrganizationId { get; set; }

	/// <summary>
	/// Role ID
	/// </summary>
	[JsonPropertyName("role_id")]
	public long? RoleId { get; set; }

	/// <summary>
	/// Role code
	/// </summary>
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	/// <summary>
	/// Entity type this role applies to
	/// </summary>
	[JsonPropertyName("entity")]
	public string? Entity { get; set; }

	/// <summary>
	/// Role type
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	/// Privilege level
	/// </summary>
	[JsonPropertyName("privilege_level")]
	public int? PrivilegeLevel { get; set; }
}
