using Newtonsoft.Json;

namespace Toggl.Api.DataObjects
{
	public class Dashboard : BaseDataObject
	{
		[JsonProperty(PropertyName = "most_active_user")]
		public MostActiveUser[] MostActiveUser { get; set; }

		[JsonProperty(PropertyName = "activity")]
		public Activity[] Activity { get; set; }
	}
}