using Newtonsoft.Json;

namespace Toggl.Api.Models;

public class UserGroup : NamedItem
{
	/// <summary>
	/// Group id
	/// </summary>
	[JsonProperty(PropertyName = "group_id")]
	public int GroupId { get; set; }
}