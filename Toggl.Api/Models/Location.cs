using Newtonsoft.Json;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/me#get-features
/// </summary>
public class Location : Item
{
	/// <summary>
	/// The city
	/// </summary>
	[JsonProperty(PropertyName = "city")]
	public required string city { get; set; }

	/// <summary>
	/// The city lat/long
	/// </summary>
	[JsonProperty(PropertyName = "city_lat_long")]
	public required string CityLatLong { get; set; }

	/// <summary>
	/// The country code
	/// </summary>
	[JsonProperty(PropertyName = "country_code")]
	public required string CountryCode { get; set; }

	/// <summary>
	/// The country name
	/// </summary>
	[JsonProperty(PropertyName = "country_name")]
	public required string CountryName { get; set; }

	/// <summary>
	/// The state
	/// </summary>
	[JsonProperty(PropertyName = "state")]
	public required string State { get; set; }
}