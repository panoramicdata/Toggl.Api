using Microsoft.Extensions.Logging;
using System;

namespace Toggl.Api;

public class TogglClientOptions
{
	public required string Key { get; set; }

	public ILogger? Logger { get; set; }

	public double TimeoutSeconds { get; set; } = 30;

	public string UserAgent { get; set; } = "Toggl.Api";

	internal void Validate()
	{
		if (string.IsNullOrEmpty(Key))
		{
			throw new ArgumentException("Key is required", nameof(Key));
		}
	}
}