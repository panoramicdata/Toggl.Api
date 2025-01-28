﻿using System.Text.Json.Serialization;
using System;

namespace Toggl.Api.Models;

/// <summary>
/// https://engineering.toggl.com/docs/api/organizations#get-organization-data
/// </summary>
public class TrialInfo
{
	/// <summary>
	/// 	CanHaveInitialTrial is true if neither the organization nor the owner has never had a trial before
	/// </summary>
	[JsonPropertyName("can_have_trial")]
	public bool CanHaveTrial { get; set; }

	/// <summary>
	/// 	What was the previous plan before the trial
	/// </summary>
	[JsonPropertyName("last_pricing_plan_id")]
	public int? LastPricingPlanId { get; set; }

	/// <summary>
	/// 	When the trial payment is due
	/// </summary>
	[JsonPropertyName("next_payment_date")]
	public DateTimeOffset? NextPaymentDate { get; set; }

	/// <summary>
	/// 	Whether the organization's subscription is currently on trial
	/// </summary>
	[JsonPropertyName("trial")]
	public bool IsTrial { get; set; }

	/// <summary>
	/// 	When a trial is available for this organization
	/// </summary>
	[JsonPropertyName("trial_available")]
	public bool IsTrialAvailable { get; set; }

	/// <summary>
	/// 	When the trial ends
	/// </summary>
	[JsonPropertyName("trial_end_date")]
	public DateTimeOffset? TrialEndDate { get; set; }

	/// <summary>
	/// 	The trial plan ID
	/// </summary>
	[JsonPropertyName("trial_plan_id")]
	public int? TrialPlanId { get; set; }
}