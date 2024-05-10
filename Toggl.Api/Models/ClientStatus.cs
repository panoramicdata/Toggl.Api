using System.Runtime.Serialization;

namespace Toggl.Api.Models;

public enum ClientStatus
{
	[EnumMember(Value = "active")]
	Active,

	[EnumMember(Value = "archived")]
	Archived,

	[EnumMember(Value = "both")]
	Both
}
