using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A Project
/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/projects.md#projects
/// </summary>
public class Project : NamedIdentifiedItem
{
	/// <summary>
	/// Workspace ID, where the project will be saved
	/// </summary>
	[JsonPropertyName("workspace_id")]
	public required long WorkspaceId { get; set; }

	/// <summary>
	/// Workspace ID, where the project will be saved (again, for some reason)
	/// </summary>
	[JsonPropertyName("wid")]
	public required long WorkspaceId2 { get; set; }

	/// <summary>
	///  Client ID
	/// </summary>
	[JsonPropertyName("client_id")]
	public required long? ClientId { get; set; }

	/// <summary>
	///  Client ID (again, for some reason)
	/// </summary>
	[JsonPropertyName("cid")]
	public required long? ClientId2 { get; set; }

	/// <summary>
	/// Whether the project is billable or not
	/// </summary>
	[JsonPropertyName("billable")]
	public required bool IsBillable { get; set; }

	/// <summary>
	/// Whether project is accessible for only project users or for all workspace users (boolean, default true)
	/// </summary>
	[JsonPropertyName("is_private")]
	public required bool IsPrivate { get; set; }

	/// <summary>
	/// Whether the project is archived
	/// </summary>
	[JsonPropertyName("active")]
	public required bool IsActive { get; set; }

	/// <summary>
	/// Whether the project can be used as a template
	/// </summary>
	[JsonPropertyName("template")]
	public required bool IsTemplateable { get; set; }

	/// <summary>
	/// Timestamp that is sent in the response for PUT, indicates the time task was last updated
	/// </summary>
	[JsonPropertyName("at")]
	public required DateTimeOffset LastModified { get; set; }

	/// <summary>
	/// Timestamp indicating when the project was created, read-only
	/// </summary>
	[JsonPropertyName("created_at")]
	public required DateTimeOffset Created { get; set; }

	/// <summary>
	/// Timestamp indicating when the project started
	/// </summary>
	[JsonPropertyName("start_date")]
	public required DateTimeOffset StartDate { get; set; }

	/// <summary>
	/// Timestamp indicating when the project ends
	/// </summary>
	[JsonPropertyName("end_date")]
	public DateTimeOffset? EndDate { get; set; }

	/// <summary>
	/// The project status
	/// </summary>
	[JsonPropertyName("status")]
	public required ProjectStatus Status { get; set; }

	/// <summary>
	/// Timestamp indicating when the project was deleted (or null if not deleted)
	/// </summary>
	[JsonPropertyName("server_deleted_at")]
	public required DateTimeOffset? ServerDeletedAt { get; set; }

	/// <summary>
	/// Timestamp indicating when the rate was last updated
	/// </summary>
	[JsonPropertyName("rate_last_updated")]
	public required DateTimeOffset? RateLastUpdated { get; set; }

	/// <summary>
	/// Whether the project is recurring
	/// </summary>
	[JsonPropertyName("recurring")]
	public required bool Recurring { get; set; }

	/// <summary>
	/// If the project is recurring, the recurrence parameters
	/// </summary>
	[JsonPropertyName("recurring_parameters")]
	public required ICollection<RecurringParameter> RecurringParameters { get; set; }

	/// <summary>
	/// Whether the project has a fixed fee
	/// </summary>
	[JsonPropertyName("fixed_fee")]
	public required bool? IsFixedFee { get; set; }

	/// <summary>
	/// A color
	/// </summary>
	[JsonPropertyName("color")]
	public required string Color { get; set; }

	/// <summary>
	/// Whether the estimated hours are automatically calculated based on task estimations or manually fixed based on the value of 'estimated_hours' (boolean, default false, not required, premium functionality)
	/// </summary>
	[JsonPropertyName("auto_estimates")]
	public required bool IsAutoEstimates { get; set; }

	/// <summary>
	/// If auto_estimates is true then the sum of task estimations is returned, otherwise user inserted hours (integer, not required, premium functionality)
	/// </summary>
	[JsonPropertyName("estimated_hours")]
	public int? EstimatedHours { get; set; }

	/// <summary>
	/// If auto_estimates is true then the sum of task estimations is returned, otherwise user inserted seconds (integer, not required, premium functionality)
	/// </summary>
	[JsonPropertyName("estimated_seconds")]
	public int? EstimatedSeconds { get; set; }

	/// <summary>
	/// The number of actual hours spent
	/// </summary>
	[JsonPropertyName("actual_hours")]
	public double? ActualHours { get; set; }

	/// <summary>
	/// The number of actual seconds spent
	/// </summary>
	[JsonPropertyName("actual_seconds")]
	public double? ActualSeconds { get; set; }

	/// <summary>
	/// The current period
	/// </summary>
	[JsonPropertyName("current_period")]
	public Period? CurrentPeriod { get; set; }

	/// <summary>
	/// Id of the template project used on current project's creation
	/// </summary>
	[JsonPropertyName("template_id")]
	public long? TemplateId { get; set; }

	/// <summary>
	/// Hourly rate of the project (float, not required, premium functionality)
	/// </summary>
	[JsonPropertyName("rate")]
	public double? HourlyRate { get; set; }

	/// <summary>
	/// Hourly rate currency of the project
	/// </summary>
	[JsonPropertyName("currency")]
	public required string Currency { get; set; }

	/// <summary>
	/// Permissions
	/// </summary>
	[JsonPropertyName("permissions")]
	public string? Permissions { get; set; }

	public override string ToString() => string.Format(CultureInfo.InvariantCulture, "Id: {0}, Name: {1}", Id, Name);
}