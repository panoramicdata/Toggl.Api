using Refit;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;

namespace Toggl.Api.Interfaces;

/// <summary>
/// Interface for managing organization invitations
/// https://engineering.toggl.com/docs/api/invitations
/// </summary>
public interface IInvitations
{
	/// <summary>
	/// Gets invitation details by code.
	/// https://engineering.toggl.com/docs/api/invitations#get-load-invitation
	/// </summary>
	/// <param name="invitationCode">The invitation code</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The invitation details</returns>
	[Get("/api/v9/invitations/{invitation_code}")]
	Task<Invitation> GetAsync(
		[AliasAs("invitation_code")] string invitationCode,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Accepts an organization invitation.
	/// https://engineering.toggl.com/docs/api/invitations#post-accepts-invitation
	/// </summary>
	/// <param name="invitationCode">The invitation code</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Post("/api/v9/organizations/invitations/{invitation_code}/accept")]
	Task AcceptAsync(
		[AliasAs("invitation_code")] string invitationCode,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Rejects an organization invitation.
	/// https://engineering.toggl.com/docs/api/invitations#post-rejects-invitation
	/// </summary>
	/// <param name="invitationCode">The invitation code</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Post("/api/v9/organizations/invitations/{invitation_code}/reject")]
	Task RejectAsync(
		[AliasAs("invitation_code")] string invitationCode,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Creates new invitations for users to join an organization.
	/// https://engineering.toggl.com/docs/api/invitations#post-creates-a-new-invitation-for-the-user
	/// </summary>
	/// <param name="organizationId">The organization id</param>
	/// <param name="invitation">The invitation creation data</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The invitation result</returns>
	[Post("/api/v9/organizations/{organization_id}/invitations")]
	Task<InvitationResult> CreateAsync(
		[AliasAs("organization_id")] long organizationId,
		[Body] InvitationCreationDto invitation,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Resends an existing invitation.
	/// https://engineering.toggl.com/docs/api/invitations#put-resends-user-their-invitation
	/// </summary>
	/// <param name="organizationId">The organization id</param>
	/// <param name="invitationId">The invitation id</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Put("/api/v9/organizations/{organization_id}/invitations/{invitation_id}/resend")]
	Task ResendAsync(
		[AliasAs("organization_id")] long organizationId,
		[AliasAs("invitation_id")] long invitationId,
		CancellationToken cancellationToken
		);
}
