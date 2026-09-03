using System.Net.Http.Headers;

namespace Toggl.Api;

/// <summary>
/// Rendering of HTTP headers for diagnostic output, with credential-bearing values redacted.
/// </summary>
internal static class HttpExtensions
{
	/// <summary>
	/// Header names whose values carry a credential and must never be rendered into a log message or
	/// an exception message.
	/// </summary>
	private static readonly HashSet<string> SensitiveHeaderNames = new(StringComparer.OrdinalIgnoreCase)
	{
		"Authorization",
		"Proxy-Authorization",
		"Cookie",
		"Set-Cookie",
		"X-API-Key",
		"Api-Key",
		"X-Api-Token",
		"X-Auth-Token",
	};

	/// <summary>
	/// The subset of sensitive headers whose value is of the form "&lt;scheme&gt; &lt;credential&gt;",
	/// where the scheme is safe to keep and useful to see.
	/// </summary>
	private static readonly HashSet<string> SchemePrefixedHeaderNames = new(StringComparer.OrdinalIgnoreCase)
	{
		"Authorization",
		"Proxy-Authorization",
	};

	/// <summary>
	/// Whether a header name denotes a credential-bearing header.
	/// </summary>
	/// <remarks>
	/// The suffix test catches vendor-prefixed variants of the standard header, which an exact-match
	/// list alone would render verbatim.
	/// </remarks>
	private static bool IsSensitive(string name)
		=> SensitiveHeaderNames.Contains(name)
		|| name.EndsWith("Authorization", StringComparison.OrdinalIgnoreCase);

	/// <summary>
	/// Whether a header's grammar is "&lt;scheme&gt; &lt;credential&gt;", so its scheme can be kept.
	/// </summary>
	private static bool IsSchemePrefixed(string name)
		=> SchemePrefixedHeaderNames.Contains(name)
		|| name.EndsWith("Authorization", StringComparison.OrdinalIgnoreCase);

	/// <summary>
	/// Joins a header's values, replacing the credential with a redaction marker when the header is a
	/// sensitive one.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The authentication scheme and the credential length are preserved. That is enough to tell an
	/// engineer that a credential was sent and roughly what shape it had, which is all diagnosis needs,
	/// without writing the credential itself somewhere it will be retained and widely readable.
	/// </para>
	/// <para>
	/// Values are joined with a comma and no space, matching what the handler produced before redaction
	/// was added.
	/// </para>
	/// </remarks>
	internal static string RedactIfSensitive(string name, IEnumerable<string> values)
	{
		var value = string.Join(",", values);

		if (value.Length == 0 || !IsSensitive(name))
		{
			return value;
		}

		// Only headers whose grammar is "<scheme> <credential>" keep their scheme, so that which
		// authentication mechanism was used remains visible. Applying this to any header containing a
		// space would be unsafe: a cookie such as "session=abc123; HttpOnly" also contains one, and
		// treating the text before it as a scheme would preserve the very value being redacted.
		if (IsSchemePrefixed(name))
		{
			var schemeLength = value.IndexOf(' ', StringComparison.Ordinal);

			if (schemeLength > 0)
			{
				return $"{value[..schemeLength]} <redacted, length {value.Length - schemeLength - 1}>";
			}
		}

		return $"<redacted, length {value.Length}>";
	}

	/// <summary>
	/// Renders headers for diagnostic output, with the value of any credential-bearing header redacted.
	/// </summary>
	/// <remarks>
	/// The separator and "name=value" shape match what the handler produced before redaction was added,
	/// so existing log output is unchanged apart from the credential values themselves.
	/// </remarks>
	internal static string ToDebugString(this HttpHeaders headers)
		=> string.Join("; ", headers.Select(h => $"{h.Key}={RedactIfSensitive(h.Key, h.Value)}"));
}
