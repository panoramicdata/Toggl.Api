using System;

namespace Toggl.Api.Exceptions;

public class TogglApiException : Exception
{
	public TogglApiException()
	{
	}

	public TogglApiException(string message) : base(message)
	{
	}

	public TogglApiException(string message, Exception innerException) : base(message, innerException)
	{
	}
}
