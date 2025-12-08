using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// DTO for updating a workspace user
/// https://engineering.toggl.com/docs/api/workspaces#put-update-workspace-user
/// </summary>
public class WorkspaceUserUpdateDto
{
	/// <summary>
	/// Whether the user is an admin
	/// </summary>
	[JsonPropertyName("admin")]
	public bool? IsAdmin { get; set; }

	/// <summary>
	/// Whether the user is inactive
	/// </summary>
	[JsonPropertyName("inactive")]
	public bool? IsInactive { get; set; }

	/// <summary>
	/// Labor cost for the user
	/// </summary>
	[JsonPropertyName("labor_cost")]
	public double? LaborCost { get; set; }

	/// <summary>
	/// Rate assigned to the user
	/// </summary>
	[JsonPropertyName("rate")]
	public double? Rate { get; set; }

	/// <summary>
	/// Role of the user in the workspace
	/// </summary>
	[JsonPropertyName("role")]
	public string? Role { get; set; }

	/// <summary>
	/// Working hours in minutes
	/// </summary>
	[JsonPropertyName("working_hours_in_minutes")]
	public int? WorkingHoursInMinutes { get; set; }
}
