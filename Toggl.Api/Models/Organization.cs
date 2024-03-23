using Newtonsoft.Json;
using System;

namespace Toggl.Api.Models;

public class Organization : IdentifiedItem
{
	/// <summary>
	/// Whether the requester is an admin of the organization
	/// </summary>
	[JsonProperty(PropertyName = "admin")]
	public bool IsAdmin { get; set; }

	/// <summary>
	/// Organization's last modification date
	/// </summary>
	[JsonProperty(PropertyName = "at")]
	public DateTimeOffset LastModified { get; set; }

	/// <summary>
	/// Organization's creation date
	/// </summary>
	[JsonProperty(PropertyName = "created_at")]
	public DateTimeOffset Created { get; set; }

	/// <summary>
	/// Is true when the organization option is_multi_workspace_enabled is set
	/// </summary>
	[JsonProperty(PropertyName = "is_multi_workspace_enabled")]
	public bool IsMultiWorkspaceEnabled { get; set; }

	/// <summary>
	/// Undocumented parameter (docs just say '-')
	/// </summary>
	[JsonProperty(PropertyName = "is_unified")]
	public bool IsUnified { get; set; }

	/// <summary>
	/// How far back free workspaces in this org can access data.
	/// </summary>
	[JsonProperty(PropertyName = "max_data_retention_days")]
	public int MaxDataRetentionDays { get; set; }

	/// <summary>
	/// Maximum number of workspaces allowed for the organization
	/// </summary>
	[JsonProperty(PropertyName = "max_workspaces")]
	public int MaxWorkspaces { get; set; }

	/// <summary>
	/// Organization Name
	/// </summary>
	[JsonProperty(PropertyName = "name")]
	public required string Name { get; set; }

	/// <summary>
	/// Whether the requester is a the owner of the organization
	/// </summary>
	[JsonProperty(PropertyName = "owner")]
	public bool IsOwner { get; set; }

	/// <summary>
	/// Organization's subscription payment methods. Omitted if empty.
	/// </summary>
	[JsonProperty(PropertyName = "payment_methods")]
	public required string PaymentMethods { get; set; }

	/// <summary>
	/// Undocumented property (docs just say '-')
	/// </summary>
	[JsonProperty(PropertyName = "permissions")]
	public required string Permissions { get; set; }

	/// <summary>
	/// Organization plan ID
	/// </summary>
	[JsonProperty(PropertyName = "pricing_plan_id")]
	public int PricingPlanId { get; set; }

	/// <summary>
	/// Organization's delete date
	/// </summary>
	[JsonProperty(PropertyName = "server_deleted_at")]
	public DateTimeOffset? ServerDeletedAt { get; set; }

	/// <summary>
	/// Whether the organization is currently suspended
	/// </summary>
	[JsonProperty(PropertyName = "suspended_at")]
	public DateTimeOffset? SuspendedAt { get; set; }

	/// <summary>
	/// Undocumented property (docs just say '-')
	/// </summary>
	[JsonProperty(PropertyName = "trial_info")]
	public required TrialInfo TrialInfo { get; set; }

	/// <summary>
	/// Number of organization users
	/// </summary>
	[JsonProperty(PropertyName = "user_count")]
	public int UserCount { get; set; }
}