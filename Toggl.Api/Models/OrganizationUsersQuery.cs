using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// An organization user query
/// </summary>
public class OrganizationUsersQuery
{
	/// <summary>
	/// Returns records where name or email contains this string
	/// </summary>
	[JsonPropertyName("filter")]
	public string? Filter { get; set; }

	/// <summary>
	/// List of active inactive invited comma separated(if not present, all statuses)
	/// </summary>
	[JsonPropertyName("active_status")]
	public string? ActiveStatus { get; set; }

	/// <summary>
	/// If true returns admins only
	/// </summary>
	[JsonPropertyName("only_admins")]
	public bool? OnlyAdmins { get; set; }

	/// <summary>
	/// Comma-separated list of groups ids, returns users belonging to these groups only
	/// </summary>
	[JsonPropertyName("groups")]
	public string? Groups { get; set; }

	/// <summary>
	/// Comma-separated list of workspaces ids, returns users belonging to this workspaces only
	/// </summary>
	[JsonPropertyName("workspaces")]
	public string? Workspaces { get; set; }

	/// <summary>
	/// Page number, default 1
	/// </summary>
	[JsonPropertyName("page")]
	public string? Page { get; set; }

	/// <summary>
	/// 	Number of items per page, default 50
	/// </summary>
	[JsonPropertyName("per_page")]
	public string? PerPage { get; set; }

	/// <summary>
	/// 	Values 'asc' or 'desc', result is sorted on 'names' column, default 'asc'
	/// </summary>
	[JsonPropertyName("sort_dir")]
	public SortDirection? SortDirection { get; set; }
}
