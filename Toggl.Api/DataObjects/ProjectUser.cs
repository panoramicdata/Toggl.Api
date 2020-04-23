using Newtonsoft.Json;
using System;

namespace Toggl.Api.DataObjects
{
	/// <summary>
	/// 
	/// </summary>
	public class ProjectUser : BaseDataObject
	{
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "pid")]
		public int ProjectId { get; set; }

		[JsonProperty(PropertyName = "wid")]
		public int WorkspaceId { get; set; }

		[JsonProperty(PropertyName = "uid")]
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
	}
}
