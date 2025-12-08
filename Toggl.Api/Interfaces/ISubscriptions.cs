using Refit;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;

namespace Toggl.Api.Interfaces;

/// <summary>
/// Subscription and billing management endpoints
/// https://engineering.toggl.com/docs/api/subscription
/// </summary>
public interface ISubscriptions
{
	#region Subscription CRUD

	/// <summary>
	/// Gets the subscription for an organization.
	/// https://engineering.toggl.com/docs/api/subscription#get-subscription
	/// </summary>
	/// <param name="organizationId">The organization ID</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The subscription</returns>
	[Get("/api/v9/organizations/{organization_id}/subscription")]
	Task<Subscription> GetAsync(
		[AliasAs("organization_id")] long organizationId,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Creates a subscription for an organization.
	/// https://engineering.toggl.com/docs/api/subscription#post-subscription
	/// </summary>
	/// <param name="organizationId">The organization ID</param>
	/// <param name="subscription">The subscription details</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The created subscription</returns>
	[Post("/api/v9/organizations/{organization_id}/subscription")]
	Task<Subscription> CreateAsync(
		[AliasAs("organization_id")] long organizationId,
		[Body] SubscriptionCreationDto subscription,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Updates a subscription for an organization.
	/// https://engineering.toggl.com/docs/api/subscription#put-subscription
	/// </summary>
	/// <param name="organizationId">The organization ID</param>
	/// <param name="subscription">The subscription details</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The updated subscription</returns>
	[Put("/api/v9/organizations/{organization_id}/subscription")]
	Task<Subscription> UpdateAsync(
		[AliasAs("organization_id")] long organizationId,
		[Body] SubscriptionCreationDto subscription,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Cancels a subscription for an organization.
	/// https://engineering.toggl.com/docs/api/subscription#delete-subscription
	/// </summary>
	/// <param name="organizationId">The organization ID</param>
	/// <param name="cancellationToken">The cancellation token</param>
	[Delete("/api/v9/organizations/{organization_id}/subscription")]
	Task DeleteAsync(
		[AliasAs("organization_id")] long organizationId,
		CancellationToken cancellationToken
		);

	#endregion

	#region Customer

	/// <summary>
	/// Gets the customer information for a subscription.
	/// https://engineering.toggl.com/docs/api/subscription#get-subscription-customer
	/// </summary>
	/// <param name="organizationId">The organization ID</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The subscription customer</returns>
	[Get("/api/v9/organizations/{organization_id}/subscription/customer")]
	Task<SubscriptionCustomer> GetCustomerAsync(
		[AliasAs("organization_id")] long organizationId,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Creates customer information for a subscription.
	/// https://engineering.toggl.com/docs/api/subscription#post-subscription-customer
	/// </summary>
	/// <param name="organizationId">The organization ID</param>
	/// <param name="customer">The customer details</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The created subscription customer</returns>
	[Post("/api/v9/organizations/{organization_id}/subscription/customer")]
	Task<SubscriptionCustomer> CreateCustomerAsync(
		[AliasAs("organization_id")] long organizationId,
		[Body] SubscriptionCustomerDto customer,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Updates customer information for a subscription.
	/// https://engineering.toggl.com/docs/api/subscription#put-subscription-customer
	/// </summary>
	/// <param name="organizationId">The organization ID</param>
	/// <param name="customer">The customer details</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The updated subscription customer</returns>
	[Put("/api/v9/organizations/{organization_id}/subscription/customer")]
	Task<SubscriptionCustomer> UpdateCustomerAsync(
		[AliasAs("organization_id")] long organizationId,
		[Body] SubscriptionCustomerDto customer,
		CancellationToken cancellationToken
		);

	#endregion

	#region Trial

	/// <summary>
	/// Starts a trial subscription for an organization.
	/// https://engineering.toggl.com/docs/api/subscription#post-subscription-trial
	/// </summary>
	/// <param name="organizationId">The organization ID</param>
	/// <param name="trial">The trial details</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The subscription with trial</returns>
	[Post("/api/v9/organizations/{organization_id}/subscription/trial")]
	Task<Subscription> StartTrialAsync(
		[AliasAs("organization_id")] long organizationId,
		[Body] SubscriptionTrialDto trial,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Cancels a trial subscription for an organization.
	/// https://engineering.toggl.com/docs/api/subscription#delete-subscription-trial
	/// </summary>
	/// <param name="organizationId">The organization ID</param>
	/// <param name="cancellationToken">The cancellation token</param>
	[Delete("/api/v9/organizations/{organization_id}/subscription/trial")]
	Task CancelTrialAsync(
		[AliasAs("organization_id")] long organizationId,
		CancellationToken cancellationToken
		);

	#endregion

	#region Invoice Summary

	/// <summary>
	/// Gets the invoice summary for a subscription.
	/// https://engineering.toggl.com/docs/api/subscription#get-subscription-invoice-summary
	/// </summary>
	/// <param name="organizationId">The organization ID</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The invoice summary</returns>
	[Get("/api/v9/organizations/{organization_id}/subscription/invoice_summary")]
	Task<InvoiceSummary> GetInvoiceSummaryAsync(
		[AliasAs("organization_id")] long organizationId,
		CancellationToken cancellationToken
		);

	#endregion

	#region Payment Failed

	/// <summary>
	/// Gets payment failure information for a subscription.
	/// https://engineering.toggl.com/docs/api/subscription#get-subscription-payment-failed
	/// </summary>
	/// <param name="organizationId">The organization ID</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>Payment failure information</returns>
	[Get("/api/v9/organizations/{organization_id}/subscription/payment_failed")]
	Task<PaymentFailedInfo> GetPaymentFailedAsync(
		[AliasAs("organization_id")] long organizationId,
		CancellationToken cancellationToken
		);

	#endregion

	#region Promo Code

	/// <summary>
	/// Applies a promo code to a subscription.
	/// https://engineering.toggl.com/docs/api/subscription#post-subscription-promocode
	/// </summary>
	/// <param name="organizationId">The organization ID</param>
	/// <param name="promoCode">The promo code details</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The updated subscription</returns>
	[Post("/api/v9/organizations/{organization_id}/subscription/promocode")]
	Task<Subscription> ApplyPromoCodeAsync(
		[AliasAs("organization_id")] long organizationId,
		[Body] SubscriptionPromoCodeDto promoCode,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Removes a promo code from a subscription.
	/// https://engineering.toggl.com/docs/api/subscription#delete-subscription-promocode
	/// </summary>
	/// <param name="organizationId">The organization ID</param>
	/// <param name="cancellationToken">The cancellation token</param>
	[Delete("/api/v9/organizations/{organization_id}/subscription/promocode")]
	Task RemovePromoCodeAsync(
		[AliasAs("organization_id")] long organizationId,
		CancellationToken cancellationToken
		);

	#endregion

	#region Invoice Download

	/// <summary>
	/// Downloads an invoice PDF for an organization.
	/// https://engineering.toggl.com/docs/api/subscription#get-invoice-pdf
	/// </summary>
	/// <param name="organizationId">The organization ID</param>
	/// <param name="invoiceUid">The invoice UID</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The invoice PDF stream</returns>
	[Get("/api/v9/organizations/{organization_id}/invoices/{invoice_uid}.pdf")]
	Task<Stream> DownloadInvoiceAsync(
		[AliasAs("organization_id")] long organizationId,
		[AliasAs("invoice_uid")] string invoiceUid,
		CancellationToken cancellationToken
		);

	#endregion
}
