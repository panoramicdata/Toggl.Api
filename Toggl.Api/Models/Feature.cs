using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/me#get-features
/// </summary>
public class Feature : NamedItem
{
	/// <summary>
	/// Whether the feature is enabled
	/// </summary>
	[JsonPropertyName("enabled")]
	public bool? IsEnabled { get; set; }

	/// <summary>
	/// The feature id
	/// </summary>
	[JsonPropertyName("feature_id")]
	public int? FeatureId { get; set; }
}