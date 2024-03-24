using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A Project User
/// </summary>
public class ProjectUser : IdentifiedItem
{
	[JsonPropertyName("pid")]
	public long ProjectId { get; set; }

	[JsonPropertyName("wid")]
	public long WorkspaceId { get; set; }

	[JsonPropertyName("uid")]
	public long UserId { get; set; }

	[JsonPropertyName("manager")]
	public bool IsManager { get; set; }

	[JsonPropertyName("at")]
	public DateTime? UpdatedOn { get; set; }

	/// <summary>
	/// rate: hourly rate of the project (float, not required, premium functionality)
	/// </summary>
	[JsonPropertyName("rate")]
	public double? HourlyRate { get; set; }
}
