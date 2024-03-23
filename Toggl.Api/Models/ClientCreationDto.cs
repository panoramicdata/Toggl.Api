using Newtonsoft.Json;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/clients#post-create-client
/// </summary>
public class ClientCreationDto : NamedItem
{
	/// <summary>
	/// Workspace ID
	/// </summary>
	[JsonProperty(PropertyName = "wid")]
	public long WorkspaceId { get; set; }
}
