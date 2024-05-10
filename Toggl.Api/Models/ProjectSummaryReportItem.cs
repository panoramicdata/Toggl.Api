using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A project summary report response
/// </summary>
public class ProjectSummaryReportItem
{
	/// <summary>
	/// The billable amount in cents
	/// </summary>
	[JsonPropertyName("billable_amount_in_cents")]
	public int BillableAmountInCents { get; set; }

	/// <summary>
	/// The seconds
	/// </summary>
	[JsonPropertyName("seconds")]
	public int Seconds { get; set; }

	/// <summary>
	/// The labour cost in cents
	/// </summary>
	[JsonPropertyName("labour_cost_in_cents")]
	public int LabourCostInCents { get; set; }

	/// <summary>
	/// The resolution
	/// </summary>
	[JsonPropertyName("resolution")]
	public string Resolution { get; set; } = string.Empty;

	/// <summary>
	/// The tracked days
	/// </summary>
	[JsonPropertyName("tracked_days")]
	public int TrackedDays { get; set; }

	/// <summary>
	/// The graphs
	/// </summary>
	[JsonPropertyName("graph")]
	public ICollection<object>? Graph { get; set; } = [];

	/// <summary>
	/// The rates
	/// </summary>
	[JsonPropertyName("rates")]
	public ICollection<Rate>? Rates { get; set; } = [];
}
