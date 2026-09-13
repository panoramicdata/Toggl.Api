using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A payment card.
/// </summary>
public class PaymentCard
{
	/// <summary>
	/// The country
	/// </summary>
	[JsonPropertyName("country")]
	public string? Country { get; set; }

	/// <summary>
	/// The brand
	/// </summary>
	[JsonPropertyName("brand")]
	public string? Brand { get; set; }

	/// <summary>
	/// The last four digits of the card
	/// </summary>
	[JsonPropertyName("last4")]
	public string? Last4Digits { get; set; }

	/// <summary>
	/// The expiration month
	/// </summary>
	[JsonPropertyName("exp_month")]
	public int? ExpiryMonth { get; set; }

	/// <summary>
	/// The expiration year
	/// </summary>
	[JsonPropertyName("exp_year")]
	public int? ExpiryYear { get; set; }
}
