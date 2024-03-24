using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public class DetailedReport : Report
{
	[JsonPropertyName("data")]
	public List<ReportTimeEntry>? Data { get; set; }

	[JsonPropertyName("total_count")]
	public long? TotalCount { get; set; }

	[JsonPropertyName("per_page")]
	public long? PerPage { get; set; }
}