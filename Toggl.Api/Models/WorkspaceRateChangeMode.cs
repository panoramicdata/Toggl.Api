using System.Text.Json.Serialization;

namespace Toggl.Api;

public enum WorkspaceRateChangeMode
{
	[JsonPropertyName("start_today")]
	StartToday,

	[JsonPropertyName("override-current")]
	OverrideCurrent,

	[JsonPropertyName("override-all")]
	OverrideAll
}