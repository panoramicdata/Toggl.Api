using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// The workspace rate change mode.
/// </summary>
public enum WorkspaceRateChangeMode
{
	/// <summary>
	/// Start today.
	/// </summary>
	[JsonPropertyName("start_today")]
	StartToday,

	/// <summary>
	/// Override current.
	/// </summary>
	[JsonPropertyName("override-current")]
	OverrideCurrent,

	/// <summary>
	/// Override all.
	/// </summary>
	[JsonPropertyName("override-all")]
	OverrideAll
}