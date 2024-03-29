using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A detailed report request
/// </summary>
public class DetailedReportRequest
{
	/// <summary>
	/// Whether the time entry is set as billable, optional, premium feature.
	/// </summary>
	[JsonPropertyName("billable")]
	public bool? IsBillable { get; set; }

	/// <summary>
	/// Client IDs, optional, filtering attribute. To filter records with no clients, use [null].
	/// </summary>
	[JsonPropertyName("client_ids")]
	public ICollection<long>? ClientIds { get; set; }

	/// <summary>
	/// Description, optional, filtering attribute.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// End date, example time.DateOnly. Should be greater than Start date.
	/// </summary>
	[JsonPropertyName("end_date")]
	public required DateOnly EndDate { get; set; }

	/// <summary>
	/// First ID, optional, integer, the first time entry ID in the list.
	/// </summary>
	[JsonPropertyName("first_id")]
	public int? FirstId { get; set; }

	/// <summary>
	/// First row number, optional, integer, the first row number in the list.
	/// </summary>
	[JsonPropertyName("first_row_number")]
	public int? FirstRowNumber { get; set; }

	/// <summary>
	/// The first timestamp
	/// </summary>
	[JsonPropertyName("first_timestamp")]
	public long? FirstTimestamp { get; set; }

	/// <summary>
	/// Group IDs, optional, filtering attribute.
	/// </summary>
	[JsonPropertyName("group_ids")]
	public ICollection<long>? GroupIds { get; set; }

	/// <summary>
	/// Whether time entries should be grouped, optional, default false.
	/// </summary>
	[JsonPropertyName("grouped")]
	public bool? Grouped { get; set; }

	/// <summary>
	/// Whether amounts should be hidden, optional, default false.
	/// </summary>
	[JsonPropertyName("hide_amounts")]
	public bool? HideAmounts { get; set; }

	/// <summary>
	/// Max duration seconds, optional, filtering attribute. Time Audit only, should be greater than MinDurationSeconds.
	/// </summary>
	[JsonPropertyName("max_duration_seconds")]
	public int? MaxDurationSeconds { get; set; }

	/// <summary>
	/// Min duration seconds, optional, filtering attribute. Time Audit only, should be less than MaxDurationSeconds.
	/// </summary>
	[JsonPropertyName("min_duration_seconds")]
	public int? MinDurationSeconds { get; set; }

	/// <summary>
	/// Order by field, optional, default "date". Can be "date", "user", "duration", "description" or "last_update".
	/// </summary>
	[JsonPropertyName("order_by")]
	public string? OrderBy { get; set; }

	/// <summary>
	/// 	Order direction, optional. Can be ASC or DESC.
	/// </summary>
	[JsonPropertyName("order_dir")]
	public PageSortDirection? OrderDirection { get; set; }

	/// <summary>
	/// PageSize defines the number of items per page, optional, default 50.
	/// </summary>
	[JsonPropertyName("page_size")]
	public int? PageSize { get; set; }

	/// <summary>
	/// Posted fields
	/// </summary>
	[JsonPropertyName("postedFields")]
	public ICollection<string>? PostedFields { get; set; }

	/// <summary>
	/// Project IDs, optional, filtering attribute. To filter records with no projects, use [null].
	/// </summary>
	[JsonPropertyName("project_ids")]
	public ICollection<long>? ProjectIds { get; set; }

	/// <summary>
	/// 	Whether time should be rounded, optional, default from workspace settings.
	/// </summary>
	[JsonPropertyName("rounding")]
	public bool? Rounding { get; set; }

	/// <summary>
	/// Rounding minutes value, optional, default from workspace settings. Should be 0, 1, 5, 6, 10, 12, 15, 30, 60 or 240.
	/// </summary>
	[JsonPropertyName("rounding_minutes")]
	public int? RoundingMinutes { get; set; }

	/// <summary>
	/// Start time
	/// </summary>
	[JsonPropertyName("start_time")]
	public required TimeOnly StartTime { get; set; }

	/// <summary>
	/// Start date, example time.DateOnly.Should be less than End date.
	/// </summary>
	[JsonPropertyName("start_date")]
	public required DateOnly StartDate { get; set; }

	/// <summary>
	/// Tag IDs, optional, filtering attribute. To filter records with no tags, use [null].
	/// </summary>
	[JsonPropertyName("tag_ids")]
	public ICollection<long>? TagIds { get; set; }

	/// <summary>
	/// Task IDs, optional, filtering attribute. To filter records with no tasks, use [null].
	/// </summary>
	[JsonPropertyName("task_ids")]
	public ICollection<long>? TaskIds { get; set; }

	/// <summary>
	/// TimeEntryIDs filters by time entries. This was added to support retro-compatibility with reports v2.
	/// </summary>
	[JsonPropertyName("time_entry_ids")]
	public ICollection<long>? TimeEntryIds { get; set; }

	/// <summary>
	/// User IDs, optional, filtering attribute.
	/// </summary>
	[JsonPropertyName("user_ids")]
	public ICollection<long>? UserIds { get; set; }
}