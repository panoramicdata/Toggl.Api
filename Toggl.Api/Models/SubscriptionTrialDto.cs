using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// DTO for starting a trial subscription
/// https://engineering.toggl.com/docs/api/subscription
/// </summary>
public class SubscriptionTrialDto
{
	/// <summary>
	/// Pricing plan ID for the trial
	/// </summary>
	[JsonPropertyName("pricing_plan_id")]
	public int PricingPlanId { get; set; }
}
