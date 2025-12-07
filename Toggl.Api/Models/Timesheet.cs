using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Represents a timesheet
/// https://engineering.toggl.com/docs/api/me#get-timesheets
/// </summary>
public class Timesheet : IdentifiedItem
{
	/// <summary>
	/// Approver ID
	/// </summary>
	[JsonPropertyName("approver_id")]
	public long? ApproverId { get; set; }

	/// <summary>
	/// Approver name
	/// </summary>
	[JsonPropertyName("approver_name")]
	public string? ApproverName { get; set; }

	/// <summary>
	/// When was last updated
	/// </summary>
	[JsonPropertyName("at")]
	public DateTimeOffset? At { get; set; }

	/// <summary>
	/// End date
	/// </summary>
	[JsonPropertyName("end_date")]
	public DateOnly? EndDate { get; set; }

	/// <summary>
	/// Member ID
	/// </summary>
	[JsonPropertyName("member_id")]
	public long? MemberId { get; set; }

	/// <summary>
	/// Member name
	/// </summary>
	[JsonPropertyName("member_name")]
	public string? MemberName { get; set; }

	/// <summary>
	/// Timesheet period type (weekly, monthly, etc.)
	/// </summary>
	[JsonPropertyName("period_type")]
	public string? PeriodType { get; set; }

	/// <summary>
	/// Rejection comment
	/// </summary>
	[JsonPropertyName("rejection_comment")]
	public string? RejectionComment { get; set; }

	/// <summary>
	/// Start date
	/// </summary>
	[JsonPropertyName("start_date")]
	public DateOnly? StartDate { get; set; }

	/// <summary>
	/// Status of the timesheet (pending, approved, rejected, etc.)
	/// </summary>
	[JsonPropertyName("status")]
	public string? Status { get; set; }

	/// <summary>
	/// Submitted at timestamp
	/// </summary>
	[JsonPropertyName("submitted_at")]
	public DateTimeOffset? SubmittedAt { get; set; }

	/// <summary>
	/// Workspace ID
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public long? WorkspaceId { get; set; }

	/// <summary>
	/// Workspace name
	/// </summary>
	[JsonPropertyName("workspace_name")]
	public string? WorkspaceName { get; set; }
}
