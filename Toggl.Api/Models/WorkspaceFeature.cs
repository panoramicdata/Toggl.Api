using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/me#get-features
/// </summary>
public class WorkspaceFeature : Item
{
	/// <summary>
	/// The features
	/// </summary>
	[JsonPropertyName("features")]
	public required ICollection<Feature> Features { get; set; }

	/// <summary>
	/// The workspace id
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public required int WorkspaceId { get; set; }
}