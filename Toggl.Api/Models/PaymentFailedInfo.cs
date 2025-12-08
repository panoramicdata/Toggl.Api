using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Represents payment failure information
/// https://engineering.toggl.com/docs/api/subscription
/// </summary>
public class PaymentFailedInfo
{
	/// <summary>
	/// Failure message
	/// </summary>
	[JsonPropertyName("message")]
	public string? Message { get; set; }

	/// <summary>
	/// Failure reason
	/// </summary>
	[JsonPropertyName("reason")]
	public string? Reason { get; set; }

	/// <summary>
	/// When the payment failed
	/// </summary>
	[JsonPropertyName("failed_at")]
	public DateTimeOffset? FailedAt { get; set; }

	/// <summary>
	/// Retry count
	/// </summary>
	[JsonPropertyName("retry_count")]
	public int? RetryCount { get; set; }

	/// <summary>
	/// Next retry date
	/// </summary>
	[JsonPropertyName("next_retry_at")]
	public DateTimeOffset? NextRetryAt { get; set; }
}
