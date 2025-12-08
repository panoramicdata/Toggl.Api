using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Record of a data export request
/// https://engineering.toggl.com/docs/api/exports
/// </summary>
public class DownloadRequestRecord : IdentifiedItem
{
	/// <summary>
	/// When was created
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTimeOffset? CreatedAt { get; set; }

	/// <summary>
	/// When download will expire
	/// </summary>
	[JsonPropertyName("expires_at")]
	public DateTimeOffset? ExpiresAt { get; set; }

	/// <summary>
	/// Export status (pending, processing, completed, failed)
	/// </summary>
	[JsonPropertyName("status")]
	public string? Status { get; set; }

	/// <summary>
	/// UUID for download link
	/// </summary>
	[JsonPropertyName("uuid")]
	public string? Uuid { get; set; }

	/// <summary>
	/// User ID who requested the export
	/// </summary>
	[JsonPropertyName("user_id")]
	public long? UserId { get; set; }
}
