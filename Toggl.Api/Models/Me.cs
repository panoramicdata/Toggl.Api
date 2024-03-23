using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/me#get-me
/// </summary>
public class Me : IdentifiedItem
{
	/// <summary>
	/// Will be omitted if empty
	/// </summary>
	[JsonProperty(PropertyName = "api_token")]
	public required string ApiToken { get; set; }

	/// <summary>
	/// Last modified
	/// </summary>
	[JsonProperty(PropertyName = "at")]
	public required DateTimeOffset At { get; set; }

	/// <summary>
	/// The first day of the user's week
	/// </summary>
	[JsonProperty(PropertyName = "beginning_of_week")]
	public int BeginningOfWeek { get; set; }

	/// <summary>
	/// Clients, null if with_related_data was not set to true or if the user does not have any clients
	/// </summary>
	[JsonProperty(PropertyName = "clients")]
	public ICollection<Client>? Clients { get; set; }

	/// <summary>
	/// country_id
	/// </summary>
	[JsonProperty(PropertyName = "country_id")]
	public int CountryId { get; set; }

	/// <summary>
	/// Created
	/// </summary>
	[JsonProperty(PropertyName = "created_at")]
	public required DateTimeOffset Created { get; set; }

	/// <summary>
	/// The default workspace id
	/// </summary>
	[JsonProperty(PropertyName = "default_workspace_id")]
	public required string DefaultWorkspaceId { get; set; }

	/// <summary>
	/// Email
	/// </summary>
	[JsonProperty(PropertyName = "email")]
	public required string Email { get; set; }

	/// <summary>
	/// The full name
	/// </summary>
	[JsonProperty(PropertyName = "fullname")]
	public required string FullName { get; set; }

	/// <summary>
	/// Whether the user has a password
	/// </summary>
	[JsonProperty(PropertyName = "has_password")]
	public bool HasPassword { get; set; }

	/// <summary>
	/// The image URL
	/// </summary>
	[JsonProperty(PropertyName = "image_url")]
	public required string ImageUrl { get; set; }

	/// <summary>
	/// The Intercom hash.
	/// Will be omitted if empty
	/// </summary>
	[JsonProperty(PropertyName = "intercom_hash")]
	public string? IntercomHash { get; set; }

	/// <summary>
	/// OAuth Providees
	/// </summary>
	[JsonProperty(PropertyName = "oauth_providers")]
	public required ICollection<string> OauthProviders { get; set; }

	/// <summary>
	/// The OpenID email
	/// </summary>
	[JsonProperty(PropertyName = "openid_email")]
	public required string? OpenIdEmail { get; set; }

	/// <summary>
	/// Additional properties
	/// Will be omitted if empty
	/// </summary>
	[JsonProperty(PropertyName = "options")]
	public MeOptions? Options { get; set; }

	/// <summary>
	/// Projects, null if with_related_data was not set to true or if the user does not have any projects
	/// </summary>
	[JsonProperty(PropertyName = "projects")]
	public ICollection<Project>? Projects { get; set; }

	/// <summary>
	/// Tags, null if with_related_data was not set to true, or if the user does not have any tags
	/// </summary>
	[JsonProperty(PropertyName = "tags")]
	public ICollection<Tag>? Tags { get; set; }

	/// <summary>
	/// Tasks, null if with_related_data was not set to true or if the user does not have any tasks
	/// </summary>
	[JsonProperty(PropertyName = "tasks")]
	public ICollection<Task>? Tasks { get; set; }

	/// <summary>
	/// TimeEntries, null if with_related_data was not set to true or if the user does not have any time entries
	/// </summary>
	[JsonProperty(PropertyName = "time_entries")]
	public ICollection<TimeEntry>? TimeEntries { get; set; }

	/// <summary>
	/// Time zone
	/// </summary>
	[JsonProperty(PropertyName = "timezone")]
	public required string Timezone { get; set; }

	/// <summary>
	/// Last modified
	/// </summary>
	[JsonProperty(PropertyName = "updated_at")]
	public required DateTimeOffset LastModified { get; set; }

	/// <summary>
	/// Workspaces, null if with_related_data was not set to true or if the user does not have any workspaces
	/// </summary>
	[JsonProperty(PropertyName = "workspaces")]
	public ICollection<Workspace>? Workspaces { get; set; }
}
