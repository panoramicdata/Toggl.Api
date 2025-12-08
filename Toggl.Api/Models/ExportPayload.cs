using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Payload for requesting a data export
/// https://engineering.toggl.com/docs/api/exports
/// </summary>
public class ExportPayload
{
	/// <summary>
	/// Whether to export clients
	/// </summary>
	[JsonPropertyName("clients")]
	public bool? Clients { get; set; }

	/// <summary>
	/// Whether to export projects
	/// </summary>
	[JsonPropertyName("projects")]
	public bool? Projects { get; set; }

	/// <summary>
	/// Whether to export tasks
	/// </summary>
	[JsonPropertyName("tasks")]
	public bool? Tasks { get; set; }

	/// <summary>
	/// Whether to export time entries
	/// </summary>
	[JsonPropertyName("time_entries")]
	public bool? TimeEntries { get; set; }

	/// <summary>
	/// Whether to export workspaces
	/// </summary>
	[JsonPropertyName("workspaces")]
	public bool? Workspaces { get; set; }
}
