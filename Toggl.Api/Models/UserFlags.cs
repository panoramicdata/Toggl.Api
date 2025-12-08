using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// User flags - dynamic key-value pairs for user settings
/// https://engineering.toggl.com/docs/api/me#get-me-flags
/// </summary>
public class UserFlags : Dictionary<string, object>
{
}
