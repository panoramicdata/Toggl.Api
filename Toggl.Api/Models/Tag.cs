using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public class Tag : NamedIdentifiedItem
{
	/// <summary>
	/// The workspace id
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public int WorkspaceId { get; set; }

	/// <summary>
	/// The workspace id
	/// </summary>
	[JsonPropertyName("at")]
	public DateTimeOffset Created { get; set; }

	/// <summary>
	/// The creator id
	/// </summary>
	[JsonPropertyName("creator_id")]
	public int CreatorId { get; set; }
}
