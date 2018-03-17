using System;
using System.Collections.Generic;
using Toggl.Api.DataObjects;

namespace Toggl.Api.QueryObjects
{
	public class TimeEntryParams : TimeEntry
	{

		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }

		public TimeEntryParams()
		{
			TagNames = new List<string>();
		}

		public List<KeyValuePair<string, string>> GetParameters()
		{
			var lst = new List<KeyValuePair<string, string>>();
			if (StartDate.HasValue)
				lst.Add(new KeyValuePair<string, string>("start_date", GetStartParameter()));
			if (EndDate.HasValue)
				lst.Add(new KeyValuePair<string, string>("end_date", GetEndIsoDate()));
			return lst;
		}

		private string GetStartParameter()
		{
			return GetIsoDate(StartDate);
		}

		private string GetEndIsoDate()
		{
			return GetIsoDate(EndDate);
		}

		private string GetIsoDate(DateTime? dt)
		{
			return dt.GetValueOrDefault().ToString("yyyy-MM-ddTHH:mm:sszzz");
		}
	}
}