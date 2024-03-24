using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

public class Organization : IdentifiedItem
{
	/// <summary>
	/// Whether the requester is an admin of the organization
	/// </summary>
	[JsonPropertyName("admin")]
	public bool IsAdmin { get; set; }

	/// <summary>
	/// Organization's last modification date
	/// </summary>
	[JsonPropertyName("at")]
	public DateTimeOffset LastModified { get; set; }

	/// <summary>
	/// Organization's creation date
	/// </summary>
	[JsonPropertyName("created_at")]
	public DateTimeOffset Created { get; set; }

	/// <summary>
	/// Is true when the organization option is_multi_workspace_enabled is set
	/// </summary>
	[JsonPropertyName("is_multi_workspace_enabled")]
	public bool IsMultiWorkspaceEnabled { get; set; }

	/// <summary>
	/// Undocumented parameter (docs just say '-')
	/// </summary>
	[JsonPropertyName("is_unified")]
	public bool IsUnified { get; set; }

	/// <summary>
	/// How far back free workspaces in this org can access data.
	/// </summary>
	[JsonPropertyName("max_data_retention_days")]
	public int MaxDataRetentionDays { get; set; }

	/// <summary>
	/// Maximum number of workspaces allowed for the organization
	/// </summary>
	[JsonPropertyName("max_workspaces")]
	public int MaxWorkspaces { get; set; }

	/// <summary>
	/// Organization Name
	/// </summary>
	[JsonPropertyName("name")]
	public required string Name { get; set; }

	/// <summary>
	/// Whether the requester is a the owner of the organization
	/// </summary>
	[JsonPropertyName("owner")]
	public bool IsOwner { get; set; }

	/// <summary>
	/// Organization's subscription payment methods. Omitted if empty.
	/// </summary>
	[JsonPropertyName("payment_methods")]
	public required ICollection<PaymentMethod> PaymentMethods { get; set; }

	/// <summary>
	/// Undocumented property (docs just say '-')
	/// </summary>
	[JsonPropertyName("permissions")]
	public string? Permissions { get; set; }

	/// <summary>
	/// Organization plan ID
	/// </summary>
	[JsonPropertyName("pricing_plan_id")]
	public int PricingPlanId { get; set; }

	/// <summary>
	/// Organization's delete date
	/// </summary>
	[JsonPropertyName("server_deleted_at")]
	public DateTimeOffset? ServerDeletedAt { get; set; }

	/// <summary>
	/// Whether the organization is currently suspended
	/// </summary>
	[JsonPropertyName("suspended_at")]
	public DateTimeOffset? SuspendedAt { get; set; }

	/// <summary>
	/// Undocumented property (docs just say '-')
	/// </summary>
	[JsonPropertyName("trial_info")]
	public required TrialInfo TrialInfo { get; set; }

	/// <summary>
	/// Number of organization users
	/// </summary>
	[JsonPropertyName("user_count")]
	public int UserCount { get; set; }
}