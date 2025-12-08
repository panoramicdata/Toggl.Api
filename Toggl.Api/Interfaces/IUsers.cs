using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;

namespace Toggl.Api.Interfaces;

/// <summary>
/// Interface for managing workspace users
/// https://engineering.toggl.com/docs/api/workspaces#users
/// </summary>
public interface IUsers
{
	/// <summary>
	/// Returns all users in a workspace.
	/// https://engineering.toggl.com/docs/api/workspaces#get-workspace-users
	/// </summary>
	/// <param name="workspaceId">Numeric ID of the workspace</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>List of workspace users</returns>
	[Get("/api/v9/workspaces/{workspace_id}/users")]
	Task<ICollection<WorkspaceUser>> GetAsync(
		[AliasAs("workspace_id")] long workspaceId,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Updates a workspace user.
	/// https://engineering.toggl.com/docs/api/workspaces#put-update-workspace-user
	/// </summary>
	/// <param name="workspaceId">Numeric ID of the workspace</param>
	/// <param name="userId">Numeric ID of the user</param>
	/// <param name="user">The user update data</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The updated workspace user</returns>
	[Put("/api/v9/workspaces/{workspace_id}/users/{user_id}")]
	Task<WorkspaceUser> UpdateAsync(
		[AliasAs("workspace_id")] long workspaceId,
		[AliasAs("user_id")] long userId,
		[Body] WorkspaceUserUpdateDto user,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Returns all workspace users (detailed view with assignments).
	/// https://engineering.toggl.com/docs/api/workspaces#get-workspace-workspace-users
	/// </summary>
	/// <param name="workspaceId">Numeric ID of the workspace</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>List of workspace users with assignments</returns>
	[Get("/api/v9/workspaces/{workspace_id}/workspace_users")]
	Task<ICollection<WorkspaceUser>> GetWorkspaceUsersAsync(
		[AliasAs("workspace_id")] long workspaceId,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Updates a workspace user assignment.
	/// https://engineering.toggl.com/docs/api/workspaces#put-update-workspace-workspace-user
	/// </summary>
	/// <param name="workspaceId">Numeric ID of the workspace</param>
	/// <param name="workspaceUserId">Numeric ID of the workspace user assignment</param>
	/// <param name="user">The user update data</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns>The updated workspace user</returns>
	[Put("/api/v9/workspaces/{workspace_id}/workspace_users/{workspace_user_id}")]
	Task<WorkspaceUser> UpdateWorkspaceUserAsync(
		[AliasAs("workspace_id")] long workspaceId,
		[AliasAs("workspace_user_id")] long workspaceUserId,
		[Body] WorkspaceUserUpdateDto user,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Removes a user from the workspace.
	/// https://engineering.toggl.com/docs/api/workspaces#delete-workspace-workspace-user
	/// </summary>
	/// <param name="workspaceId">Numeric ID of the workspace</param>
	/// <param name="workspaceUserId">Numeric ID of the workspace user assignment</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Delete("/api/v9/workspaces/{workspace_id}/workspace_users/{workspace_user_id}")]
	Task DeleteWorkspaceUserAsync(
		[AliasAs("workspace_id")] long workspaceId,
		[AliasAs("workspace_user_id")] long workspaceUserId,
		CancellationToken cancellationToken
		);
}