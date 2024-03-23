using Newtonsoft.Json;

namespace Toggl.Api.Models;

public class MostActiveUser : Item
{
	[JsonProperty(PropertyName = "user_id")]
	public long UserId { get; set; }

	[JsonProperty(PropertyName = "duration")]
	public int Duration { get; set; }
}