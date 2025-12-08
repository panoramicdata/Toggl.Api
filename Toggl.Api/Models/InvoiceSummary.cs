using System;
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
}
