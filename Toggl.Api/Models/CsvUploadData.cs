using System;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// CSV upload data
/// https://engineering.toggl.com/docs/api/workspaces#get-get-single-workspace
/// </summary>
public class CsvUploadData
{
	/// <summary>
	/// Last modified
	/// </summary>
	[JsonPropertyName("at")]
	public DateTimeOffset? LastModified { get; set; }

	/// <summary>
	/// Log id
	/// </summary>
	[JsonPropertyName("log_id")]
	public int? LogId { get; set; }
}