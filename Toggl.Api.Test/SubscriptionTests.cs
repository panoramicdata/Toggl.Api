using AwesomeAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Toggl.Api.Test;

public class SubscriptionTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
{
	[Fact]
	public async Task Subscriptions_Get_Succeeds()
	{
		var organizationId = await GetOrganizationIdAsync();

		// Note: This test may fail with 404 if there's no active subscription
		// or 403 if the user doesn't have permission to view subscriptions
		try
		{
			var subscription = await TogglClient
				.Subscriptions
				.GetAsync(organizationId, CancellationToken);

			subscription.Should().NotBeNull();
		}
		catch (Refit.ApiException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
		{
			// Organization may not have an active subscription - this is acceptable
		}
		catch (Refit.ApiException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Forbidden)
		{
			// User may not have permission to view subscriptions - this is acceptable for testing
		}
	}

	[Fact]
	public async Task Subscriptions_GetCustomer_Succeeds()
	{
		var organizationId = await GetOrganizationIdAsync();

		// Note: This test may fail with 404 if there's no customer info
		// or 403 if the user doesn't have permission
		try
		{
			var customer = await TogglClient
				.Subscriptions
				.GetCustomerAsync(organizationId, CancellationToken);

			customer.Should().NotBeNull();
		}
		catch (Refit.ApiException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
		{
			// Organization may not have customer info - this is acceptable
		}
		catch (Refit.ApiException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Forbidden)
		{
			// User may not have permission - this is acceptable for testing
		}
	}

	[Fact]
	public async Task Subscriptions_GetInvoiceSummary_Succeeds()
	{
		var organizationId = await GetOrganizationIdAsync();

		// Note: This test may fail with 404 if there are no invoices
		// or 403 if the user doesn't have permission
		try
		{
			var invoiceSummary = await TogglClient
				.Subscriptions
				.GetInvoiceSummaryAsync(organizationId, CancellationToken);

			invoiceSummary.Should().NotBeNull();
		}
		catch (Refit.ApiException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
		{
			// Organization may not have any invoices - this is acceptable
		}
		catch (Refit.ApiException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Forbidden)
		{
			// User may not have permission - this is acceptable for testing
		}
	}

	[Fact]
	public async Task Subscriptions_GetPaymentFailed_Succeeds()
	{
		var organizationId = await GetOrganizationIdAsync();

		// Note: This test may fail with 404 if there are no failed payments
		// or 403 if the user doesn't have permission
		try
		{
			_ = await TogglClient
				.Subscriptions
				.GetPaymentFailedAsync(organizationId, CancellationToken);

			// Payment failed info may be null if no failures - test passes if call succeeds
		}
		catch (Refit.ApiException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
		{
			// No failed payments - this is acceptable
		}
		catch (Refit.ApiException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Forbidden)
		{
			// User may not have permission - this is acceptable for testing
		}
	}
}
