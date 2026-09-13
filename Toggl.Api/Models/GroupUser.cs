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
	public int? UserId { get; set; }

	/// <summary>
	/// The users
	/// </summary>
	[JsonPropertyName("avatar_url")]
	public Uri? AvatarUrl { get; set; }

	/// <summary>
	/// Whether the user has joined
	/// </summary>
	[JsonPropertyName("joined")]
	public bool? Joined { get; set; }

	/// <summary>
	/// Whether the GroupUser is inactive.
	/// </summary>
	[JsonPropertyName("inactive")]
	public bool? IsInactive { get; set; }
}
