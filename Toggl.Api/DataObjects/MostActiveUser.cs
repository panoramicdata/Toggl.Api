using Newtonsoft.Json;

namespace Toggl.Api.DataObjects;

public class MostActiveUser : BaseDataObject
{
	[JsonProperty(PropertyName = "user_id")]
	public long UserId { get; set; }

	[JsonProperty(PropertyName = "duration")]
	public int Duration { get; set; }
}