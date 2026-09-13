using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A Project User
/// </summary>
public class ProjectUser : IdentifiedItem
{
	/// <summary>
	/// When was last modified
	/// </summary>
	[JsonPropertyName("at")]
	public DateTimeOffset? LastModified { get; set; }

	/// <summary>
	/// Group ID, legacy field
	/// </summary>
	[JsonPropertyName("group_id")]
	public long? GroupId { get; set; }

	/// <summary>
	/// Group ID (again, for some reason)
	/// </summary>
	[JsonPropertyName("gid")]
	public long? GroupId2 { get; set; }

	/// <summary>
	/// Labor cost for this project user (American spelling)
	/// </summary>
	[JsonPropertyName("labor_cost")]
	public decimal? LaborCost { get; set; }

	/// <summary>
	/// Labour cost for this project user (British spelling)
	/// </summary>
	[JsonPropertyName("labour_cost")]
	public decimal? LabourCost { get; set; }

	/// <summary>
	/// Labor cost last updated (American spelling)
	/// </summary>
	[JsonPropertyName("labor_cost_last_updated")]
	public object? LaborCostLastUpdated { get; set; }

	/// <summary>
	/// Labour cost last updated for this project user (British spelling)
	/// </summary>
	[JsonPropertyName("labour_cost_last_updated")]
	public object? LabourCostLastUpdated { get; set; }

	/// <summary>
	/// Whether the user is manager of the project
	/// </summary>
	[JsonPropertyName("manager")]
	public bool? IsManager { get; set; }

	/// <summary>
	/// Project ID
	/// </summary>
	[JsonPropertyName("project_id")]
	public long? ProjectId { get; set; }

	/// <summary>
	/// Custom rate for project user
	/// </summary>
	[JsonPropertyName("rate")]
	public double? HourlyRate { get; set; }

	/// <summary>
	/// When was last modified
	/// </summary>
	[JsonPropertyName("rate_last_updated")]
	public DateTimeOffset? RateLastModified { get; set; }

	/// <summary>
	/// The user ID.
	/// </summary>
	[JsonPropertyName("user_id")]
	public long? UserId { get; set; }

	/// <summary>
	/// Workspace ID
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public long? WorkspaceId { get; set; }
}
