using Newtonsoft.Json;

namespace Toggl.Api.QueryObjects;

public class DetailedReportParams : ReportParams
{
	[JsonProperty(PropertyName = "page")]
	public long? Page { get; set; }
}
