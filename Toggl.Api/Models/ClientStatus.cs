using System.Runtime.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// The client status.
/// </summary>
public enum ClientStatus
{
	/// <summary>
	/// Active clients.
	/// </summary>
	[EnumMember(Value = "active")]
	Active,

	/// <summary>
	/// Archived clients.
	/// </summary>
	[EnumMember(Value = "archived")]
	Archived,

	/// <summary>
	/// Both active and archived clients.
	/// </summary>
	[EnumMember(Value = "both")]
	Both
}
