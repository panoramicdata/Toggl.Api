using System.Text.Json.Serialization;

namespace Toggl.Api.Models
{
	public class Rate
	{
		/// <summary>
		/// The billable seconds
		/// </summary>
		[JsonPropertyName("billable_seconds")]
		public int BillableSeconds { get; set; }

		/// <summary>
		/// The currency
		/// </summary>
		[JsonPropertyName("currency")]
		public string Currency { get; set; } = string.Empty;

		/// <summary>
		/// The hourly rate in cents
		/// </summary>
		[JsonPropertyName("hourly_rate_in_cents")]
		public int HourlyRateInCents { get; set; }
	}
}
