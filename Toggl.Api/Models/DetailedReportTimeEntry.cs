using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public class DetailedReportTimeEntry
{
	/// <summary>
	/// The ID
	/// </summary>
	[JsonPropertyName("id")]
	public required long Id { get; set; }

	/// <summary>
	/// The seconds spent
	/// </summary>
	[JsonPropertyName("seconds")]
	public required int Seconds { get; set; }

	/// <summary>
	/// Start time
	/// </summary>
	[JsonPropertyName("start")]
	public DateTimeOffset Start { get; set; }

	/// <summary>
	/// Stop time
	/// </summary>
	[JsonPropertyName("stop")]
	public DateTimeOffset Stop { get; set; }

	/// <summary>
	/// When the entry was created
	/// </summary>
	[JsonPropertyName("at")]
	public DateTimeOffset At { get; set; }
}
