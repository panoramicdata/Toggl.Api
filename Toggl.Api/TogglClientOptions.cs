using Microsoft.Extensions.Logging;
using System;
using System.Text.Json.Serialization;

namespace Toggl.Api;

public class TogglClientOptions
{
	/// <summary>
	/// The Toggl API key
	/// </summary>
	public required string Key { get; set; }

	/// <summary>
	/// An optional Logger
	/// </summary>
	public ILogger? Logger { get; set; }

	/// <summary>
	/// Web timeout in seconds
	/// Set to two hours and ten minutes by default to accommodate Toggl's stupid 402 limit
	/// </summary>
	public double TimeoutSeconds { get; set; } = 7500;

	/// <summary>
	/// The User-Agent header to send
	/// </summary>
	public string UserAgent { get; set; } = "Toggl.Api";

	/// <summary>
	/// Whether to handle 402 Payment Required responses by backing off and retrying
	/// </summary>
	public bool HandleRateLimiting { get; set; }

	/// <summary>
	/// Leave at this value to ensure that changes to the API don't cause backward compatibility issues
	/// </summary>
	public JsonUnmappedMemberHandling JsonUnmappedMemberHandling { get; set; } = JsonUnmappedMemberHandling.Skip;

	internal void Validate()
	{
		if (string.IsNullOrEmpty(Key))
		{
			throw new ArgumentException("Key is required");
		}
	}
}