using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

// https://github.com/toggl/toggl_api_docs/blob/master/reports/project.md

public class ProjectReportDashboard : Item
{
	/// <summary>
	/// Name of project
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Total time tracked for this project (ms)
	/// </summary>
	[JsonPropertyName("duration")]
	public long? DurationMs { get; set; }

	/// <summary>
	/// Total time without tasks for this project (ms)
	/// </summary>
	[JsonPropertyName("duration_without_task")]
	public long? DurationWithoutTaskMs { get; set; }

	/// <summary>
	/// Billable time tracked for this project (ms)
	/// </summary>
	[JsonPropertyName("billable_duration")]
	public long? BillableDurationMs { get; set; }

	/// <summary>
	/// Sum of earnings
	/// </summary>
	[JsonPropertyName("billable_amount")]
	public long? BillableAmount { get; set; }

	/// <summary>
	/// Total number of tasks in this project
	/// </summary>
	[JsonPropertyName("tasks_count")]
	public long? TasksCount { get; set; }

	/// <summary>
	/// Currency of billable_amount
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// Estimate of how long project would take in seconds
	/// </summary>
	[JsonPropertyName("estimated_seconds")]
	public long? EstimatedSeconds { get; set; }

	/// <summary>
	/// Estimate of how long project would take in seconds for tasks
	/// </summary>
	[JsonPropertyName("task_estimated_seconds")]
	public long? TaskEstimatedSeconds { get; set; }

	/// <summary>
	/// Flag indicating if total of task time estimations (true) should be used as grand-estimate, for false value estimated_seconds should be used instead
	/// </summary>
	[JsonPropertyName("use_task_estimated_seconds")]
	public bool? UseTaskEstimatedSeconds { get; set; }
}
