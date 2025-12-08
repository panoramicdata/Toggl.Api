using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;

namespace Toggl.Api.Interfaces;

/// <summary>
/// https://engineering.toggl.com/docs/api/groups
/// </summary>
public interface IGroups
{
	#region Organization Groups

	/// <summary>
	/// Returns list of groups in organization based on set of url parameters. List is sorted by name.
	/// https://engineering.toggl.com/docs/api/groups#get-list-of-groups-in-organization-with-user-and-workspace-assignments
	/// </summary>
	/// <param name="organizationId">Numeric ID of the organization</param>
	/// <param name="nameContains">Returns records where name contains this string</param>
	/// <param name="workspaceId">ID of workspace. Returns groups assigned to this workspace</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/organizations/{organization_id}/groups")]
	Task<ICollection<Group>> GetAsync(
		[AliasAs("organization_id")] long organizationId,
		[AliasAs("name")] string? nameContains,
		[AliasAs("workspace")] int? workspaceId,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Creates a new group in the organization.
	/// https://engineering.toggl.com/docs/api/groups#post-create-group
	/// </summary>
	/// <param name="organizationId">Numeric ID of the organization</param>
	/// <param name="group">The group to create</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The created group</returns>
	[Post("/api/v9/organizations/{organization_id}/groups")]
	Task<Group> CreateAsync(
		[AliasAs("organization_id")] long organizationId,
		[Body] GroupCreationDto group,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Updates an existing group.
	/// https://engineering.toggl.com/docs/api/groups#put-update-group
	/// </summary>
	/// <param name="organizationId">Numeric ID of the organization</param>
	/// <param name="groupId">Numeric ID of the group</param>
	/// <param name="group">The group update data</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The updated group</returns>
	[Put("/api/v9/organizations/{organization_id}/groups/{group_id}")]
	Task<Group> UpdateAsync(
		[AliasAs("organization_id")] long organizationId,
		[AliasAs("group_id")] long groupId,
		[Body] GroupUpdateDto group,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Deletes a group from the organization.
	/// https://engineering.toggl.com/docs/api/groups#delete-delete-group
	/// </summary>
	/// <param name="organizationId">Numeric ID of the organization</param>
	/// <param name="groupId">Numeric ID of the group</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Delete("/api/v9/organizations/{organization_id}/groups/{group_id}")]
	Task DeleteAsync(
		[AliasAs("organization_id")] long organizationId,
		[AliasAs("group_id")] long groupId,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Patches a group (add/remove users or workspaces).
	/// https://engineering.toggl.com/docs/api/groups#patch-patch-group
	/// </summary>
	/// <param name="organizationId">Numeric ID of the organization</param>
	/// <param name="groupId">Numeric ID of the group</param>
	/// <param name="patchOperations">The patch operations to apply</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The patched group</returns>
	[Patch("/api/v9/organizations/{organization_id}/groups/{group_id}")]
	Task<Group> PatchAsync(
		[AliasAs("organization_id")] long organizationId,
		[AliasAs("group_id")] long groupId,
		[Body] ICollection<GroupPatchDto> patchOperations,
		CancellationToken cancellationToken
		);

	#endregion

	#region Workspace Groups

	/// <summary>
	/// Returns list of groups in a workspace.
	/// https://engineering.toggl.com/docs/api/groups#get-workspace-groups
	/// </summary>
	/// <param name="workspaceId">Numeric ID of the workspace</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>List of groups in the workspace</returns>
	[Get("/api/v9/workspaces/{workspace_id}/groups")]
	Task<ICollection<Group>> GetWorkspaceGroupsAsync(
		[AliasAs("workspace_id")] long workspaceId,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Creates a new group in the workspace.
	/// https://engineering.toggl.com/docs/api/groups#post-workspace-group
	/// </summary>
	/// <param name="workspaceId">Numeric ID of the workspace</param>
	/// <param name="group">The group to create</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The created group</returns>
	[Post("/api/v9/workspaces/{workspace_id}/groups")]
	Task<Group> CreateWorkspaceGroupAsync(
		[AliasAs("workspace_id")] long workspaceId,
		[Body] GroupCreationDto group,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Updates a group in the workspace.
	/// https://engineering.toggl.com/docs/api/groups#put-workspace-group
	/// </summary>
	/// <param name="workspaceId">Numeric ID of the workspace</param>
	/// <param name="groupId">Numeric ID of the group</param>
	/// <param name="group">The group update data</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The updated group</returns>
	[Put("/api/v9/workspaces/{workspace_id}/groups/{group_id}")]
	Task<Group> UpdateWorkspaceGroupAsync(
		[AliasAs("workspace_id")] long workspaceId,
		[AliasAs("group_id")] long groupId,
		[Body] GroupUpdateDto group,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Deletes a group from the workspace.
	/// https://engineering.toggl.com/docs/api/groups#delete-workspace-group
	/// </summary>
	/// <param name="workspaceId">Numeric ID of the workspace</param>
	/// <param name="groupId">Numeric ID of the group</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Delete("/api/v9/workspaces/{workspace_id}/groups/{group_id}")]
	Task DeleteWorkspaceGroupAsync(
		[AliasAs("workspace_id")] long workspaceId,
		[AliasAs("group_id")] long groupId,
		CancellationToken cancellationToken
		);

	#endregion
}
