using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public class ReportRequest
{
	/// <summary>
	/// End date, example time.DateOnly. Should be greater than Start date
	/// </summary>
	[JsonPropertyName("end_date")]
	public required DateOnly EndDate { get; set; }

	/// <summary>
	/// 	Start time
	/// </summary>
	[JsonPropertyName("start_time")]
	public required TimeOnly StartTime { get; set; }

	/// <summary>
	/// 	Start date, example time.DateOnly. Should be less than End date.
	/// </summary>
	[JsonPropertyName("start_date")]
	public required DateOnly StartDate { get; set; }
}
