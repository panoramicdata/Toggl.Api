using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public class PaymentCard
{
	/// <summary>
	/// The country
	/// </summary>
	[JsonPropertyName("country")]
	public required string Country { get; set; }

	/// <summary>
	/// The brand
	/// </summary>
	[JsonPropertyName("brand")]
	public required string Brand { get; set; }

	/// <summary>
	/// The last four digits of the card
	/// </summary>
	[JsonPropertyName("last4")]
	public required string Last4Digits { get; set; }

	/// <summary>
	/// The expiration month
	/// </summary>
	[JsonPropertyName("exp_month")]
	public required int ExpiryMonth { get; set; }

	/// <summary>
	/// The expiration year
	/// </summary>
	[JsonPropertyName("exp_year")]
	public required int ExpiryYear { get; set; }
}
