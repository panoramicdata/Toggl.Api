using Newtonsoft.Json;

namespace Toggl.Api.DataObjects
{
	// https://github.com/toggl/toggl_api_docs/blob/master/reports/project.md

	public class ProjectReportDashboard : BaseDataObject
	{
		/// <summary>
		/// Name of project
		/// </summary>
		[JsonProperty(PropertyName = "name")]
		public string? Name { get; set; }

		/// <summary>
		/// Total time tracked for this project (ms)
		/// </summary>
		[JsonProperty(PropertyName = "duration")]
		public long? DurationMs { get; set; }

		/// <summary>
		/// Total time without tasks for this project (ms)
		/// </summary>
		[JsonProperty(PropertyName = "duration_without_task")]
		public long? DurationWithoutTaskMs { get; set; }

		/// <summary>
		/// Billable time tracked for this project (ms)
		/// </summary>
		[JsonProperty(PropertyName = "billable_duration")]
		public long? BillableDurationMs { get; set; }

		/// <summary>
		/// Sum of earnings
		/// </summary>
		[JsonProperty(PropertyName = "billable_amount")]
		public long? BillableAmount { get; set; }

		/// <summary>
		/// Total number of tasks in this project
		/// </summary>
		[JsonProperty(PropertyName = "tasks_count")]
		public int? TasksCount { get; set; }

		/// <summary>
		/// Currency of billable_amount
		/// </summary>
		[JsonProperty(PropertyName = "currency")]
		public string? Currency { get; set; }

		/// <summary>
		/// Estimate of how long project would take in seconds
		/// </summary>
		[JsonProperty(PropertyName = "estimated_seconds")]
		public long? EstimatedSeconds { get; set; }

		/// <summary>
		/// Estimate of how long project would take in seconds for tasks
		/// </summary>
		[JsonProperty(PropertyName = "task_estimated_seconds")]
		public long? TaskEstimatedSeconds { get; set; }

		/// <summary>
		/// Flag indicating if total of task time estimations (true) should be used as grand-estimate, for false value estimated_seconds should be used instead
		/// </summary>
		[JsonProperty(PropertyName = "use_task_estimated_seconds")]
		public bool? UseTaskEstimatedSeconds { get; set; }
	}
}
