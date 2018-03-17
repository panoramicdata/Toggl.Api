using Newtonsoft.Json;

namespace Toggl.Api.DataObjects
{
	public class Report : BaseDataObject
	{
		[JsonProperty(PropertyName = "total_grand")]
		public long? TotalGrand { get; set; }

		[JsonProperty(PropertyName = "total_billable")]
		public long? TotalBillable { get; set; }
	}
}