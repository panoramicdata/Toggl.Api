using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// API quota information for an organization
/// https://engineering.toggl.com/docs/api/me#get-quota
/// </summary>
public class Quota
{
	/// <summary>
	/// Organization ID
	/// </summary>
	[JsonPropertyName("organization_id")]
	public long OrganizationId { get; set; }

	/// <summary>
	/// Organization name
	/// </summary>
	[JsonPropertyName("organization_name")]
	public string? OrganizationName { get; set; }

	/// <summary>
	/// Maximum requests allowed per hour
	/// </summary>
	[JsonPropertyName("max_requests")]
	public int MaxRequests { get; set; }

	/// <summary>
	/// Remaining requests in the current period
	/// </summary>
	[JsonPropertyName("remaining_requests")]
	public int RemainingRequests { get; set; }

	/// <summary>
	/// Seconds until the quota resets
	/// </summary>
	[JsonPropertyName("resets_in")]
	public int ResetsIn { get; set; }
}
