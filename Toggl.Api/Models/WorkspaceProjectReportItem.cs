using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A project user report response
/// </summary>
public class WorkspaceProjectReportItem
{
	/// <summary>
	/// The billable seconds
	/// </summary>
	[JsonPropertyName("billable_seconds")]
	public required int BillableSeconds { get; set; }

	/// <summary>
	/// The project id
	/// </summary>
	[JsonPropertyName("project_id")]
	public required int ProjectId { get; set; }

	/// <summary>
	/// The tracked seconds
	/// </summary>
	[JsonPropertyName("tracked_seconds")]
	public required int TrackedSeconds { get; set; }

	/// <summary>
	/// The user id
	/// </summary>
	[JsonPropertyName("user_id")]
	public required int UserId { get; set; }
}