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
	public ICollection<Feature>? Features { get; set; }

	/// <summary>
	/// The workspace id
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public int? WorkspaceId { get; set; }
}