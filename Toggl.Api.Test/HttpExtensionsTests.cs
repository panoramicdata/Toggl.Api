using AwesomeAssertions;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xunit;

namespace Toggl.Api.Test;

/// <summary>
/// Tests for header redaction in diagnostic output.
///
/// <para>
/// <c>AuthenticatedHttpClientHandler</c> sets an Authorization header carrying the API token,
/// base64 encoded, on every request, then joined every header key and value into its Debug level
/// log message. The response side did the same. Without redaction the credential was written
/// wherever those messages ended up, and base64 is an encoding rather than a protection, so it was
/// trivially recoverable.
/// </para>
///
/// <para>
/// These are pure unit tests. They construct headers directly and require no credentials, no
/// configuration and no live account.
/// </para>
/// </summary>
public class HttpExtensionsTests
{
	private const string FakeApiToken = "0123456789abcdef0123456789abcdef";

	/// <summary>
	/// Builds the header exactly as the handler does, so this fails if that changes.
	/// </summary>
	private static string BuildAuthorizationValue()
		=> "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(FakeApiToken + ":api_token"));

	/// <summary>
	/// The headline case: neither the encoded credential nor the token inside it may survive.
	/// </summary>
	[Fact]
	public void ToDebugString_TogglApiToken_DoesNotLeakTheCredential()
	{
		var authorization = BuildAuthorizationValue();
		using var request = new HttpRequestMessage();
		request.Headers.Add("Authorization", authorization);

		var debugString = request.Headers.ToDebugString();

		debugString.Should().NotContain(authorization["Basic ".Length..]);
		debugString.Should().NotContain(FakeApiToken);
		debugString.Should().Be($"Authorization=Basic <redacted, length {authorization.Length - "Basic ".Length}>");
	}

	/// <summary>
	/// Base64 is an encoding, not a protection. A redaction that only looked for the raw token would
	/// leave the encoded form in the log, from which the token is recoverable in one step.
	/// </summary>
	[Fact]
	public void ToDebugString_EncodedCredential_IsNotRecoverableFromTheOutput()
	{
		using var request = new HttpRequestMessage();
		request.Headers.Add("Authorization", BuildAuthorizationValue());

		var debugString = request.Headers.ToDebugString();

		var base64Candidates = debugString
			.Split('=', ' ', ';')
			.Where(part => part.Length > 8);

		foreach (var candidate in base64Candidates)
		{
			var decoded = TryDecodeBase64(candidate);
			decoded.Should().NotContain(FakeApiToken);
		}
	}

	private static string TryDecodeBase64(string candidate)
	{
		try
		{
			return Encoding.ASCII.GetString(Convert.FromBase64String(candidate));
		}
		catch (FormatException)
		{
			return string.Empty;
		}
	}

	/// <summary>
	/// Proves the defect being fixed: the previous rendering leaked, the replacement does not.
	/// </summary>
	[Fact]
	public void ToDebugString_UnlikeTheOldJoin_DoesNotContainTheCredential()
	{
		var authorization = BuildAuthorizationValue();
		using var request = new HttpRequestMessage();
		request.Headers.Add("Authorization", authorization);

		// This is exactly what the handler did before the fix.
		var previousRendering = string.Join(
			"; ",
			request.Headers.Select(h => $"{h.Key}={string.Join(",", h.Value)}"));

		previousRendering.Should().Contain(authorization, "the previous rendering is what leaked");
		request.Headers.ToDebugString().Should().NotContain(FakeApiToken);
	}

	/// <summary>
	/// A header added without validation keeps whatever casing the caller used.
	/// </summary>
	/// <param name="headerName">The header name casing under test.</param>
	[Theory]
	[InlineData("authorization")]
	[InlineData("AUTHORIZATION")]
	[InlineData("AuThOrIzAtIoN")]
	public void ToDebugString_AuthorizationHeader_IsRedactedWhateverTheCasing(string headerName)
	{
		using var request = new HttpRequestMessage();
		request.Headers.TryAddWithoutValidation(headerName, BuildAuthorizationValue());

		var debugString = request.Headers.ToDebugString();

		debugString.Should().NotContain(FakeApiToken);
		debugString.Should().Contain("<redacted");
	}

