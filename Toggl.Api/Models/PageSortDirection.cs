using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Differs from SortDirection due to casing
/// </summary>
public enum PageSortDirection
{
	[JsonPropertyName("ASC")]
	Ascending,

	[JsonPropertyName("DESC")]
	Descending
}