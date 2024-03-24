using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/me#put-me
/// </summary>
public class MeUpdateDto
{
	/// <summary>
	/// User's first day of the week. Sunday: 0, Monday:1, etc.
	/// </summary>
	[JsonPropertyName("beginning_of_week")]
	public required int BeginningOfWeek { get; set; }

	/// <summary>
	/// User's country ID
	/// </summary>
	[JsonPropertyName("country_id")]
	public required int CountryId { get; set; }

	/// <summary>
	/// User's current password (used to change the current password)
	/// </summary>
	[JsonPropertyName("current_password")]
	public required string CurrentPassword { get; set; }

	/// <summary>
	/// User's default workspace ID
	/// </summary>
	[JsonPropertyName("default_workspace_id")]
	public required int DefaultWorkspaceId { get; set; }

	/// <summary>
	/// User's email address
	/// </summary>
	[JsonPropertyName("email")]
	public required string Email { get; set; }

	/// <summary>
	/// User's full name
	/// </summary>
	[JsonPropertyName("fullname")]
	public required string FullName { get; set; }

	/// <summary>
	/// User's new password (current one must also be provided)
	/// </summary>
	[JsonPropertyName("password")]
	public required string Password { get; set; }

	/// <summary>
	/// User's timezone
	/// </summary>
	[JsonPropertyName("timezone")]
	public required string Timezone { get; set; }
}