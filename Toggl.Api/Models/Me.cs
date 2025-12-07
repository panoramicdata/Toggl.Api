using System;

namespace Toggl.Api.Models;

[Obsolete("Use CurrentUser instead.  Will be removed in future versions.", true)]
public class Me : CurrentUser
{
}