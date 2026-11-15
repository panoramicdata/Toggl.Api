using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A session.
/// </summary>
public class Session : UserSettingsBase
{
	/// <summary>
	/// The API token.
	/// </summary>
	[JsonPropertyName("api_token")]
	public string ApiToken { get; set; } = string.Empty;

	/// <summary>
	/// The default workspace ID.
	/// </summary>
	[JsonPropertyName("default_wid")]
	public int? DefaultWorkspaceId { get; set; }

	/// <summary>
	/// The email address.
	/// </summary>
	[JsonPropertyName("email")]
	public string Email { get; set; } = string.Empty;

	/// <summary>
	/// The full name.
	/// </summary>
	[JsonPropertyName("fullname")]
	public string FullName { get; set; } = string.Empty;

	/// <summary>
	/// The beginning of the week.
	/// </summary>
	[JsonPropertyName("beginning_of_week")]
	public int BeginningOfWeek { get; set; }

	/// <summary>
	/// The language.
	/// </summary>
	[JsonPropertyName("language")]
	public string Language { get; set; } = string.Empty;

	/// <summary>
	/// The time of day format.
	/// </summary>
	[JsonPropertyName("timeofday_format")]
	public string TimeOfDayFormat { get; set; } = string.Empty;

	/// <summary>
	/// The date format.
	/// </summary>
	[JsonPropertyName("date_format")]
	public string DateFormat { get; set; } = string.Empty;

	/// <summary>
	/// The jQuery time of day format.
	/// </summary>
	[JsonPropertyName("jquery_timeofday_format")]
	public string JQueryTimeofdayFormat { get; set; } = string.Empty;

	/// <summary>
	/// The jQuery date format.
	/// </summary>
	[JsonPropertyName("jquery_date_format")]
	public string JqueryDateFormat { get; set; } = string.Empty;

	/// <summary>
	/// The image URL.
	/// </summary>
	[JsonPropertyName("image_url")]
	public string ImageUrl { get; set; } = string.Empty;

	/// <summary>
	/// The timezone.
	/// </summary>
	[JsonPropertyName("timezone")]
	public string Timezone { get; set; } = string.Empty;
}