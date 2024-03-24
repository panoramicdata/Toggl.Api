using System.Text.Json.Serialization;

namespace Toggl.Api.QueryObjects;

public class DetailedReportParams : ReportParams
{
	[JsonPropertyName("page")]
	public long? Page { get; set; }
}
