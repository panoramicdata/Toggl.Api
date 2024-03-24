using System.Collections.Generic;

namespace Toggl.Api.Models;

using System.Text.Json.Serialization;
using System.Globalization;

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
	//[JsonConverter(typeof(IsoDateTimeConverter))]
	//public DateTime? Start { get; set; }
	public string? Start { get; set; }

	[JsonPropertyName("end")]
	//[JsonConverter(typeof(IsoDateTimeConverter))]
	//public DateTime? Stop { get; set; }
	public string? Stop { get; set; } = null;

	[JsonPropertyName("dur")]
	public long? Duration { get; set; }

	[JsonPropertyName("updated")]
	//[JsonConverter(typeof(IsoDateTimeConverter))]
	//public DateTime? Stop { get; set; }
	public string? Updated { get; set; } = null;

	[JsonPropertyName("use_stop")]
	public bool? UseStop { get; set; }

	[JsonPropertyName("is_billable")]
	public bool? IsBillable { get; set; }

	[JsonPropertyName("billable")]
	public long? Billable { get; set; }

	[JsonPropertyName("tags")]
	public List<string>? TagNames { get; set; } = null;

	public override string ToString() => string.Format(CultureInfo.InvariantCulture, "Id: {0}, Start: {1}, Stop: {2}, TaskId: {3}", Id, Start, Stop, TaskId);
}