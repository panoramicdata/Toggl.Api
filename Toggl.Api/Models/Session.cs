using System.Text.Json.Serialization;
using System;

namespace Toggl.Api.Models;

public class Session : IdentifiedItem
{
	[JsonPropertyName("api_token")]
	public string ApiToken { get; set; } = string.Empty;

	[JsonPropertyName("default_wid")]
	public int? DefaultWorkspaceId { get; set; }

	[JsonPropertyName("email")]
	public string Email { get; set; } = string.Empty;

	[JsonPropertyName("fullname")]
	public string FullName { get; set; } = string.Empty;

	[JsonPropertyName("jquery_timeofday_format")]
	public string JQueryTimeofdayFormat { get; set; } = string.Empty;

	[JsonPropertyName("jquery_date_format")]
	public string JqueryDateFormat { get; set; } = string.Empty;

	[JsonPropertyName("timeofday_format")]
	public string TimeOfDayFormat { get; set; } = string.Empty;

	[JsonPropertyName("date_format")]
	public string DateFormat { get; set; } = string.Empty;

	[JsonPropertyName("store_start_and_stop_time")]
	public bool? IsStartStopTime { get; set; }

	[JsonPropertyName("beginning_of_week")]
	public int BeginningOfWeek { get; set; }

	[JsonPropertyName("language")]
	public string Language { get; set; } = string.Empty;

	[JsonPropertyName("image_url")]
	public string ImageUrl { get; set; } = string.Empty;

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
	public string Timezone { get; set; } = string.Empty;

	[JsonPropertyName("openid_enabled")]
	public bool? IsOpenidEnabled { get; set; }

	[JsonPropertyName("send_product_emails")]
	public bool? IsSendProductEmails { get; set; }

	[JsonPropertyName("send_weekly_report")]
	public bool? IsSendWeeklyReport { get; set; }

	[JsonPropertyName("send_timer_notifications")]
	public bool? IsSendTimerNotifications { get; set; }
}