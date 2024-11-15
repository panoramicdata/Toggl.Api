using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// The user
/// </summary>
public class GroupUser : NamedItem
{
	/// <summary>
	/// The users
	/// </summary>
	[JsonPropertyName("user_id")]
	public required int UserId { get; set; }

	/// <summary>
	/// The users
	/// </summary>
	[JsonPropertyName("avatar_url")]
	public required Uri AvatarUrl { get; set; }

	/// <summary>
	/// Whether the user has joined
	/// </summary>
	[JsonPropertyName("joined")]
	public required bool Joined { get; set; }

	/// <summary>
	/// Whether the GroupUser is inactive.
	/// </summary>
	[JsonPropertyName("inactive")]
	public required bool IsInactive { get; set; }
}
