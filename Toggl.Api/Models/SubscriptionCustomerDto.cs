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

/// <summary>
/// Factory methods for <see cref="SubscriptionCustomerDto"/>.
/// </summary>
public static class SubscriptionCustomerDtoFactory
{
	/// <summary>
	/// Creates a new <see cref="SubscriptionCustomerDto"/> with the specified values.
	/// </summary>
	/// <param name="email">Email address.</param>
	/// <param name="firstName">First name.</param>
	/// <param name="lastName">Last name.</param>
	/// <param name="organization">Organization name.</param>
	/// <param name="phone">Phone number.</param>
	/// <param name="companyName">Company name.</param>
	/// <param name="companyAddress">Company address.</param>
	/// <param name="companyCity">Company city.</param>
	/// <param name="countryId">Country ID.</param>
	/// <param name="countrySubdivisionId">Country subdivision ID.</param>
	/// <param name="vatNumber">VAT number.</param>
	/// <param name="zipCode">Zip code.</param>
	/// <returns>A new <see cref="SubscriptionCustomerDto"/> with the provided values.</returns>
	public static SubscriptionCustomerDto Create(
		string? email,
		string? firstName,
		string? lastName,
		string? organization,
		string? phone,
		string? companyName,
		string? companyAddress,
		string? companyCity,
		int? countryId,
		int? countrySubdivisionId,
		string? vatNumber,
		string? zipCode)
		=> new()
		{
			Email = email,
			FirstName = firstName,
			LastName = lastName,
			Organization = organization,
			Phone = phone,
			CompanyName = companyName,
			CompanyAddress = companyAddress,
			CompanyCity = companyCity,
			CountryId = countryId,
			CountrySubdivisionId = countrySubdivisionId,
			VatNumber = vatNumber,
			ZipCode = zipCode
		};
}
