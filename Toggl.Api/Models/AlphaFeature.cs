using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Alpha feature configuration
/// https://engineering.toggl.com/docs/api/preferences
/// </summary>
public class AlphaFeature
{
	/// <summary>
	/// Alpha feature code
	/// </summary>
	[JsonPropertyName("code")]
	public required string Code { get; set; }

	/// <summary>
	/// Whether the alpha feature is enabled for the user
	/// </summary>
	[JsonPropertyName("enabled")]
	public required bool Enabled { get; set; }
}
