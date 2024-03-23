using Newtonsoft.Json;

namespace Toggl.Api.Models;

/// <summary>
/// An organization user query
/// </summary>
public class OrganizationUsersQuery
{
	/// <summary>
	/// Returns records where name or email contains this string
	/// </summary>
	[JsonProperty(PropertyName = "filter")]
	public string? Filter { get; set; }

	/// <summary>
	/// List of active inactive invited comma separated(if not present, all statuses)
	/// </summary>
	[JsonProperty(PropertyName = "active_status")]
	public string? ActiveStatus { get; set; }

	/// <summary>
	/// If true returns admins only
	/// </summary>
	[JsonProperty(PropertyName = "only_admins")]
	public bool? OnlyAdmins { get; set; }

	/// <summary>
	/// Comma-separated list of groups ids, returns users belonging to these groups only
	/// </summary>
	[JsonProperty(PropertyName = "groups")]
	public string? Groups { get; set; }

	/// <summary>
	/// Comma-separated list of workspaces ids, returns users belonging to this workspaces only
	/// </summary>
	[JsonProperty(PropertyName = "workspaces")]
	public string? Workspaces { get; set; }

	/// <summary>
	/// Page number, default 1
	/// </summary>
	[JsonProperty(PropertyName = "page")]
	public string? Page { get; set; }

	/// <summary>
	/// 	Number of items per page, default 50
	/// </summary>
	[JsonProperty(PropertyName = "per_page")]
	public string? PerPage { get; set; }

	/// <summary>
	/// 	Values 'asc' or 'desc', result is sorted on 'names' column, default 'asc'
	/// </summary>
	[JsonProperty(PropertyName = "sort_dir")]
	public SortDirection? SortDirection { get; set; }
}
