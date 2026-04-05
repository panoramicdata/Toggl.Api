using System;
using System.Collections.Generic;
using System.Globalization;
using Toggl.Api.Models;

namespace Toggl.Api.QueryObjects;

/// <summary>
/// Time entry query parameters.
/// </summary>
public class TimeEntryParams : TimeEntry
{
	/// <summary>
	/// The start date.
	/// </summary>
	public DateTime? StartDate { get; set; }

	/// <summary>
	/// The end date.
	/// </summary>
	public DateTime? EndDate { get; set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="TimeEntryParams"/> class.
	/// </summary>
	public TimeEntryParams()
	{
		Tags = [];
	}

	/// <summary>
	/// Gets the query parameters.
	/// </summary>
	public List<KeyValuePair<string, string>> GetParameters()
	{
		var lst = new List<KeyValuePair<string, string>>();
		if (StartDate.HasValue)
		{
			lst.Add(new KeyValuePair<string, string>("start_date", GetStartParameter()));
		}

		if (EndDate.HasValue)
		{
			lst.Add(new KeyValuePair<string, string>("end_date", GetEndIsoDate()));
		}

		return lst;
	}

	private string GetStartParameter()
		=> GetIsoDate(StartDate);

	private string GetEndIsoDate()
		=> GetIsoDate(EndDate);

	private static string GetIsoDate(DateTime? dt)
		=> dt.GetValueOrDefault().ToString("yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture);
}
