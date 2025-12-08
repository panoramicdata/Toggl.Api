using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Organization pricing plan information
/// https://engineering.toggl.com/docs/api/organizations#get-organization-plans
/// </summary>
public class PricingPlan : IdentifiedItem
{
	/// <summary>
	/// Name of the pricing plan
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// Whether this is an enterprise plan
	/// </summary>
	[JsonPropertyName("enterprise")]
	public bool IsEnterprise { get; set; }

	/// <summary>
	/// Whether this plan is currently active
	/// </summary>
	[JsonPropertyName("active")]
	public bool IsActive { get; set; }

	/// <summary>
	/// Maximum number of users allowed on this plan
	/// </summary>
	[JsonPropertyName("maximum_users")]
	public int? MaximumUsers { get; set; }

	/// <summary>
	/// Price per user (in cents)
	/// </summary>
	[JsonPropertyName("price_per_user")]
	public int? PricePerUser { get; set; }

	/// <summary>
	/// Currency for the price
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }
}
