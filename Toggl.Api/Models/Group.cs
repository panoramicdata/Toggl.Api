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
	/// Timestamp of last update
	/// </summary>
	[JsonPropertyName("at")]
	public required DateTimeOffset LastModified { get; set; }

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

	/// <summary>
	/// Total count of items in the response (only populated when listing)
	/// </summary>
	[JsonPropertyName("total_count")]
	public int? TotalCount { get; set; }
}