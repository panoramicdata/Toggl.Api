using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Workspace statistics
/// https://engineering.toggl.com/docs/api/workspaces#get-workspace-statistics
/// </summary>
public class WorkspaceStatistics
{
	/// <summary>
	/// Number of admins in the workspace
	/// </summary>
	[JsonPropertyName("admins")]
	public int Admins { get; set; }

	/// <summary>
	/// Number of groups in the workspace
	/// </summary>
	[JsonPropertyName("groups")]
	public int Groups { get; set; }

	/// <summary>
	/// Number of members in the workspace
	/// </summary>
	[JsonPropertyName("members")]
	public int Members { get; set; }

	/// <summary>
	/// Number of pending invitations
	/// </summary>
	[JsonPropertyName("pending_invitations")]
	public int? PendingInvitations { get; set; }

	/// <summary>
	/// Total tracked seconds
	/// </summary>
	[JsonPropertyName("total_tracked_seconds")]
	public long? TotalTrackedSeconds { get; set; }

	/// <summary>
	/// Earliest time entry date
	/// </summary>
	[JsonPropertyName("earliest_time_entry_date")]
	public DateTimeOffset? EarliestTimeEntryDate { get; set; }
}
