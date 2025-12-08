using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Represents a subscription customer
/// https://engineering.toggl.com/docs/api/subscription
/// </summary>
public class SubscriptionCustomer
{
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
}
