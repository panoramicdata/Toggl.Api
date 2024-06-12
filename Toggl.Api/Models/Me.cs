using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/me#get-me
/// </summary>
public class Me : IdentifiedItem
{
	/// <summary>
	/// Will be omitted if empty
	/// </summary>
	[JsonPropertyName("api_token")]
	public required string ApiToken { get; set; }

	/// <summary>
	/// Last modified
	/// </summary>
	[JsonPropertyName("at")]
	public required DateTimeOffset At { get; set; }

	/// <summary>
	/// The first day of the user's week
	/// </summary>
	[JsonPropertyName("beginning_of_week")]
	public int BeginningOfWeek { get; set; }

	/// <summary>
	/// Clients, null if with_related_data was not set to true or if the user does not have any clients
	/// </summary>
	[JsonPropertyName("clients")]
	public ICollection<Client>? Clients { get; set; }

	/// <summary>
	/// country_id
	/// </summary>
	[JsonPropertyName("country_id")]
	public int CountryId { get; set; }

	/// <summary>
	/// Created
	/// </summary>
	[JsonPropertyName("created_at")]
	public required DateTimeOffset Created { get; set; }

	/// <summary>
	/// The default workspace id
	/// </summary>
	[JsonPropertyName("default_workspace_id")]
	public required long DefaultWorkspaceId { get; set; }

	/// <summary>
	/// Email
	/// </summary>
	[JsonPropertyName("email")]
	public required string Email { get; set; }

	/// <summary>
	/// The full name
	/// </summary>
	[JsonPropertyName("fullname")]
	public required string FullName { get; set; }

	/// <summary>
	/// Whether the user has a password
	/// </summary>
	[JsonPropertyName("has_password")]
	public bool HasPassword { get; set; }

	/// <summary>
	/// The image URL
	/// </summary>
	[JsonPropertyName("image_url")]
	public required string ImageUrl { get; set; }

	/// <summary>
	/// The Intercom hash.
	/// Will be omitted if empty
	/// </summary>
	[JsonPropertyName("intercom_hash")]
	public string? IntercomHash { get; set; }

	/// <summary>
	/// OAuth Providees
	/// </summary>
	[JsonPropertyName("oauth_providers")]
	public ICollection<string>? OauthProviders { get; set; }

	/// <summary>
	/// Whether OpenID is enabled
	/// </summary>
	[JsonPropertyName("openid_enabled")]
	public required bool IsOpenIdEnabled { get; set; }

	/// <summary>
	/// The OpenID email
	/// </summary>
	[JsonPropertyName("openid_email")]
	public required string? OpenIdEmail { get; set; }

	/// <summary>
	/// Additional properties
	/// Will be omitted if empty
	/// </summary>
	[JsonPropertyName("options")]
	public MeOptions? Options { get; set; }

	/// <summary>
	/// Projects, null if with_related_data was not set to true or if the user does not have any projects
	/// </summary>
	[JsonPropertyName("projects")]
	public ICollection<Project>? Projects { get; set; }

	/// <summary>
	/// Tags, null if with_related_data was not set to true, or if the user does not have any tags
	/// </summary>
	[JsonPropertyName("tags")]
	public ICollection<Tag>? Tags { get; set; }

	/// <summary>
	/// Tasks, null if with_related_data was not set to true or if the user does not have any tasks
	/// </summary>
	[JsonPropertyName("tasks")]
	public ICollection<ProjectTask>? Tasks { get; set; }

	/// <summary>
	/// TimeEntries, null if with_related_data was not set to true or if the user does not have any time entries
	/// </summary>
	[JsonPropertyName("time_entries")]
	public ICollection<TimeEntry>? TimeEntries { get; set; }

	/// <summary>
	/// Time zone
	/// </summary>
	[JsonPropertyName("timezone")]
	public required string Timezone { get; set; }

	/// <summary>
	/// Last modified
	/// </summary>
	[JsonPropertyName("updated_at")]
	public required DateTimeOffset LastModified { get; set; }

	/// <summary>
	/// Workspaces, null if with_related_data was not set to true or if the user does not have any workspaces
	/// </summary>
	[JsonPropertyName("workspaces")]
	public ICollection<Workspace>? Workspaces { get; set; }

	/// <summary>
	/// The Toggl Account id
	/// </summary>
	[JsonPropertyName("toggl_accounts_id")]
	public required string TogglAccountsId { get; set; }

	/// <summary>
	/// When authorization was updated
	/// </summary>
	[JsonPropertyName("authorization_updated_at")]
	public DateTimeOffset? AuthorizationUpdatedAt { get; set; }
}
