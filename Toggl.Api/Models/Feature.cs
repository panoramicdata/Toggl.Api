using Newtonsoft.Json;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/me#get-features
/// </summary>
public class Feature : NamedItem
{
	/// <summary>
	/// Whether the feature is enabled
	/// </summary>
	[JsonProperty(PropertyName = "enabled")]
	public required bool IsEnabled { get; set; }

	/// <summary>
	/// The feature id
	/// </summary>
	[JsonProperty(PropertyName = "feature_id")]
	public required int FeatureId { get; set; }
}