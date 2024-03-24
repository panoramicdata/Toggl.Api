using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public enum SortDirection
{
	[JsonPropertyName("asc")]
	Ascending,

	[JsonPropertyName("desc")]
	Descending
}