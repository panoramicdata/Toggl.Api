using System;
using System.Globalization;

namespace Toggl.Api.Extensions;

/// <summary>
/// Date extension methods.
/// </summary>
public static class Dates
{
	/// <summary>
	/// Converts a DateTime to an ISO date string.
	/// </summary>
	public static string ToIsoDateStr(this DateTime date) => date.ToString("yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture);

	/// <summary>
	/// Converts a DateTime to a Unix timestamp.
	/// </summary>
	public static long ToUnixTime(this DateTime date) => (date.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
}

