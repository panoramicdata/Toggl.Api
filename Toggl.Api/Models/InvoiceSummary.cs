using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Toggl.Api.Models;

/// <summary>
/// Represents invoice summary information
/// https://engineering.toggl.com/docs/api/subscription
/// </summary>
public class InvoiceSummary
{
	/// <summary>
	/// Amount due in cents
	/// </summary>
	[JsonPropertyName("amount_due_in_cents")]
	public long? AmountDueInCents { get; set; }

	/// <summary>
	/// Currency code
	/// </summary>
	[JsonPropertyName("currency")]
	public string? Currency { get; set; }

	/// <summary>
	/// Due date
	/// </summary>
	[JsonPropertyName("due_date")]
	public DateTimeOffset? DueDate { get; set; }

	/// <summary>
	/// Invoice number
	/// </summary>
	[JsonPropertyName("invoice_number")]
	public string? InvoiceNumber { get; set; }

	/// <summary>
	/// Invoice UID
	/// </summary>
	[JsonPropertyName("invoice_uid")]
	public string? InvoiceUid { get; set; }

	/// <summary>
	/// Issue date
	/// </summary>
	[JsonPropertyName("issue_date")]
	public DateTimeOffset? IssueDate { get; set; }

	/// <summary>
	/// Payment status
	/// </summary>
	[JsonPropertyName("status")]
	public string? Status { get; set; }

	/// <summary>
	/// Subtotal in cents
	/// </summary>
	[JsonPropertyName("subtotal_in_cents")]
	public long? SubtotalInCents { get; set; }

	/// <summary>
	/// Tax in cents
	/// </summary>
	[JsonPropertyName("tax_in_cents")]
	public long? TaxInCents { get; set; }

	/// <summary>
	/// Total in cents
	/// </summary>
	[JsonPropertyName("total_in_cents")]
	public long? TotalInCents { get; set; }

	/// <summary>
	/// Pricing plan tag
	/// </summary>
	[JsonPropertyName("pricing_plan_tag")]
	public string? PricingPlanTag { get; set; }

	/// <summary>
	/// Total amount
	/// </summary>
	[JsonPropertyName("total_amount")]
	public JsonElement? TotalAmount { get; set; }

	/// <summary>
	/// Total tax amount
	/// </summary>
	[JsonPropertyName("total_tax_amount")]
	public JsonElement? TotalTaxAmount { get; set; }

	/// <summary>
	/// Total discount amount
	/// </summary>
	[JsonPropertyName("total_discount_amount")]
	public JsonElement? TotalDiscountAmount { get; set; }

	/// <summary>
	/// Total amount without discount
	/// </summary>
	[JsonPropertyName("total_amount_without_discount")]
	public JsonElement? TotalAmountWithoutDiscount { get; set; }

	/// <summary>
	/// Additional undocumented invoice summary fields
	/// </summary>
	[JsonExtensionData]
	public Dictionary<string, JsonElement>? ExtensionData { get; set; }
}
