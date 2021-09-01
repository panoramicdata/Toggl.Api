using Newtonsoft.Json;
using System;

namespace Toggl.Api.DataObjects
{
	/// <summary>
	/// A Project User
	/// </summary>
	public class ProjectUser : BaseDataObject
	{
		[JsonProperty(PropertyName = "id")]
		public long Id { get; set; }

		[JsonProperty(PropertyName = "pid")]
		public long ProjectId { get; set; }

		[JsonProperty(PropertyName = "wid")]
		public long WorkspaceId { get; set; }

		[JsonProperty(PropertyName = "uid")]
		public long UserId { get; set; }

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
