using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/users.md#users
/// </summary>
public class UserAdd : Item
{
	[JsonPropertyName("email")]
	public string? Email { get; set; }

	[JsonPropertyName("timezone")]
	public string? Timezone { get; set; }
}