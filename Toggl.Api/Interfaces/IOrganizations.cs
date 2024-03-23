using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;

namespace Toggl.Api.Interfaces;

/// <summary>
/// https://engineering.toggl.com/docs/api/organizations
/// </summary>
public interface IOrganizations
{
	/// <summary>
	/// Creates a new organization
	/// https://engineering.toggl.com/docs/api/organizations#post-creates-a-new-organization
	/// </summary>
	/// <param name="organization">The organization to create</param>
	/// <returns></returns>
	[Post("/api/v9/organizations")]
	Task<Organization> CreateAsync(
		[Body] OrganizationCreationDto organization,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// GET Organization data
	/// https://engineering.toggl.com/docs/api/organizations#get-organization-data
	/// </summary>
	/// <param name="organization">The organization to create</param>
	/// <returns></returns>
	[Get("/api/v9/organizations/{organization_id}")]
	Task<Organization> GetAsync(
		[AliasAs("organization_id")] long organizationId,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Updates an existing organization
	/// https://engineering.toggl.com/docs/api/organizations#put-updates-an-existing-organization
	/// </summary>
	/// <param name="organizationId">The organization id</param>
	/// <param name="organization">The organization to create</param>
	/// <returns></returns>
	[Put("/api/v9/organizations/{organization_id}")]
	Task<Organization> UpdateAsync(
		[AliasAs("organization_id")] long organizationId,
		[Body] OrganizationUpdateDto organization,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// GET List of users in organization
	/// https://engineering.toggl.com/docs/api/organizations#get-list-of-users-in-organization
	/// </summary>
	/// <param name="organizationId">The organization id</param>
	/// <param name="organizationUsersQuery">The organization users query</param>
	/// <returns></returns>
	[Get("/api/v9/organizations/{organization_id}/users")]
	Task<ICollection<OrganizationUser>> GetUsersAsync(
		[AliasAs("organization_id")] long organizationId,
		[Body] OrganizationUsersQuery organizationUsersQuery,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Apply changes in bulk to users in an organization (currently deletion only).
	/// https://engineering.toggl.com/docs/api/organizations#patch-apply-changes-in-bulk-to-users-in-an-organization
	/// </summary>
	/// <param name="organizationId">The organization id</param>
	/// <param name="userIds">The ids of users to delete</param>
	/// <returns></returns>
	[Patch("/api/v9/organizations/{organization_id}/users")]
	Task<ICollection<OrganizationUser>> DeleteUsersAsync(
		[AliasAs("organization_id")] long organizationId,
		[Body] ICollection<int> userIds,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Leaves organization, effectively delete user account in org and delete organization if it is last user
	/// https://engineering.toggl.com/docs/api/organizations#delete-leaves-organization
	/// </summary>
	/// <param name="organizationId">The organization id</param>
	/// <returns></returns>
	[Delete("/api/v9/organizations/{organization_id}/users")]
	Task<ICollection<OrganizationUser>> LeaveAsync(
		[AliasAs("organization_id")] long organizationId,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Changes a single organization-user.
	/// https://engineering.toggl.com/docs/api/organizations#delete-leaves-organization
	/// </summary>
	/// <param name="organizationId">The organization id</param>
	/// <returns></returns>
	[Put("/api/v9/organizations/{organization_id}/users/{organization_user_id}")]
	Task<ICollection<OrganizationUser>> LeaveAsync(
		[AliasAs("organization_id")] long organizationId,
		[AliasAs("organization_user_id")] long organizationUserId,
		[Body] OrganizationUserUpdateDto organizationUser,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Returns map indexed by workspace ID where each map element contains workspace admins list, members count and groups count.
	/// There is no documentation for this endpoint.
	/// https://engineering.toggl.com/docs/api/organizations#get-statistics-for-all-workspaces-in-the-organization
	/// </summary>
	/// <param name="organizationId">The organization id</param>
	/// <returns></returns>
	[Get("/api/v9/organizations/{organization_id}/workspaces/statistics")]
	Task<object> GetStatisticsAsync(
		[AliasAs("organization_id")] long organizationId,
		CancellationToken cancellationToken
		);
}

