using Newtonsoft.Json;
using Toggl.Api.DataObjects;

namespace Toggl.Api.QueryObjects
{
	public class ProjectDashboardParams : BaseDataObject
	{
		/// <summary>
		/// The developer's details
		/// </summary>
		[JsonProperty(PropertyName = "user_agent")]
		public string? UserAgent { get; set; }

		/// <summary>
		/// The workspace whose data you want to access
		/// </summary>
		[JsonProperty(PropertyName = "workspace_id")]
		public long WorkspaceId { get; set; }

		/// <summary>
		/// The project whose data you want to access
		/// </summary>
		[JsonProperty(PropertyName = "project_id")]
		public long ProjectId { get; set; }

		/// <summary>
		/// name/assignee/duration/billable_amount/estimated_seconds
		/// </summary>
		[JsonProperty(PropertyName = "order_field")]
		public string OrderField { get; set; } = "name";

		/// <summary>
		/// on/off, on for descending and off for ascending order
		/// </summary>
		[JsonProperty(PropertyName = "order_desc")]
		public string OrderDesc { get; set; } = "on";
	}
}
