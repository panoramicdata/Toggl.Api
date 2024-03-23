using Newtonsoft.Json;
using System.Collections.Generic;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/me#get-features
/// </summary>
public class WorkspaceFeature : NamedItem
{
	/// <summary>
	/// The features
	/// </summary>
	[JsonProperty(PropertyName = "features")]
	public required ICollection<Feature> Features { get; set; }

	/// <summary>
	/// The workspace id
	/// </summary>
	[JsonProperty(PropertyName = "workspace_id")]
	public required int WorkspaceId { get; set; }
}