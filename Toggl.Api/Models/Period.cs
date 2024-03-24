using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public class Period
{
	/// <summary>
	/// The start date
	/// </summary>
	[JsonPropertyName("start_date")]
	public DateTimeOffset StartDate { get; set; }

	/// <summary>
	/// The end date
	/// </summary>
	[JsonPropertyName("end_date")]
	public DateTimeOffset EndDate { get; set; }
}
