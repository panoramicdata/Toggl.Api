using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/me#get-features
/// </summary>
public class Location : Item
{
	/// <summary>
	/// The city
	/// </summary>
	[JsonPropertyName("city")]
	public string? city { get; set; }

	/// <summary>
	/// The city lat/long
	/// </summary>
	[JsonPropertyName("city_lat_long")]
	public string? CityLatLong { get; set; }

	/// <summary>
	/// The country code
	/// </summary>
	[JsonPropertyName("country_code")]
	public string? CountryCode { get; set; }

	/// <summary>
	/// The country name
	/// </summary>
	[JsonPropertyName("country_name")]
	public string? CountryName { get; set; }

	/// <summary>
	/// The state
	/// </summary>
	[JsonPropertyName("state")]
	public string? State { get; set; }
}