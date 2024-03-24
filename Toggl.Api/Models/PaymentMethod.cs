using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public class PaymentMethod
{
	/// <summary>
	/// Whether the requester is an admin of the organization
	/// </summary>
	[JsonPropertyName("type")]
	public required string Type { get; set; }

	/// <summary>
	/// Whether the requester is an admin of the organization
	/// </summary>
	[JsonPropertyName("card")]
	public required PaymentCard Card { get; set; }
}