using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/me#get-trackreminders
/// </summary>
public class TrackReminder : IdentifiedItem
{
	/// <summary>
	/// Reminder creation time
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTimeOffset Created { get; set; }

	/// <summary>
	/// Periodicity of the reminder in days, should be either 1 or 7
	/// The documentation states "Frequency" but it's actually "Periodicity"
	/// </summary>
	[JsonPropertyName("frequency")]
	public int PeriodicityDays { get; set; }

	/// <summary>
	/// Groups IDs to send the reminder to
	/// </summary>
	[JsonPropertyName("group_ids")]
	public required ICollection<int> GroupIds { get; set; }

	/// <summary>
	/// Reminder ID
	/// </summary>
	[JsonPropertyName("reminder_id")]
	public int ReminderId { get; set; }

	/// <summary>
	/// Threshold is the number of hours after which the reminder will be sent
	/// </summary>
	[JsonPropertyName("threshold")]
	public int ThresholdHours { get; set; }

	/// <summary>
	/// User IDs to send the reminder to
	/// </summary>
	[JsonPropertyName("user_ids")]
	public required ICollection<int> UserIds { get; set; }

	/// <summary>
	/// Workspace ID
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public int WorkspaceId { get; set; }
}
