using Newtonsoft.Json;

namespace Toggl.Api.Models;

public class Tag : IdentifiedItem
{
	[JsonProperty(PropertyName = "name")]
	public string? Name { get; set; }

	[JsonProperty(PropertyName = "workspace")]
	public Workspace? Workspace { get; set; }
}
