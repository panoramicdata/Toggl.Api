using System;
using Newtonsoft.Json;

namespace Toggl.Api.DataObjects
{
	/// <summary>
	/// 
	/// </summary>
	public class ProjectUser : BaseDataObject
	{
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "project_id")]
		public int ProjectId { get; set; }

		[JsonProperty(PropertyName = "workspace_id")]
		public int WorkspaceId { get; set; }

		[JsonProperty(PropertyName = "user_id")]
		public int UserId { get; set; }

		[JsonProperty(PropertyName = "manager")]
		public bool IsManager { get; set; }

		[JsonProperty(PropertyName = "at")]
		public DateTime? UpdatedOn { get; set; }

		/// <summary>
		/// rate: hourly rate of the project (float, not required, premium functionality)
		/// </summary>
		[JsonProperty(PropertyName = "rate")]
		public double? HourlyRate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty(PropertyName = "labour_cost")]
		public double? LabourCost { get; set; }
	}
}
