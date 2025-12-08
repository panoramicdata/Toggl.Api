using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Represents a subscription for an organization
/// https://engineering.toggl.com/docs/api/subscription
/// </summary>
public class Subscription
{
	/// <summary>
	/// Whether auto-renew is enabled
	/// </summary>
	[JsonPropertyName("auto_renew")]
	public bool AutoRenew { get; set; }

	/// <summary>
	/// Card details
	/// </summary>
	[JsonPropertyName("card_details")]
	public CardDetails? CardDetails { get; set; }

	/// <summary>
	/// Company ID
	/// </summary>
	[JsonPropertyName("company_id")]
	public long? CompanyId { get; set; }

	/// <summary>
	/// Contact detail
	/// </summary>
	[JsonPropertyName("contact_detail")]
	public ContactDetail? ContactDetail { get; set; }

	/// <summary>
	/// Created at timestamp
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTimeOffset? CreatedAt { get; set; }

	/// <summary>
	/// Currency code (e.g., USD)
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// Current period end date
	/// </summary>
	[JsonPropertyName("current_period_ends_at")]
	public DateTimeOffset? CurrentPeriodEndsAt { get; set; }

	/// <summary>
	/// Customer ID
	/// </summary>
	[JsonPropertyName("customer_id")]
	public long? CustomerId { get; set; }

	/// <summary>
	/// Deleted at timestamp
	/// </summary>
	[JsonPropertyName("deleted_at")]
	public DateTimeOffset? DeletedAt { get; set; }

	/// <summary>
	/// Last pricing plan ID
	/// </summary>
	[JsonPropertyName("last_pricing_plan_id")]
	public int? LastPricingPlanId { get; set; }

	/// <summary>
	/// Organization ID
	/// </summary>
	[JsonPropertyName("organization_id")]
	public long OrganizationId { get; set; }

	/// <summary>
	/// Payment method
	/// </summary>
	[JsonPropertyName("payment_method")]
	public string? PaymentMethod { get; set; }

	/// <summary>
	/// Pricing plan ID
	/// </summary>
	[JsonPropertyName("pricing_plan_id")]
	public int PricingPlanId { get; set; }

	/// <summary>
	/// Renewal at timestamp
	/// </summary>
	[JsonPropertyName("renewal_at")]
	public DateTimeOffset? RenewalAt { get; set; }

	/// <summary>
	/// Subscription ID
	/// </summary>
	[JsonPropertyName("subscription_id")]
	public long SubscriptionId { get; set; }

	/// <summary>
	/// Subscription period
	/// </summary>
	[JsonPropertyName("subscription_period")]
	public SubscriptionPeriod? SubscriptionPeriod { get; set; }

	/// <summary>
	/// Toggl product handle
	/// </summary>
	[JsonPropertyName("toggl_product_handle")]
	public string? TogglProductHandle { get; set; }

	/// <summary>
	/// Updated at timestamp
	/// </summary>
	[JsonPropertyName("updated_at")]
	public DateTimeOffset? UpdatedAt { get; set; }
}

/// <summary>
/// Card details for a subscription
/// </summary>
public class CardDetails
{
	/// <summary>
	/// Card type (e.g., visa, mastercard)
	/// </summary>
	[JsonPropertyName("card_type")]
	public string? CardType { get; set; }

	/// <summary>
	/// Expiration month
	/// </summary>
	[JsonPropertyName("expiration_month")]
	public int? ExpirationMonth { get; set; }

	/// <summary>
	/// Expiration year
	/// </summary>
	[JsonPropertyName("expiration_year")]
	public int? ExpirationYear { get; set; }

	/// <summary>
	/// Last four digits of the card
	/// </summary>
	[JsonPropertyName("last_four")]
	public string? LastFour { get; set; }
}

/// <summary>
/// Contact detail for a subscription
/// </summary>
public class ContactDetail
{
	/// <summary>
	/// Company name
	/// </summary>
	[JsonPropertyName("company_name")]
	public string? CompanyName { get; set; }

	/// <summary>
	/// Company address
	/// </summary>
	[JsonPropertyName("company_address")]
	public string? CompanyAddress { get; set; }

	/// <summary>
	/// Company city
	/// </summary>
	[JsonPropertyName("company_city")]
	public string? CompanyCity { get; set; }

	/// <summary>
	/// Country ID
	/// </summary>
	[JsonPropertyName("country_id")]
	public int? CountryId { get; set; }

	/// <summary>
	/// Country subdivision ID (state/province)
	/// </summary>
	[JsonPropertyName("country_subdivision_id")]
	public int? CountrySubdivisionId { get; set; }

	/// <summary>
	/// VAT number
	/// </summary>
	[JsonPropertyName("vat_number")]
	public string? VatNumber { get; set; }

	/// <summary>
	/// VAT number valid
	/// </summary>
	[JsonPropertyName("vat_number_valid")]
	public bool? VatNumberValid { get; set; }

	/// <summary>
	/// Zip code
	/// </summary>
	[JsonPropertyName("zip_code")]
	public string? ZipCode { get; set; }
}

/// <summary>
/// Subscription period details
/// </summary>
public class SubscriptionPeriod
{
	/// <summary>
	/// Period end date
	/// </summary>
	[JsonPropertyName("period_end")]
	public DateTimeOffset? PeriodEnd { get; set; }

	/// <summary>
	/// Period start date
	/// </summary>
	[JsonPropertyName("period_start")]
	public DateTimeOffset? PeriodStart { get; set; }
}
