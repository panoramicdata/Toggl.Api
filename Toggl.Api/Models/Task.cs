using System.Text.Json.Serialization;
using System;
using System.Globalization;

namespace Toggl.Api.Models;

/// <summary>
/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/tasks.md#tasks
/// </summary>
public class Task : IdentifiedItem
{
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	[JsonPropertyName("pid")]
	public long? ProjectId { get; set; }

	[JsonPropertyName("wid")]
	public long? WorkspaceId { get; set; }

	[JsonPropertyName("uid")]
	public long? UserId { get; set; }

	[JsonPropertyName("estimated_seconds")]
	public int? EstimatedSeconds { get; set; }

	[JsonPropertyName("is_active")]
	public bool? IsActive { get; set; }

	[JsonPropertyName("at")]
	public DateTime? UpdatedOn { get; set; }

	public override string ToString() => string.Format(CultureInfo.InvariantCulture, "Id: {0}, Name: {1}", Id, Name);
}