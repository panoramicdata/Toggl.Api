using System;
using System.Collections.Generic;
using System.Globalization;
using Toggl.Api.Models;

namespace Toggl.Api.QueryObjects;

public class TimeEntryParams : TimeEntry
{
	public DateTime? StartDate { get; set; }

	public DateTime? EndDate { get; set; }

	public TimeEntryParams()
	{
		Tags = new List<string>();
	}

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
