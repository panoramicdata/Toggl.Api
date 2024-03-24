using System.Text.Json.Serialization;
using System;

namespace Toggl.Api.Models;

/// <summary>
/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/users.md#users
/// </summary>
public class User : IdentifiedItem
{
	[JsonPropertyName("api_token")]
	public string? ApiToken { get; set; }

	[JsonPropertyName("default_wid")]
	public long? DefaultWorkspaceId { get; set; }

	[JsonPropertyName("email")]
	public string? Email { get; set; }

	[JsonPropertyName("fullname")]
	public string? FullName { get; set; }

	[JsonPropertyName("jquery_timeofday_format")]
	public string? JQueryTimeofdayFormat { get; set; }

	[JsonPropertyName("jquery_date_format")]
	public string? JqueryDateFormat { get; set; }

	[JsonPropertyName("timeofday_format")]
	public string? TimeOfDayFormat { get; set; }

	[JsonPropertyName("date_format")]
	public string? DateFormat { get; set; }

	[JsonPropertyName("store_start_and_stop_time")]
	public bool? IsStartStopTime { get; set; }

	[JsonPropertyName("beginning_of_week")]
	public int? BeginningOfWeek { get; set; }

	[JsonPropertyName("language")]
	public string? Language { get; set; }

	[JsonPropertyName("image_url")]
	public string? ImageUrl { get; set; }

	[JsonPropertyName("sidebar_piechart")]
	public bool? IsSidebarPiechart { get; set; }

	[JsonPropertyName("at")]
	public DateTime? UpdatedOn { get; set; }

	[JsonPropertyName("created_at")]
	public DateTime? CreatedOn { get; set; }

	[JsonPropertyName("retention")]
	public int? Retention { get; set; }

	[JsonPropertyName("record_timeline")]
	public bool? IsRecordTimeline { get; set; }

	[JsonPropertyName("render_timeline")]
	public bool? IsRenderTimeline { get; set; }

	[JsonPropertyName("timeline_enabled")]
	public bool? IsTimelineEnabled { get; set; }

	[JsonPropertyName("timeline_experiment")]
	public bool? IsTimelineExperiment { get; set; }

	[JsonPropertyName("manual_mode")]
	public bool? IsManualMode { get; set; }

	[JsonPropertyName("new_blog_post")]
	public NewBlogPost? NewBlogPost { get; set; }

	[JsonPropertyName("should_upgrade")]
	public bool? IsShouldUpgrade { get; set; }

	[JsonPropertyName("show_offer")]
	public bool? IsShowOffer { get; set; }

	[JsonPropertyName("share_experiment")]
	public bool? IsShareExperiment { get; set; }

	[JsonPropertyName("achievements_enabled")]
	public bool? IsAchievementsEnabled { get; set; }

	[JsonPropertyName("timezone")]
	public string? Timezone { get; set; }

	[JsonPropertyName("openid_enabled")]
	public bool? IsOpenidEnabled { get; set; }

	[JsonPropertyName("send_product_emails")]
	public bool? IsSendProductEmails { get; set; }

	[JsonPropertyName("send_weekly_report")]
	public bool? IsSendWeeklyReport { get; set; }

	[JsonPropertyName("send_timer_notifications")]
	public bool? IsSendTimerNotifications { get; set; }
}
