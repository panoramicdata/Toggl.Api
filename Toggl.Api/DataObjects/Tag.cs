using Newtonsoft.Json;

namespace Toggl.Api.DataObjects;

public class Tag : BaseDataObject
{
	[JsonProperty(PropertyName = "name")]
	public string? Name { get; set; }

	[JsonProperty(PropertyName = "id")]
	public int? Id { get; set; }

	[JsonProperty(PropertyName = "workspace")]
	public Workspace? Workspace { get; set; }
}
