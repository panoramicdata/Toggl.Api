// Ignore Spelling: Labour

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A workspace user
/// </summary>
public class WorkspaceUser : NamedIdentifiedItem
{
	/// <summary>
	/// The UID
	/// </summary>
	[JsonPropertyName("uid")]
	public int Uid { get; set; }

	/// <summary>
	/// Whether the user is active
	/// </summary>
	[JsonPropertyName("active")]
	public required bool IsActive { get; set; }

	/// <summary>
	/// Whether the user is an admin
	/// </summary>
	[JsonPropertyName("admin")]
	public required bool IsAdmin { get; set; }

	/// <summary>
	/// The avatar url
	/// </summary>
	[JsonPropertyName("avatar_file_name")]
	public string? AvatarUrl { get; set; }

	/// <summary>
	/// The email address
	/// </summary>
	[JsonPropertyName("email")]
	public required string Email { get; set; } = string.Empty;

	/// <summary>
	/// Groups
	/// </summary>
	[JsonPropertyName("group_ids")]
	public ICollection<long> GroupIds { get; set; } = [];

	/// <summary>
	/// Whether the user is inactive
	/// </summary>
	[JsonPropertyName("inactive")]
	public required bool IsInactive { get; set; }

	/// <summary>
	/// Invitation code
	/// </summary>
	[JsonPropertyName("invitation_code")]
	public string InvitationCode { get; set; } = string.Empty;

	/// <summary>
	/// Invitation code
	/// </summary>
	[JsonPropertyName("invite_url")]
	public string InvitationUrl { get; set; } = string.Empty;

	/// <summary>
	/// Indicates if user is a direct member of the workspace (is not assigned to the workspace using the group)
	/// </summary>
	[JsonPropertyName("is_direct")]
	public required bool IsDirect { get; set; }

	/// <summary>
	/// The user labor cost
	/// </summary>
	[JsonPropertyName("labor_cost")]
	public double? LaborCost { get; set; }

	/// <summary>
	/// The user labour cost
	/// </summary>
	[JsonPropertyName("labour_cost")]
	public double? LabourCost { get; set; }

	/// <summary>
	/// The user labour cost
	/// </summary>
	[JsonPropertyName("labor_cost_last_updated")]
	public DateTimeOffset? LabourCostLastUpdated { get; set; }

	/// <summary>
	/// When the labour cost was last updated
	/// </summary>
	[JsonPropertyName("labor_cost_last_updated")]
	public object? LabourCostLastUpdated { get; set; }

	/// <summary>
	/// Indicates if user is admin inside organization
	/// </summary>
	[JsonPropertyName("organization_admin")]
	public bool IsOrganizationAdmin { get; set; }

	/// <summary>
	/// Rate assigned to the user
	/// </summary>
	[JsonPropertyName("rate")]
	public double? Rate { get; set; }

	/// <summary>
	/// Timestamp of the last rate update
	/// </summary>
	[JsonPropertyName("rate_last_updated")]
	public DateTimeOffset? RateLastUpdated { get; set; }

	/// <summary>
	/// The user role
	/// </summary>
	[JsonPropertyName("role")]
	public required string Role { get; set; } = string.Empty;

	/// <summary>
	/// The timezone of the user
	/// </summary>
	[JsonPropertyName("timezone")]
	public required string TimeZone { get; set; } = string.Empty;

	/// <summary>
	/// The user ID
	/// </summary>
	[JsonPropertyName("user_id")]
	public int UserId { get; set; }

	/// <summary>
	/// The legacy user ID
	/// </summary>
	[JsonPropertyName("uid")]
	public int? Uid { get; set; }

	/// <summary>
	/// The working hours in minutes
	/// </summary>
	[JsonPropertyName("working_hours_in_minutes")]
	public int? WorkingHoursInMinutes { get; set; }

	/// <summary>
	/// Indicates whether the user is an admin in the workspace
	/// </summary>
	[JsonPropertyName("workspace_admin")]
	public bool IsWorkspaceAdmin { get; set; }

	/// <summary>
	/// The workspace identifier
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public int WorkspaceId { get; set; }

	/// <summary>
	/// The workspace identifier
	/// </summary>
	[JsonPropertyName("wid")]
	public long? Wid { get; set; }

	/// <summary>
	/// Timestamp of the last update
	/// </summary>
	[JsonPropertyName("at")]
	public DateTimeOffset? UpdatedAt { get; set; }
}
