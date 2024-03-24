using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public class Report : Item
{
	[JsonPropertyName("total_grand")]
	public long? TotalGrand { get; set; }

	[JsonPropertyName("total_billable")]
	public long? TotalBillable { get; set; }
}