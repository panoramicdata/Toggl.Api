using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Organization owner information
/// https://engineering.toggl.com/docs/api/organizations#get-get-organization-owner
/// </summary>
public class OrganizationOwner : IdentifiedItem
{
	/// <summary>
	/// Email address of the owner
	/// </summary>
	[JsonPropertyName("email")]
	public required string Email { get; set; }

	/// <summary>
	/// Name of the owner
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// User ID of the owner
	/// </summary>
	[JsonPropertyName("user_id")]
	public long UserId { get; set; }
}
