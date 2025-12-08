using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Track reminder creation/update DTO
/// https://engineering.toggl.com/docs/api/workspaces#post-track-reminders
/// </summary>
public class TrackReminderCreationDto
{
	/// <summary>
	/// Periodicity of the reminder in days, should be either 1 or 7
	/// </summary>
	[JsonPropertyName("frequency")]
	public int Frequency { get; set; }

	/// <summary>
	/// Groups IDs to send the reminder to
	/// </summary>
	[JsonPropertyName("group_ids")]
	public ICollection<int>? GroupIds { get; set; }

	/// <summary>
	/// Threshold is the number of hours after which the reminder will be sent
	/// </summary>
	[JsonPropertyName("threshold")]
	public int Threshold { get; set; }

	/// <summary>
	/// User IDs to send the reminder to
	/// </summary>
	[JsonPropertyName("user_ids")]
	public ICollection<int>? UserIds { get; set; }
}
