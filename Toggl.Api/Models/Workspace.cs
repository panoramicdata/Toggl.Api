using Newtonsoft.Json;
using System;
using System.Globalization;

namespace Toggl.Api.Models;

/// <summary>
/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#workspaces
/// </summary>
public class Workspace : IdentifiedItem
{
	/// <summary>
	/// name: (string, required)
	/// </summary>
	[JsonProperty(PropertyName = "name")]
	public string? Name { get; set; }

	/// <summary>
	/// premium: If it's a pro workspace or not. Shows if someone is paying for the workspace or not (boolean, not required)
	/// </summary>
	[JsonProperty(PropertyName = "premium")]
	public bool? Ispremium { get; set; }

	/// <summary>
	/// at: timestamp that is sent in the response, indicates the time item was last updated
	/// </summary>
	[JsonProperty(PropertyName = "at")]
	public DateTime? UpdatedOn { get; set; }

	public override string ToString() => string.Format(CultureInfo.InvariantCulture, "Id: {0}, Name: {1}", Id, Name);
}