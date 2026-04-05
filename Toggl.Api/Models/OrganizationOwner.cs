using System.Text.Json;
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

	/// <summary>
	/// Organization user ID of the owner
	/// </summary>
	[JsonPropertyName("organization_user_id")]
	public long? OrganizationUserId { get; set; }

	/// <summary>
	/// Organization ID
	/// </summary>
	[JsonPropertyName("organization_id")]
	public long? OrganizationId { get; set; }

	/// <summary>
	/// Toggl accounts identifier
	/// </summary>
	[JsonPropertyName("toggl_accounts_id")]
	public JsonElement? TogglAccountsId { get; set; }
}
