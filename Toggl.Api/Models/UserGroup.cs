using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public class UserGroup : NamedItem
{
	/// <summary>
	/// Group id
	/// </summary>
	[JsonPropertyName("group_id")]
	public int GroupId { get; set; }
}