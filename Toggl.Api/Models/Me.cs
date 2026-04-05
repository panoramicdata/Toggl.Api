using System;

namespace Toggl.Api.Models;

/// <summary>
/// Represents the current user. Deprecated in favor of CurrentUser.
/// </summary>
[Obsolete("Use CurrentUser instead.  Will be removed in future versions.", true)]
public class Me : CurrentUser
{
}