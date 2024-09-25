using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/workspaces#post-create-a-new-workspace
/// </summary>
public class WorkspaceCreationDto : NamedItem
{
	/// <summary>
	/// List of admins, optional
	/// </summary>
	[JsonPropertyName("admins")]
	public ICollection<int>? Admins { get; set; }

	/// <summary>
	/// Default currency, premium feature, optional, only for existing WS, will be 'USD' initially
	/// </summary>
	[JsonPropertyName("default_currency")]
	public required string DefaultCurrency { get; set; }

	/// <summary>
	/// The default hourly rate, premium feature, optional, only for existing WS, will be 0.0 initially
	/// </summary>
	[JsonPropertyName("default_hourly_rate")]
	public double? DefaultHourlyRate { get; set; }

	/// <summary>
	/// The subscription plan for the workspace, deprecated
	/// </summary>
	[JsonPropertyName("initial_pricing_plan")]
	public int InitialPricingPlan { get; set; }

	/// <summary>
	/// Only admins will be able to create projects, optional, only for existing WS, will be false initially
	/// </summary>
	[JsonPropertyName("only_admins_may_create_projects")]
	public bool? OnlyAdminsMayCreateProjects { get; set; }

	/// <summary>
	/// Only admins will be able to create tags, optional, only for existing WS, will be false initially
	/// </summary>
	[JsonPropertyName("only_admins_may_create_tags")]
	public bool? OnlyAdminsMayCreateTags { get; set; }

	/// <summary>
	/// Whether only admins will be able to see billable rates, premium feature, optional, only for existing WS. Will be false initially
	/// </summary>
	[JsonPropertyName("only_admins_see_billable_rates")]
	public bool? OnlyAdminsSeeBillableRates { get; set; }

	/// <summary>
	/// Only admins will be able to see the team dashboard, optional, only for existing WS, will be false initially
	/// </summary>
	[JsonPropertyName("only_admins_see_team_dashboard")]
	public bool? OnlyAdminsSeeTeamDashboard { get; set; }

	/// <summary>
	/// Whether projects will be set as billable by default, premium feature, optional, only for existing WS. Will be true initially
	/// </summary>
	[JsonPropertyName("projects_billable_by_default")]
	public bool? ProjectsBillableByDefault { get; set; }

	/// <summary>
	/// The rate change mode, premium feature, optional, only for existing WS. Can be "start-today", "override-current", "override-all"
	/// </summary>
	[JsonPropertyName("rate_change_mode")]
	public required WorkspaceRateChangeMode RateChangeMode { get; set; }

	/// <summary>
	/// Whether reports should be collapsed by default, optional, only for existing WS, will be true initially
	/// </summary>
	[JsonPropertyName("reports_collapse")]
	public bool? ReportsCollapse { get; set; }

	/// <summary>
	/// Default rounding, premium feature, optional, only for existing WS
	/// </summary>
	[JsonPropertyName("rounding")]
	public int? Rounding { get; set; }

	/// <summary>
	/// Default rounding in minutes, premium feature, optional, only for existing WS
	/// </summary>
	[JsonPropertyName("rounding_minutes")]
	public int? RoundingMinutes { get; set; }
}