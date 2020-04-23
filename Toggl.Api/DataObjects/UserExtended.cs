using System.Collections.Generic;
using Newtonsoft.Json;

namespace Toggl.Api.DataObjects
{
	/// <summary>
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/users.md#users
	/// </summary>
	public class UserExtended : User
	{
		[JsonProperty(PropertyName = "time_entries")]
		public List<TimeEntry> TimeEntries { get; set; }

		[JsonProperty(PropertyName = "projects")]
		public List<Project> Projects { get; set; }

		[JsonProperty(PropertyName = "tags")]
		public List<Tag> Tags { get; set; }

		[JsonProperty(PropertyName = "workspaces")]
		public List<Workspace> Workspaces { get; set; }

		[JsonProperty(PropertyName = "clients")]
		public List<Client> Clients { get; set; }
	}
}
