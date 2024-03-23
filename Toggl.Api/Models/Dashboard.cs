using Newtonsoft.Json;

namespace Toggl.Api.Models;

public class Dashboard : Item
{
	[JsonProperty(PropertyName = "most_active_user")]
	public MostActiveUser[] MostActiveUser { get; set; } = [];

	[JsonProperty(PropertyName = "activity")]
	public Activity[] Activity { get; set; } = [];
}