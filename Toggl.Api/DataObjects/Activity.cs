using Newtonsoft.Json;
using System;

namespace Toggl.Api.DataObjects
{
	public class Activity : BaseDataObject
	{
		[JsonProperty(PropertyName = "user_id")]
		public long UserId { get; set; }

		[JsonProperty(PropertyName = "project_id")]
		public long ProjectId { get; set; }

		[JsonProperty(PropertyName = "duration")]
		public int Duration { get; set; }

		[JsonProperty(PropertyName = "description")]
		public string? Description { get; set; }

		[JsonProperty(PropertyName = "stop")]
		public DateTime Stop { get; set; }
	}
}
