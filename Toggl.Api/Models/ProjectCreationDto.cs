using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/projects/#post-workspaceprojects
/// </summary>
public class ProjectCreationDto : NamedItem
{
	/// <summary>
	/// Whether the project is active or archived
	/// </summary>
	[JsonPropertyName("active")]
	public required bool IsActive { get; set; }

	/// <summary>
	/// Whether estimates are based on task hours, optional, premium feature
	/// </summary>
	[JsonPropertyName("auto_estimates")]
	public bool? IsAutoEstimates { get; set; }

	/// <summary>
	/// Whether the project is set as billable, optional, premium feature
	/// </summary>
	[JsonPropertyName("billable")]
	public bool? IsBillable { get; set; }

	/// <summary>
	/// Client ID, optional
	/// </summary>
	[JsonPropertyName("client_id")]
	public long? ClientId { get; set; }

	/// <summary>
	/// Client ID, legacy
	/// </summary>
	[JsonPropertyName("cid")]
	public long? ClientId2 { get; set; }

	/// <summary>
	/// Client name, optional
	/// </summary>
	[JsonPropertyName("client_name")]
	public string? ClientName { get; set; }

	/// <summary>
	/// Project color
	/// </summary>
	[JsonPropertyName("color")]
	public string Color { get; set; } = string.Empty;

	/// <summary>
	/// Project currency, optional, premium feature
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// End date of a project time-frame
	/// </summary>
	[JsonPropertyName("end_date")]
	public DateTimeOffset? EndDate { get; set; }

	/// <summary>
	/// Estimated hours, optional, premium feature
	/// </summary>
	[JsonPropertyName("estimated_hours")]
	public int? EstimatedHours { get; set; }

	/// <summary>
	/// Project fixed fee, optional, premium feature
	/// </summary>
	[JsonPropertyName("fixed_fee")]
	public double? FixedFee { get; set; }

	/// <summary>
	/// Whether the project is private or not
	/// </summary>
	[JsonPropertyName("is_private")]
	public required bool IsPrivate { get; set; }

	/// <summary>
	/// Shared
	/// </summary>
	[JsonPropertyName("is_shared")]
	public required bool IsShared { get; set; }

	/// <summary>
	/// Hourly rate, optional, premium feature
	/// </summary>
	[JsonPropertyName("rate")]
	public double? HourlyRate { get; set; }

	/// <summary>
	/// Rate change mode, optional, premium feature. Can be "start-today", "override-current", "override-all"
	/// </summary>
	[JsonPropertyName("rate_change_mode")]
	public WorkspaceRateChangeMode? RateChangeMode { get; set; }

	/// <summary>
	/// Project is recurring, optional, premium feature
	/// </summary>
	[JsonPropertyName("recurring")]
	public bool? Recurring { get; set; }

	/// <summary>
	/// Start date of a project time-frame
	/// </summary>
	[JsonPropertyName("start_date")]
	public required DateTimeOffset StartDate { get; set; }

	/// <summary>
	/// Project is template, optional, premium feature
	/// </summary>
	[JsonPropertyName("template")]
	public bool? IsTemplateable { get; set; }

	/// <summary>
	/// Template ID, optional
	/// </summary>
	[JsonPropertyName("template_id")]
	public long? TemplateId { get; set; }
}
