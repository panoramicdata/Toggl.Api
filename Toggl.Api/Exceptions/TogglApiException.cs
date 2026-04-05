using System;

namespace Toggl.Api.Exceptions;

/// <summary>
/// A Toggl API exception.
/// </summary>
public class TogglApiException : Exception
{
	/// <summary>
	/// Initializes a new instance of the <see cref="TogglApiException"/> class.
	/// </summary>
	public TogglApiException()
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="TogglApiException"/> class.
	/// </summary>
	public TogglApiException(string message) : base(message)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="TogglApiException"/> class.
	/// </summary>
	public TogglApiException(string message, Exception innerException) : base(message, innerException)
	{
	}
}
