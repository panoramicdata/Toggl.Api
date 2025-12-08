using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// User preferences including alpha features
/// https://engineering.toggl.com/docs/api/preferences
/// </summary>
public class UserPreferences
{
	/// <summary>
	/// Alpha features configuration
	/// </summary>
	[JsonPropertyName("alpha_features")]
	public ICollection<AlphaFeature>? AlphaFeatures { get; set; }

	/// <summary>
	/// Whether activity timeline should be recorded
	/// </summary>
	[JsonPropertyName("activity_timeline_display_activity")]
	public bool? ActivityTimelineDisplayActivity { get; set; }

	/// <summary>
	/// Whether to auto-detect idle time
	/// </summary>
	[JsonPropertyName("autodetect_idle")]
	public bool? AutodetectIdle { get; set; }

	/// <summary>
	/// Whether auto-tracker is enabled
	/// </summary>
	[JsonPropertyName("autotrack")]
	public bool? Autotrack { get; set; }

	/// <summary>
	/// Beginning of the week (0 = Sunday, 1 = Monday, etc.)
	/// </summary>
	[JsonPropertyName("beginning_of_week")]
	public int? BeginningOfWeek { get; set; }

	/// <summary>
	/// Whether cells should be swapped
	/// </summary>
	[JsonPropertyName("cells_swapped")]
	public bool? CellsSwapped { get; set; }

	/// <summary>
	/// Whether collapse time entries is enabled
	/// </summary>
	[JsonPropertyName("collapse_time_entries")]
	public bool? CollapseTimeEntries { get; set; }

	/// <summary>
	/// Date format (e.g., "MM/DD/YYYY")
	/// </summary>
	[JsonPropertyName("date_format")]
	public string? DateFormat { get; set; }

	/// <summary>
	/// Whether decimal hours format is used
	/// </summary>
	[JsonPropertyName("decimal_hours")]
	public bool? DecimalHours { get; set; }

	/// <summary>
	/// Duration format (classic, improved, decimal)
	/// </summary>
	[JsonPropertyName("duration_format")]
	public string? DurationFormat { get; set; }

	/// <summary>
	/// Duration format (legacy, use duration_format instead)
	/// </summary>
	[JsonPropertyName("duration_format_on_timer_duration_field")]
	public bool? DurationFormatOnTimerDurationField { get; set; }

	/// <summary>
	/// Whether first seen modal was shown
	/// </summary>
	[JsonPropertyName("first_seen")]
	public DateTimeOffset? FirstSeen { get; set; }

	/// <summary>
	/// Whether focus mode is enabled
	/// </summary>
	[JsonPropertyName("focus_app_on_time_entry_start")]
	public bool? FocusAppOnTimeEntryStart { get; set; }

	/// <summary>
	/// Focus mode time setting
	/// </summary>
	[JsonPropertyName("focus_mode_time")]
	public string? FocusModeTime { get; set; }

	/// <summary>
	/// Whether haptic feedback is enabled
	/// </summary>
	[JsonPropertyName("haptic_feedback_enabled")]
	public bool? HapticFeedbackEnabled { get; set; }

	/// <summary>
	/// Whether idle detection is enabled
	/// </summary>
	[JsonPropertyName("idle_detection")]
	public bool? IdleDetection { get; set; }

	/// <summary>
	/// Whether keyboard shortcuts are enabled
	/// </summary>
	[JsonPropertyName("keyboard_increment_timer_value")]
	public int? KeyboardIncrementTimerValue { get; set; }

	/// <summary>
	/// Whether manualMode is enabled
	/// </summary>
	[JsonPropertyName("manual_mode")]
	public bool? ManualMode { get; set; }

	/// <summary>
	/// Whether manualMode should be shown on mobile
	/// </summary>
	[JsonPropertyName("manual_mode_on_mobile")]
	public bool? ManualModeOnMobile { get; set; }

	/// <summary>
	/// Whether modern tips should be shown
	/// </summary>
	[JsonPropertyName("modern_tips")]
	public ICollection<string>? ModernTips { get; set; }

	/// <summary>
	/// Whether Pomodoro mode is enabled
	/// </summary>
	[JsonPropertyName("pomodoro")]
	public bool? Pomodoro { get; set; }

	/// <summary>
	/// Pomodoro break length in minutes
	/// </summary>
	[JsonPropertyName("pomodoro_break")]
	public int? PomodoroBreak { get; set; }

	/// <summary>
	/// Pomodoro interval in minutes
	/// </summary>
	[JsonPropertyName("pomodoro_interval")]
	public int? PomodoroInterval { get; set; }

	/// <summary>
	/// Whether offline mode is enabled
	/// </summary>
	[JsonPropertyName("offline_mode")]
	public bool? OfflineMode { get; set; }

	/// <summary>
	/// Whether record timeline is enabled
	/// </summary>
	[JsonPropertyName("record_timeline")]
	public bool? RecordTimeline { get; set; }

	/// <summary>
	/// Whether reminders are enabled
	/// </summary>
	[JsonPropertyName("reminder")]
	public bool? Reminder { get; set; }

	/// <summary>
	/// Reminder days
	/// </summary>
	[JsonPropertyName("reminder_days")]
	public string? ReminderDays { get; set; }

	/// <summary>
	/// Reminder interval in minutes
	/// </summary>
	[JsonPropertyName("reminder_interval")]
	public int? ReminderInterval { get; set; }

	/// <summary>
	/// Reminder period end time
	/// </summary>
	[JsonPropertyName("reminder_period_end")]
	public string? ReminderPeriodEnd { get; set; }

	/// <summary>
	/// Reminder period start time
	/// </summary>
	[JsonPropertyName("reminder_period_start")]
	public string? ReminderPeriodStart { get; set; }

	/// <summary>
	/// Whether running time entry is shown on desktop
	/// </summary>
	[JsonPropertyName("show_time_in_title")]
	public bool? ShowTimeInTitle { get; set; }

	/// <summary>
	/// Whether stack time entries is enabled
	/// </summary>
	[JsonPropertyName("stack_time_entries")]
	public bool? StackTimeEntries { get; set; }

	/// <summary>
	/// Start automatically on login
	/// </summary>
	[JsonPropertyName("start_automatically")]
	public bool? StartAutomatically { get; set; }

	/// <summary>
	/// Stop on sleep
	/// </summary>
	[JsonPropertyName("stop_on_sleep")]
	public bool? StopOnSleep { get; set; }

	/// <summary>
	/// Stop on shutdown
	/// </summary>
	[JsonPropertyName("stop_on_shutdown")]
	public bool? StopOnShutdown { get; set; }

	/// <summary>
	/// Time of day format (H:mm or h:mm A)
	/// </summary>
	[JsonPropertyName("timeofday_format")]
	public string? TimeOfDayFormat { get; set; }

	/// <summary>
	/// Whether ToS accept is needed
	/// </summary>
	[JsonPropertyName("tos_accepted")]
	public bool? TosAccepted { get; set; }

	/// <summary>
	/// Whether window visible
	/// </summary>
	[JsonPropertyName("window_visible")]
	public bool? WindowVisible { get; set; }
}
