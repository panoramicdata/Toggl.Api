using System;
using System.Globalization;

namespace Toggl.Api.Extensions;

public static class Dates
{
	public static string ToIsoDateStr(this DateTime date) => date.ToString("yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture);

	public static long ToUnixTime(this DateTime date) => (date.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
}

