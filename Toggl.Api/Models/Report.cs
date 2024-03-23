using Newtonsoft.Json;

namespace Toggl.Api.Models;

public class Report : Item
{
	[JsonProperty(PropertyName = "total_grand")]
	public long? TotalGrand { get; set; }

	[JsonProperty(PropertyName = "total_billable")]
	public long? TotalBillable { get; set; }
}