using Newtonsoft.Json;
using System;

namespace Toggl.Api.DataObjects;

/// <summary>
/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/tasks.md#tasks
/// </summary>
public class Task : BaseDataObject
{
	[JsonProperty(PropertyName = "id")]
	public long? Id { get; set; }

	[JsonProperty(PropertyName = "name")]
	public string? Name { get; set; }

	[JsonProperty(PropertyName = "pid")]
	public long? ProjectId { get; set; }

	[JsonProperty(PropertyName = "wid")]
	public long? WorkspaceId { get; set; }

	[JsonProperty(PropertyName = "uid")]
	public long? UserId { get; set; }

	[JsonProperty(PropertyName = "estimated_seconds")]
	public int? EstimatedSeconds { get; set; }

	[JsonProperty(PropertyName = "is_active")]
	public bool? IsActive { get; set; }

	[JsonProperty(PropertyName = "at")]
	public DateTime? UpdatedOn { get; set; }

	public override string ToString() => string.Format("Id: {0}, Name: {1}", Id, Name);
}