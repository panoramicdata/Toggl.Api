using System.Globalization;
using System.Text.RegularExpressions;

namespace Toggl.Api.Extensions;

/// <summary>
/// String extension methods.
/// </summary>
public static class Strings
{
	/// <summary>
	/// Converts a PascalCased string to a lower_case_underscore string.
	/// </summary>
	public static string LowerCaseUnderscore(this string pascalCasedWord) => Regex
		.Replace(Regex.Replace(Regex.Replace(pascalCasedWord, "([A-Z]+)([A-Z][a-z])", "$1_$2"), @"([a-z\d])([A-Z])", "$1_$2"), @"[-\s]", "_")
		.ToLower(CultureInfo.InvariantCulture);
}
