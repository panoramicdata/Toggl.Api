using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// DTO for patching groups (bulk operations)
/// https://engineering.toggl.com/docs/api/groups#patch-patch-group
/// </summary>
public class GroupPatchDto
{
	/// <summary>
	/// Operations to perform on the group
	/// </summary>
	[JsonPropertyName("op")]
	public required string Operation { get; set; }

	/// <summary>
	/// Path to the property to patch (e.g., "/users")
	/// </summary>
	[JsonPropertyName("path")]
	public required string Path { get; set; }

	/// <summary>
	/// Value to apply (array of IDs for add/remove operations)
	/// </summary>
	[JsonPropertyName("value")]
	public ICollection<long>? Value { get; set; }
}
