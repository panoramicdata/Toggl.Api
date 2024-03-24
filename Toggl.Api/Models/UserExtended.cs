using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Toggl.Api.Models;

/// <summary>
/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/users.md#users
/// </summary>
public class UserExtended : User
{
	[JsonPropertyName("time_entries")]
	public List<TimeEntry>? TimeEntries { get; set; }

	[JsonPropertyName("projects")]
	public List<Project>? Projects { get; set; }

	[JsonPropertyName("tags")]
	public List<Tag>? Tags { get; set; }

	[JsonPropertyName("workspaces")]
	public List<Workspace>? Workspaces { get; set; }

	[JsonPropertyName("clients")]
	public List<Client>? Clients { get; set; }
}
