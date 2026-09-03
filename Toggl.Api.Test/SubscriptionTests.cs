using AwesomeAssertions;
using Refit;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Toggl.Api.Test;

public class SubscriptionTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
{
	[Fact]
	public Task Subscriptions_Get_Succeeds()
		=> CallSubscriptionEndpointAsync(organizationId => TogglClient
			.Subscriptions
			.GetAsync(organizationId, CancellationToken));

	[Fact]
	public Task Subscriptions_GetCustomer_Succeeds()
		=> CallSubscriptionEndpointAsync(organizationId => TogglClient
			.Subscriptions
			.GetCustomerAsync(organizationId, CancellationToken));

	[Fact]
	public Task Subscriptions_GetInvoiceSummary_Succeeds()
		=> CallSubscriptionEndpointAsync(organizationId => TogglClient
			.Subscriptions
			.GetInvoiceSummaryAsync(organizationId, CancellationToken));

	[Fact]
	// Payment failed info may be null if there are no failures, so the call succeeding is all
	// that is asserted here.
	public Task Subscriptions_GetPaymentFailed_Succeeds()
		=> CallSubscriptionEndpointAsync(
			organizationId => TogglClient
				.Subscriptions
				.GetPaymentFailedAsync(organizationId, CancellationToken),
			assertNotNull: false);

	/// <summary>
	/// Calls a subscription endpoint for the test organization and asserts that it returns a result.
	/// </summary>
	/// <remarks>
	/// The test organization may legitimately have no subscription, customer record or invoices
	/// (404), and the test user may not be permitted to view them (403).  Neither is a failure of
	/// the client, so both are accepted.
	/// </remarks>
	/// <param name="callAsync">Invokes the endpoint under test.</param>
	/// <param name="assertNotNull">Whether a successful call is expected to return a non-null result.</param>
	private async Task CallSubscriptionEndpointAsync<T>(
		Func<long, Task<T>> callAsync,
		bool assertNotNull = true)
	{
		var organizationId = await GetOrganizationIdAsync();

		try
		{
			var result = await callAsync(organizationId);

			if (assertNotNull)
			{
				result.Should().NotBeNull();
			}
		}
		catch (ApiException ex) when (ex.StatusCode is HttpStatusCode.NotFound or HttpStatusCode.Forbidden)
		{
			// Acceptable: see the remarks above.
		}
	}
}
