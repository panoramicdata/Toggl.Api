using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public class RecurringParameter
{
	/// <summary>
	/// Estimated seconds
	/// </summary>
	[JsonPropertyName("estimated_seconds")]
	public required int EstimatedSeconds { get; set; }

	/// <summary>
	/// Period
	/// </summary>
	[JsonPropertyName("period")]
	public required string Period { get; set; }

	/// <summary>
	/// Custom period
	/// </summary>
	[JsonPropertyName("custom_period")]
	public string? CustomPeriod { get; set; }

	/// <summary>
	/// Project start date
	/// </summary>
	[JsonPropertyName("project_start_date")]
	public required DateTimeOffset ProjectStartDate { get; set; }

	/// <summary>
	/// Parameter start date
	/// </summary>
	[JsonPropertyName("parameter_start_date")]
	public required DateTimeOffset ParameterStartDate { get; set; }

	/// <summary>
	/// Parameter end date
	/// </summary>
	[JsonPropertyName("parameter_end_date")]
	public DateTimeOffset? ParameterEndDate { get; set; }
}
