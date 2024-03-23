using Newtonsoft.Json;
using System.Collections.Generic;
using Toggl.Api.Models;

namespace Toggl.Api.QueryObjects;

public class ReportParams : Item
{
	[JsonProperty(PropertyName = "user_agent")]
	public string? UserAgent { get; set; }

	[JsonProperty(PropertyName = "workspace_id")]
	public long? WorkspaceId { get; set; }

	[JsonProperty(PropertyName = "since")]
	public string? Since { get; set; }

	[JsonProperty(PropertyName = "until")]
	public string? Until { get; set; }

	[JsonProperty(PropertyName = "billable")]
	public string? Billable { get; set; }

	[JsonProperty(PropertyName = "client_ids")]
	public List<long>? ClientIds { get; set; }

	[JsonProperty(PropertyName = "project_ids")]
	public List<long>? ProjectIds { get; set; }

	[JsonProperty(PropertyName = "user_ids")]
	public List<long>? UserIds { get; set; }

	[JsonProperty(PropertyName = "tag_ids")]
	public List<long>? TagIds { get; set; }

	[JsonProperty(PropertyName = "task_ids")]
	public string? TaskIds { get; set; }

	[JsonProperty(PropertyName = "time_entry_ids")]
	public List<long>? TimeEntryIds { get; set; }

	[JsonProperty(PropertyName = "description")]
	public string? Description { get; set; }

	[JsonProperty(PropertyName = "without_description")]
	public bool? WithoutDescription { get; set; }
}
