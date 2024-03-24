using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/users.md#update-user-data
/// </summary>
public class UserEdit : Item
{
	[JsonPropertyName("fullname")]
	public string? FullName { get; set; }

	[JsonPropertyName("email")]
	public string? Email { get; set; }

	[JsonPropertyName("send_product_emails")]
	public bool? IsSendProductEmails { get; set; }

	[JsonPropertyName("send_weekly_report")]
	public bool? IsSendWeeklyReport { get; set; }

	[JsonPropertyName("send_timer_notifications")]
	public bool? IsSendTimerNotifications { get; set; }

	[JsonPropertyName("store_start_and_stop_time")]
	public bool? IsStartStopTime { get; set; }

	[JsonPropertyName("beginning_of_week")]
	public int? BeginningOfWeek { get; set; }

	[JsonPropertyName("timezone")]
	public string? Timezone { get; set; }

	[JsonPropertyName("timeofday_format")]
	public string? TimeOfDayFormat { get; set; }

	[JsonPropertyName("date_format")]
	public string? DateFormat { get; set; }

	[JsonPropertyName("current_password")]
	public string? CurrentPassword { get; set; }

	[JsonPropertyName("password")]
	public string? Password { get; set; }
}