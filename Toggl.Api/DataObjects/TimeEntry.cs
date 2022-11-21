using Newtonsoft.Json;
using System.Collections.Generic;

namespace Toggl.Api.DataObjects;

public class TimeEntry : BaseDataObject
{
	/// <summary>
	/// The ID
	/// </summary>
	[JsonProperty(PropertyName = "id")]
	public long? Id { get; set; }

	/// <summary>
	/// The workspace ID
	/// </summary>
	[JsonProperty(PropertyName = "wid")]
	public long? WorkspaceId { get; set; }

	/// <summary>
	/// The Project ID
	/// </summary>
	[JsonProperty(PropertyName = "pid")]
	public long? ProjectId { get; set; }

	/// <summary>
	/// The Task ID
	/// </summary>
	[JsonProperty(PropertyName = "tid")]
	public long? TaskId { get; set; }

	/// <summary>
	/// Whether this item is billable
	/// </summary>
	[JsonProperty(PropertyName = "billable")]
	public bool? IsBillable { get; set; }

	/// <summary>
	/// The Start time
	/// </summary>
	[JsonProperty(PropertyName = "start")]
	public string? Start { get; set; }

	/// <summary>
	/// The Stop time
	/// </summary>
	[JsonProperty(PropertyName = "stop")]
	public string? Stop { get; set; }

	/// <summary>
	/// The duration in seconds
	/// </summary>
	[JsonProperty(PropertyName = "duration")]
	public long? Duration { get; set; }

	/// <summary>
	/// The Description
	/// </summary>
	[JsonProperty(PropertyName = "description")]
	public string? Description { get; set; }

	/// <summary>
	/// The tags
	/// </summary>
	[JsonProperty(PropertyName = "tags")]
	public List<string>? TagNames { get; set; }

	/// <summary>
	/// When it was last updated
	/// </summary>
	[JsonProperty(PropertyName = "at")]
	public string? UpdatedOn { get; set; }

	/// <summary>
	/// When it was created
	/// </summary>
	[JsonProperty(PropertyName = "created_at")]
	public string? CreatedOn { get; set; }

	[JsonProperty(PropertyName = "task")]
	public string? TaskName { get; set; }

	[JsonProperty(PropertyName = "created_with")]
	public string? CreatedWith { get; set; }

	[JsonProperty(PropertyName = "duronly")]
	public bool? ShowDurationOnly { get; set; }

	public override string ToString() => string.Format("Id: {0}, Start: {1}, Stop: {2}, TaskId: {3}", Id, Start, Stop, TaskId);
}