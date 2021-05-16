using Newtonsoft.Json;

namespace Toggl.Api.DataObjects
{
	/// <summary>
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/users.md#users
	/// </summary>
	public class UserAdd : BaseDataObject
	{
		[JsonProperty(PropertyName = "email")]
		public string? Email { get; set; }

		[JsonProperty(PropertyName = "timezone")]
		public string? Timezone { get; set; }
	}
}