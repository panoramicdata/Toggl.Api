using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// DTO for creating or updating a subscription customer
/// https://engineering.toggl.com/docs/api/subscription
/// </summary>
public class SubscriptionCustomerDto
{
	/// <summary>
	/// Email address
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// First name
	/// </summary>
	[JsonPropertyName("first_name")]
	public string? FirstName { get; set; }

	/// <summary>
	/// Last name
	/// </summary>
	[JsonPropertyName("last_name")]
	public string? LastName { get; set; }

	/// <summary>
	/// Organization name
	/// </summary>
	[JsonPropertyName("organization")]
	public string? Organization { get; set; }

	/// <summary>
	/// Phone number
	/// </summary>
	[JsonPropertyName("phone")]
	public string? Phone { get; set; }

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
	/// Zip code
	/// </summary>
	[JsonPropertyName("zip_code")]
	public string? ZipCode { get; set; }
}
