// Ignore Spelling: Admins

using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#workspaces
/// </summary>
public class Workspace : NamedIdentifiedItem
{
	/// <summary>
	/// Current user is workspace admin
	/// </summary>
	[JsonPropertyName("admin")]
	public required bool IsAdmin { get; set; }

	/// <summary>
	/// deprecated
	/// </summary>
	[JsonPropertyName("api_token")]
	public required string ApiToken { get; set; } = string.Empty;

	/// <summary>
	/// Workspace on Premium subscription
	/// </summary>
	[JsonPropertyName("business_ws")]
	public required bool IsBusinessWorkspace { get; set; }

	/// <summary>
	/// CSV upload data
	/// </summary>
	[JsonPropertyName("csv_upload")]
	public required CsvUploadData CsvUpload { get; set; }

	/// <summary>
	/// Default currency, premium feature, optional, only for existing WS, will be 'USD' initially
	/// </summary>
	[JsonPropertyName("default_currency")]
	public required string DefaultCurrency { get; set; }

	/// <summary>
	/// The default hourly rate, premium feature, optional, only for existing WS, will be 0.0 initially
	/// </summary>
	[JsonPropertyName("default_hourly_rate")]
	public required double? DefaultHourlyRate { get; set; }

	/// <summary>
	/// Whether to hide start and end times
	/// </summary>
	[JsonPropertyName("hide_start_end_times")]
	public required bool HideStartEndTimes { get; set; }

	/// <summary>
	/// Calendar integration enabled
	/// </summary>
	[JsonPropertyName("ical_enabled")]
	public required bool IsIcalEnabled { get; set; }

	/// <summary>
	/// URL of calendar
	/// </summary>
	[JsonPropertyName("ical_url")]
	public required Uri? IcalUrl { get; set; }

	/// <summary>
	/// Creation date
	/// </summary>
	[JsonPropertyName("at")]
	public required DateTimeOffset Created { get; set; }

	/// <summary>
	/// Last modification of data in the workspace
	/// </summary>
	[JsonPropertyName("last_modified")]
	public required DateTimeOffset? LastModified { get; set; }

	/// <summary>
	/// URL of workspace logo
	/// </summary>
	[JsonPropertyName("logo_url")]
	public required Uri LogoUrl { get; set; }

	/// <summary>
	/// How far back free workspaces can access data.
	/// </summary>
	[JsonPropertyName("max_data_retention_days")]
	public int? MaxDataRetentionDays { get; set; }

	/// <summary>
	/// Only admins will be able to create projects, optional, only for existing WS, will be false initially
	/// </summary>
	[JsonPropertyName("only_admins_may_create_projects")]
	public required bool OnlyAdminsMayCreateProjects { get; set; }

	/// <summary>
	/// Only admins will be able to create tags, optional, only for existing WS, will be false initially
	/// </summary>
	[JsonPropertyName("only_admins_may_create_tags")]
	public required bool OnlyAdminsMayCreateTags { get; set; }

	/// <summary>
	/// Whether only admins will be able to see billable rates, premium feature, optional, only for existing WS. Will be false initially
	/// </summary>
	[JsonPropertyName("only_admins_see_billable_rates")]
	public required bool OnlyAdminsSeeBillableRates { get; set; }

	/// <summary>
	/// Only admins will be able to see the team dashboard, optional, only for existing WS, will be false initially
	/// </summary>
	[JsonPropertyName("only_admins_see_team_dashboard")]
	public required bool OnlyAdminsSeeTeamDashboard { get; set; }

	/// <summary>
	/// Identifier of the organization
	/// </summary>
	[JsonPropertyName("organization_id")]
	public required int OrganizationId { get; set; }

	/// <summary>
	/// Permissions list
	/// </summary>
	[JsonPropertyName("permissions")]
	public string? Permissions { get; set; }

	/// <summary>
	/// Workspace on Starter subscription
	/// </summary>
	[JsonPropertyName("premium")]
	public required bool IsPremium { get; set; }

	/// <summary>
	/// deprecated
	/// </summary>
	[JsonPropertyName("profile")]
	public required int Profile { get; set; }

	/// <summary>
	/// New projects billable by default
	/// </summary>
	[JsonPropertyName("projects_billable_by_default")]
	public required bool ProjectsBillableByDefault { get; set; }

	/// <summary>
	/// Workspace setting for default project visibility.
	/// </summary>
	[JsonPropertyName("projects_private_by_default")]
	public required bool ProjectsPrivateByDefault { get; set; }

	/// <summary>
	/// Workspace setting for default project billable.
	/// </summary>
	[JsonPropertyName("projects_enforce_billable")]
	public required bool ProjectsEnforceBillable { get; set; }

	/// <summary>
	/// Timestamp of last workspace rate update
	/// </summary>
	[JsonPropertyName("rate_last_updated")]
	public required DateTimeOffset? RateLastUpdated { get; set; }

	/// <summary>
	/// Whether reports should be collapsed by default, optional, only for existing WS, will be true initially
	/// </summary>
	[JsonPropertyName("reports_collapse")]
	public required bool ReportsCollapse { get; set; }

	/// <summary>
	/// Role of the current user in the workspace
	/// </summary>
	[JsonPropertyName("role")]
	public required string Role { get; set; }

	/// <summary>
	/// Default rounding, premium feature, optional, only for existing WS. 0 - nearest, 1 - round up, -1 - round down
	/// </summary>
	[JsonPropertyName("rounding")]
	public required int Rounding { get; set; }

	/// <summary>
	/// 	Default rounding in minutes, premium feature, optional, only for existing WS
	/// </summary>
	[JsonPropertyName("rounding_minutes")]
	public required int RoundingMinutes { get; set; }

	/// <summary>
	/// Timestamp of deletion
	/// </summary>
	[JsonPropertyName("server_deleted_at")]
	public required DateTimeOffset? ServerDeletedAt { get; set; }

	/// <summary>
	/// deprecated
	/// </summary>
	[JsonPropertyName("subscription")]
	public required object? Subscription { get; set; }

	/// <summary>
	/// Timestamp of suspension
	/// </summary>
	[JsonPropertyName("suspended_at")]
	public required DateTimeOffset? SuspendedAt { get; set; }

	/// <summary>
	/// Time entry constraints setting
	/// </summary>
	[JsonPropertyName("te_constraints")]
	public object? TimeEntryConstraints { get; set; }

	/// <summary>
	/// Working hours in minutes
	/// </summary>
	[JsonPropertyName("working_hours_in_minutes")]
	public required int? WorkingHoursInMinutes { get; set; }
}