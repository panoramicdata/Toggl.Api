using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;

namespace Toggl.Api.Interfaces;

/// <summary>
/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/users.md#users
/// </summary>
public interface IGroups
{
	/// <summary>
	/// Returns list of groups in organization based on set of url parameters. List is sorted by name.
	/// https://engineering.toggl.com/docs/api/groups#get-list-of-groups-in-organization-with-user-and-workspace-assignments
	/// </summary>
	/// <param name="organizationId">Numeric ID of the organization</param>
	/// <param name="workspaceId">ID of workspace. Returns groups assigned to this workspace</param>
	/// <param name="nameContains">Returns records where name contains this string</param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/organizations/{organization_id}/groups")]
	Task<ICollection<Group>> GetAsync(
		[AliasAs("organization_id")] long organizationId,
		[AliasAs("name")] string? nameContains,
		[AliasAs("workspace")] int? workspaceId,
		CancellationToken cancellationToken
		);
}
