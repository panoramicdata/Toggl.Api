using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// DTO for applying a promo code to a subscription
/// https://engineering.toggl.com/docs/api/subscription
/// </summary>
public class SubscriptionPromoCodeDto
{
	/// <summary>
	/// The promo code to apply
	/// </summary>
	[JsonPropertyName("promo_code")]
	public required string PromoCode { get; set; }
}
