using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// DTO for creating or updating a subscription
/// https://engineering.toggl.com/docs/api/subscription
/// </summary>
public class SubscriptionCreationDto
{
	/// <summary>
	/// Billing period (monthly, yearly)
	/// </summary>
	[JsonPropertyName("billing_period")]
	public string? BillingPeriod { get; set; }

	/// <summary>
	/// Currency code (e.g., USD)
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// Pricing plan ID
	/// </summary>
	[JsonPropertyName("pricing_plan_id")]
	public int PricingPlanId { get; set; }

	/// <summary>
	/// Number of seats/users
	/// </summary>
	[JsonPropertyName("seats")]
	public int? Seats { get; set; }
}
