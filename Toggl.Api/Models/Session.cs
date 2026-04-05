using System.Text.Json.Serialization;
using System;

namespace Toggl.Api.Models;

/// <summary>
/// A session.
/// </summary>
public class Session : IdentifiedItem
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
	/// Whether to store start and stop time.
	/// </summary>
	[JsonPropertyName("store_start_and_stop_time")]
	public bool? IsStartStopTime { get; set; }

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
	/// The image URL.
	/// </summary>
	[JsonPropertyName("image_url")]
	public string ImageUrl { get; set; } = string.Empty;

	/// <summary>
	/// Whether to show sidebar pie chart.
	/// </summary>
	[JsonPropertyName("sidebar_piechart")]
	public bool? IsSidebarPiechart { get; set; }

	/// <summary>
	/// When last updated.
	/// </summary>
	[JsonPropertyName("at")]
	public DateTime? UpdatedOn { get; set; }

	/// <summary>
	/// When created.
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTime? CreatedOn { get; set; }

	/// <summary>
	/// The retention period.
	/// </summary>
	[JsonPropertyName("retention")]
	public int? Retention { get; set; }

	/// <summary>
	/// Whether to record timeline.
	/// </summary>
	[JsonPropertyName("record_timeline")]
	public bool? IsRecordTimeline { get; set; }

	/// <summary>
	/// Whether to render timeline.
	/// </summary>
	[JsonPropertyName("render_timeline")]
	public bool? IsRenderTimeline { get; set; }

	/// <summary>
	/// Whether timeline is enabled.
	/// </summary>
	[JsonPropertyName("timeline_enabled")]
	public bool? IsTimelineEnabled { get; set; }

	/// <summary>
	/// Whether timeline experiment is enabled.
	/// </summary>
	[JsonPropertyName("timeline_experiment")]
	public bool? IsTimelineExperiment { get; set; }

	/// <summary>
	/// Whether manual mode is enabled.
	/// </summary>
	[JsonPropertyName("manual_mode")]
	public bool? IsManualMode { get; set; }

	/// <summary>
	/// The new blog post.
	/// </summary>
	[JsonPropertyName("new_blog_post")]
	public NewBlogPost? NewBlogPost { get; set; }

	/// <summary>
	/// Whether should upgrade.
	/// </summary>
	[JsonPropertyName("should_upgrade")]
	public bool? IsShouldUpgrade { get; set; }

	/// <summary>
	/// Whether to show offer.
	/// </summary>
	[JsonPropertyName("show_offer")]
	public bool? IsShowOffer { get; set; }

	/// <summary>
	/// Whether share experiment is enabled.
	/// </summary>
	[JsonPropertyName("share_experiment")]
	public bool? IsShareExperiment { get; set; }

	/// <summary>
	/// Whether achievements are enabled.
	/// </summary>
	[JsonPropertyName("achievements_enabled")]
	public bool? IsAchievementsEnabled { get; set; }

	/// <summary>
	/// The timezone.
	/// </summary>
	[JsonPropertyName("timezone")]
	public string Timezone { get; set; } = string.Empty;

	/// <summary>
	/// Whether OpenID is enabled.
	/// </summary>
	[JsonPropertyName("openid_enabled")]
	public bool? IsOpenidEnabled { get; set; }

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
}