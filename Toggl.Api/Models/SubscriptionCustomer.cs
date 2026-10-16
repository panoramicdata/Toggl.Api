using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Represents a subscription customer
/// https://engineering.toggl.com/docs/api/subscription
/// </summary>
public class SubscriptionCustomer
{
	/// <summary>
	/// Identifier
	/// </summary>
	[JsonPropertyName("id")]
	public JsonElement? Id { get; set; }

	/// <summary>
	/// Customer ID
	/// </summary>
	[JsonPropertyName("customer_id")]
	public long CustomerId { get; set; }

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
	/// Reference (external ID)
	/// </summary>
	[JsonPropertyName("reference")]
	public string? Reference { get; set; }

	/// <summary>
	/// Toggl user identifier
	/// </summary>
	[JsonPropertyName("toggl_user_id")]
	public long? TogglUserId { get; set; }

	/// <summary>
	/// Toggl user email
	/// </summary>
	[JsonPropertyName("toggl_user_email")]
	public string? TogglUserEmail { get; set; }

	/// <summary>
	/// Site identifier
	/// </summary>
	[JsonPropertyName("site")]
	public string? Site { get; set; }

	/// <summary>
	/// Customer name
	/// </summary>
	[JsonPropertyName("customer_name")]
	public string? CustomerName { get; set; }

	/// <summary>
	/// Additional undocumented customer fields
	/// </summary>
	[JsonExtensionData]
	public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}

/// <summary>
/// Factory methods for <see cref="SubscriptionCustomer"/>.
/// </summary>
public static class SubscriptionCustomerFactory
{
	/// <summary>
	/// Creates a new <see cref="SubscriptionCustomer"/> with the specified values.
	/// </summary>
	/// <param name="email">Email address.</param>
	/// <param name="firstName">First name.</param>
	/// <param name="lastName">Last name.</param>
	/// <param name="organization">Organization name.</param>
	/// <param name="phone">Phone number.</param>
	/// <param name="reference">Reference (external ID).</param>
	/// <param name="togglUserId">Toggl user identifier.</param>
	/// <param name="togglUserEmail">Toggl user email.</param>
	/// <param name="site">Site identifier.</param>
	/// <param name="customerName">Customer name.</param>
	/// <returns>A new <see cref="SubscriptionCustomer"/> with the provided values.</returns>
	public static SubscriptionCustomer Create(
		string? email,
		string? firstName,
		string? lastName,
		string? organization,
		string? phone,
		string? reference,
		long? togglUserId,
		string? togglUserEmail,
		string? site,
		string? customerName)
		=> new()
		{
			Email = email,
			FirstName = firstName,
			LastName = lastName,
			Organization = organization,
			Phone = phone,
			Reference = reference,
			TogglUserId = togglUserId,
			TogglUserEmail = togglUserEmail,
			Site = site,
			CustomerName = customerName
		};
}
