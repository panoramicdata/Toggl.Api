namespace Toggl.Api;

/// <summary>
/// Refuses every request other than GET, HEAD, OPTIONS or a named read-only reports POST while <see cref="TogglClientOptions.IsReadOnly"/> is set.
/// The option is read on every request.
/// </summary>
internal sealed class ReadOnlyHandler(TogglClientOptions options) : DelegatingHandler
{
	// The Reports API uses POST for these searches and summaries; they only read.
	private static readonly string[] ReadOnlyPostPathSuffixes =
	[
		"/search/time_entries",
		"/summary"
	];

	protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
	{
		if (options.IsReadOnly && !IsRead(request))
		{
			throw new InvalidOperationException($"The client is read-only (IsReadOnly is true): {request.Method} {request.RequestUri?.AbsolutePath} is not allowed.");
		}

		return base.SendAsync(request, cancellationToken);
	}

	private static bool IsRead(HttpRequestMessage request)
		=> request.Method == HttpMethod.Get
			|| request.Method == HttpMethod.Head
			|| request.Method == HttpMethod.Options
			|| (request.Method == HttpMethod.Post && IsReportsReadPath(request.RequestUri));

	private static bool IsReportsReadPath(Uri? uri)
		=> uri is not null
			&& uri.AbsolutePath.StartsWith("/reports/api/v3/", StringComparison.OrdinalIgnoreCase)
			&& ReadOnlyPostPathSuffixes.Any(suffix => uri.AbsolutePath.EndsWith(suffix, StringComparison.OrdinalIgnoreCase));
}
