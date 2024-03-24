using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A project summary report response
/// </summary>
public class ProjectSummaryReportItem
{
	///// <summary>
	///// The billable seconds
	///// </summary>
	//[JsonPropertyName("billable_seconds")]
	//public required int BillableSeconds { get; set; }

	///// <summary>
	///// The project id
	///// </summary>
	//[JsonPropertyName("project_id")]
	//public required int ProjectId { get; set; }

	///// <summary>
	///// The tracked seconds
	///// </summary>
	//[JsonPropertyName("tracked_seconds")]
	//public required int TrackedSeconds { get; set; }

	/// <summary>
	/// The seconds
	/// </summary>
	[JsonPropertyName("seconds")]
	public required int Seconds { get; set; }

	/// <summary>
	/// The rates
	/// </summary>
	[JsonPropertyName("rates")]
	public required ICollection<object> Rates { get; set; }
}
