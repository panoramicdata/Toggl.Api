using System.Collections.Generic;

namespace Toggl.Api.Models;

using System.Globalization;
using System.Text.Json.Serialization;

public class ReportTimeEntry : IdentifiedItem
{
	[JsonPropertyName("pid")]
	public long? ProjectId { get; set; }

	[JsonPropertyName("project")]
	public string? ProjectName { get; set; }

	[JsonPropertyName("client")]
	public string? ClientName { get; set; }

	[JsonPropertyName("tid")]
	public long? TaskId { get; set; }

	[JsonPropertyName("task")]
	public string? TaskName { get; set; }

	[JsonPropertyName("uid")]
	public long? UserId { get; set; }

	[JsonPropertyName("user")]
	public string? UserName { get; set; } = null;

	[JsonPropertyName("description")]
	public string? Description { get; set; }

	[JsonPropertyName("start")]
	public string? Start { get; set; }

	[JsonPropertyName("end")]
	public string? Stop { get; set; }

	[JsonPropertyName("dur")]
	public long? Duration { get; set; }

	[JsonPropertyName("updated")]
	public string? Updated { get; set; }

	[JsonPropertyName("use_stop")]
	public bool? UseStop { get; set; }

	[JsonPropertyName("is_billable")]
	public bool? IsBillable { get; set; }

	[JsonPropertyName("billable")]
	public long? Billable { get; set; }

	[JsonPropertyName("tags")]
	public List<string>? TagNames { get; set; }

	public override string ToString() => string.Format(CultureInfo.InvariantCulture, "Id: {0}, Start: {1}, Stop: {2}, TaskId: {3}", Id, Start, Stop, TaskId);
}