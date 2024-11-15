using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// A page of data
/// https://engineering.toggl.com/docs/api/tasks#get-tasks
/// </summary>
public class Page<T>
{
	/// <summary>
	/// The total number of items
	/// </summary>
	[JsonPropertyName("total_count")]
	public required int TotalCount { get; set; }

	/// <summary>
	/// The page index, starting at 1
	/// </summary>
	[JsonPropertyName("page")]
	public required int PageIndex { get; set; }

	/// <summary>
	/// Whether the task is active
	/// </summary>
	[JsonPropertyName("per_page")]
	public required int PageSize { get; set; }

	/// <summary>
	/// The sort field
	/// </summary>
	[JsonPropertyName("sort_field")]
	public required string SortField { get; set; }

	/// <summary>
	/// The sort direction.  Can't use SortDirection for some reason.
	/// </summary>
	[JsonPropertyName("sort_order")]
	public required string SortDirection { get; set; }

	/// <summary>
	/// The sort direction
	/// </summary>
	[JsonPropertyName("data")]
	public required ICollection<T> Data { get; set; }
}
