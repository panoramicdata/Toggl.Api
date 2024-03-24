using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/clients#post-create-client
/// </summary>
public class ClientCreationDto : NamedItem
{
	/// <summary>
	/// Workspace ID
	/// </summary>
	[JsonPropertyName("wid")]
	public long WorkspaceId { get; set; }
}
