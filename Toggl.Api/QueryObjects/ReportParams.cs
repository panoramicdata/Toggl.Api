using System.Collections.Generic;
using System.Text.Json.Serialization;
using Toggl.Api.Models;

namespace Toggl.Api.QueryObjects;

/// <summary>
/// Report parameters.
/// </summary>
public class ReportParams : Item
{
	/// <summary>
	/// The user agent.
	/// </summary>
	[JsonPropertyName("user_agent")]
	public string? UserAgent { get; set; }

	/// <summary>
	/// The workspace ID.
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public long? WorkspaceId { get; set; }

	/// <summary>
	/// The start date.
	/// </summary>
	[JsonPropertyName("since")]
	public string? Since { get; set; }

	/// <summary>
	/// The end date.
	/// </summary>
	[JsonPropertyName("until")]
	public string? Until { get; set; }

	/// <summary>
	/// The billable filter.
	/// </summary>
	[JsonPropertyName("billable")]
	public string? Billable { get; set; }

	/// <summary>
	/// The client IDs.
	/// </summary>
	[JsonPropertyName("client_ids")]
	public List<long>? ClientIds { get; set; }

	/// <summary>
	/// The project IDs.
	/// </summary>
	[JsonPropertyName("project_ids")]
	public List<long>? ProjectIds { get; set; }

	/// <summary>
	/// The user IDs.
	/// </summary>
	[JsonPropertyName("user_ids")]
	public List<long>? UserIds { get; set; }

	/// <summary>
	/// The tag IDs.
	/// </summary>
	[JsonPropertyName("tag_ids")]
	public List<long>? TagIds { get; set; }

	/// <summary>
	/// The task IDs.
	/// </summary>
	[JsonPropertyName("task_ids")]
	public string? TaskIds { get; set; }

	/// <summary>
	/// The time entry IDs.
	/// </summary>
	[JsonPropertyName("time_entry_ids")]
	public List<long>? TimeEntryIds { get; set; }

	/// <summary>
	/// The description filter.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// Whether to filter entries without description.
	/// </summary>
	[JsonPropertyName("without_description")]
	public bool? WithoutDescription { get; set; }
}
