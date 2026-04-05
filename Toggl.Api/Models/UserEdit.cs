using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/users.md#update-user-data
/// </summary>
public class UserEdit : Item
{
	/// <summary>
	/// The full name.
	/// </summary>
	[JsonPropertyName("fullname")]
	public string? FullName { get; set; }

	/// <summary>
	/// The email address.
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	/// <summary>
	/// Whether to send product emails.
	/// </summary>
	[JsonPropertyName("send_product_emails")]
	public bool? IsSendProductEmails { get; set; }

	/// <summary>
	/// Whether to send weekly report.
	/// </summary>
	[JsonPropertyName("send_weekly_report")]
	public bool? IsSendWeeklyReport { get; set; }

	/// <summary>
	/// Whether to send timer notifications.
	/// </summary>
	[JsonPropertyName("send_timer_notifications")]
	public bool? IsSendTimerNotifications { get; set; }

	/// <summary>
	/// Whether to store start and stop time.
	/// </summary>
	[JsonPropertyName("store_start_and_stop_time")]
	public bool? IsStartStopTime { get; set; }

	/// <summary>
	/// The beginning of the week.
	/// </summary>
	[JsonPropertyName("beginning_of_week")]
	public int? BeginningOfWeek { get; set; }

	/// <summary>
	/// The timezone.
	/// </summary>
	[JsonPropertyName("timezone")]
	public string? Timezone { get; set; }

	/// <summary>
	/// The time of day format.
	/// </summary>
	[JsonPropertyName("timeofday_format")]
	public string? TimeOfDayFormat { get; set; }

	/// <summary>
	/// The date format.
	/// </summary>
	[JsonPropertyName("date_format")]
	public string? DateFormat { get; set; }

	/// <summary>
	/// The current password.
	/// </summary>
	[JsonPropertyName("current_password")]
	public string? CurrentPassword { get; set; }

	/// <summary>
	/// The new password.
	/// </summary>
	[JsonPropertyName("password")]
	public string? Password { get; set; }
}