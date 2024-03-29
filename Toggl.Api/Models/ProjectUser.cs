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
	public required DateTimeOffset LastModified { get; set; }

	/// <summary>
	/// Group ID, legacy field
	/// </summary>
	[JsonPropertyName("group_id")]
	public required long? GroupId { get; set; }

	/// <summary>
	/// Group ID (again, for some reason)
	/// </summary>
	[JsonPropertyName("gid")]
	public required long? GroupId2 { get; set; }

	/// <summary>
	/// Labour cost for this project user
	/// </summary>
	[JsonPropertyName("labour_cost")]
	public required long? LabourCost { get; set; }

	/// <summary>
	/// Whether the user is manager of the project
	/// </summary>
	[JsonPropertyName("manager")]
	public required bool IsManager { get; set; }

	/// <summary>
	/// Project ID
	/// </summary>
	[JsonPropertyName("project_id")]
	public required long ProjectId { get; set; }

	/// <summary>
	/// Custom rate for project user
	/// </summary>
	[JsonPropertyName("rate")]
	public required double? HourlyRate { get; set; }

	/// <summary>
	/// When was last modified
	/// </summary>
	[JsonPropertyName("rate_last_updated")]
	public required DateTimeOffset? RateLastModified { get; set; }

	[JsonPropertyName("user_id")]
	public required long UserId { get; set; }

	/// <summary>
	/// Workspace ID
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public required long WorkspaceId { get; set; }
}