	/// <summary>
	/// The other standard credential-bearing header names are redacted too.
	/// </summary>
	/// <param name="headerName">The credential-bearing header name under test.</param>
	[Theory]
	[InlineData("Proxy-Authorization")]
	[InlineData("Cookie")]
	[InlineData("X-API-Key")]
	[InlineData("Api-Key")]
	[InlineData("X-Api-Token")]
	[InlineData("X-Auth-Token")]
	public void ToDebugString_OtherCredentialHeaders_AreRedacted(string headerName)
	{
		const string secret = "s3cr3t-value-that-must-not-be-logged";
		using var request = new HttpRequestMessage();
		request.Headers.TryAddWithoutValidation(headerName, secret);

		var debugString = request.Headers.ToDebugString();

		debugString.Should().NotContain(secret);
		debugString.Should().Contain("<redacted");
	}

	/// <summary>
	/// A vendor may prefix the standard header name rather than using it directly.
	/// </summary>
	[Fact]
	public void ToDebugString_VendorPrefixedAuthorizationHeader_IsRedacted()
	{
		using var request = new HttpRequestMessage();
		request.Headers.TryAddWithoutValidation("X-Vendor-Authorization", $"Bearer {FakeApiToken}");

		var debugString = request.Headers.ToDebugString();

		debugString.Should().NotContain(FakeApiToken);
		debugString.Should().Contain("<redacted");
	}

	/// <summary>
	/// A cookie value also contains a space, so treating the text before the first space as a scheme
	/// would preserve the very value being redacted. Only Authorization style headers keep a scheme.
	/// </summary>
	[Fact]
	public void ToDebugString_CookieValueContainingASpace_IsRedactedWhole()
	{
		const string cookie = "session=abc123def456; HttpOnly";
		using var request = new HttpRequestMessage();
		request.Headers.TryAddWithoutValidation("Cookie", cookie);

		var debugString = request.Headers.ToDebugString();

		debugString.Should().Be($"Cookie=<redacted, length {cookie.Length}>");
		debugString.Should().NotContain("session=abc");
	}

	/// <summary>
	/// The separator and shape of the rendering must match what the handler produced before, so that
	/// existing log output changes only in the credential values themselves.
	/// </summary>
	[Fact]
	public void ToDebugString_PreservesTheOriginalLineFormat()
	{
		using var request = new HttpRequestMessage();
		request.Headers.TryAddWithoutValidation("Accept", "application/json");
		request.Headers.TryAddWithoutValidation("User-Agent", "Toggl.Api");

		var debugString = request.Headers.ToDebugString();

		debugString.Should().Be("Accept=application/json; User-Agent=Toggl.Api");
	}

	/// <summary>
	/// Redaction must be surgical: the useful headers alongside the credential must survive intact.
	/// </summary>
	[Fact]
	public void ToDebugString_RedactsOnlyTheSensitiveHeader()
	{
		using var request = new HttpRequestMessage();
		request.Headers.Add("Authorization", BuildAuthorizationValue());
		request.Headers.TryAddWithoutValidation("Accept", "application/json");

		var debugString = request.Headers.ToDebugString();

		debugString.Should().NotContain(FakeApiToken);
		debugString.Should().Contain("Accept=application/json");
	}

	/// <summary>
	/// Response headers go through the same helper, so Set-Cookie and the quota headers are covered.
	/// </summary>
	[Fact]
	public void ToDebugString_ResponseSetCookieIsRedactedButQuotaHeadersSurvive()
	{
		using var response = new HttpResponseMessage();
		response.Headers.TryAddWithoutValidation("Set-Cookie", "session=abc123def456; HttpOnly");
		response.Headers.TryAddWithoutValidation("X-Toggl-Quota-Remaining", "0");

		var debugString = response.Headers.ToDebugString();

		debugString.Should().NotContain("abc123def456");
		debugString.Should().Contain("<redacted");
		debugString.Should().Contain("X-Toggl-Quota-Remaining=0");
	}

	/// <summary>
	/// An empty header collection produces no output at all.
	/// </summary>
	[Fact]
	public void ToDebugString_NoHeaders_IsEmpty()
	{
		using var request = new HttpRequestMessage();

		request.Headers.ToDebugString().Should().BeEmpty();
	}
}
