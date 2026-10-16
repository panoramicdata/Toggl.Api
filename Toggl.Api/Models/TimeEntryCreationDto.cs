using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// DTO for creating a time entry
/// https://engineering.toggl.com/docs/api/time_entries#post-timeentries
/// </summary>
public class TimeEntryCreationDto : TimeEntryDtoBase
{
	/// <summary>Must be provided when creating a time entry and should identify the service/application used to create it</summary>
	[JsonPropertyName("created_with")]
	public required string CreatedWith { get; set; }

	/// <summary>
	/// Time entry duration. For running entries should be negative, preferable -1
	/// </summary>
	[JsonPropertyName("duration")]
	public new long Duration
	{
		get => base.Duration!.Value;
		set => base.Duration = value;
	}

	/// <summary>
	/// Start time in UTC, required, RFC3339 format
	/// </summary>
	[JsonPropertyName("start")]
	public new DateTimeOffset Start
	{
		get => base.Start!.Value;
		set => base.Start = value;
	}

	/// <summary>
	/// Validate that the required creation fields are set before the DTO is used.
	/// </summary>
	/// <exception cref="InvalidOperationException">Thrown when a required field is not set.</exception>
	public void EnsureValid()
	{
		if (string.IsNullOrEmpty(CreatedWith))
		{
			throw new InvalidOperationException("CreatedWith must be provided when creating a time entry.");
		}

		if (base.Duration is null)
		{
			throw new InvalidOperationException("Duration must be provided when creating a time entry.");
		}

		if (base.Start is null)
		{
			throw new InvalidOperationException("Start must be provided when creating a time entry.");
		}
	}
}
