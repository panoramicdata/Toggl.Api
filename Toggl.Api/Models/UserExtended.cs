using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Toggl.Api.Models;

/// <summary>
/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/users.md#users
/// </summary>
public class UserExtended : User
{
	/// <summary>
	/// The time entries.
	/// </summary>
	[JsonPropertyName("time_entries")]
	public List<TimeEntry>? TimeEntries { get; set; }

	/// <summary>
	/// The projects.
	/// </summary>
	[JsonPropertyName("projects")]
	public List<Project>? Projects { get; set; }

	/// <summary>
	/// The tags.
	/// </summary>
	[JsonPropertyName("tags")]
	public List<Tag>? Tags { get; set; }

	/// <summary>
	/// The workspaces.
	/// </summary>
	[JsonPropertyName("workspaces")]
	public List<Workspace>? Workspaces { get; set; }

	/// <summary>
	/// The clients.
	/// </summary>
	[JsonPropertyName("clients")]
	public List<Client>? Clients { get; set; }
}
