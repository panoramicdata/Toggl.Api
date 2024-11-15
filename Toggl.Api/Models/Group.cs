using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public class Group : NamedItem
{
	/// <summary>
	/// The group id
	/// </summary>
	[JsonPropertyName("group_id")]
	public required int GroupId { get; set; }

	/// <summary>
	/// The group id
	/// </summary>
	[JsonPropertyName("at")]
	public required DateTimeOffset Created { get; set; }

	/// <summary>
	/// The workspace ids
	/// </summary>
	[JsonPropertyName("workspaces")]
	public required ICollection<int> Workspaces { get; set; }

	/// <summary>
	/// The users
	/// </summary>
	[JsonPropertyName("users")]
	public required ICollection<GroupUser> Users { get; set; }
}
