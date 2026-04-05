using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A report.
/// </summary>
public class Report : Item
{
	/// <summary>
	/// The total grand duration.
	/// </summary>
	[JsonPropertyName("total_grand")]
	public long? TotalGrand { get; set; }

	/// <summary>
	/// The total billable duration.
	/// </summary>
	[JsonPropertyName("total_billable")]
	public long? TotalBillable { get; set; }
}