using System.Collections.Generic;
using System.Text.Json.Serialization;
using Toggl.Api.Models;

namespace Toggl.Api.QueryObjects;

public class ReportParams : Item
{
	[JsonPropertyName("user_agent")]
	public string? UserAgent { get; set; }

	[JsonPropertyName("workspace_id")]
	public long? WorkspaceId { get; set; }

	[JsonPropertyName("since")]
	public string? Since { get; set; }

	[JsonPropertyName("until")]
	public string? Until { get; set; }

	[JsonPropertyName("billable")]
	public string? Billable { get; set; }

	[JsonPropertyName("client_ids")]
	public List<long>? ClientIds { get; set; }

	[JsonPropertyName("project_ids")]
	public List<long>? ProjectIds { get; set; }

	[JsonPropertyName("user_ids")]
	public List<long>? UserIds { get; set; }

	[JsonPropertyName("tag_ids")]
	public List<long>? TagIds { get; set; }

	[JsonPropertyName("task_ids")]
	public string? TaskIds { get; set; }

	[JsonPropertyName("time_entry_ids")]
	public List<long>? TimeEntryIds { get; set; }

	[JsonPropertyName("description")]
	public string? Description { get; set; }

	[JsonPropertyName("without_description")]
	public bool? WithoutDescription { get; set; }
}
