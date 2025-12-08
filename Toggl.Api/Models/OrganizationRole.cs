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
}
