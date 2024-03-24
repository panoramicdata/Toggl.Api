using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;

namespace Toggl.Api.Interfaces;

/// <summary>
/// https://engineering.toggl.com/docs/api/workspaces
/// </summary>
public interface IWorkspaces
{
	/// <summary>
	/// Get clients for a workspace
	/// https://engineering.toggl.com/docs/api/clients#get-list-clients
	/// </summary>
	/// <param name="workspaceId"></param>
	/// <param name="clientStatus"></param>
	/// <param name="nameContains"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	[Get("/api/v9/workspaces/{workspace_id}/clients")]
	Task<ICollection<Client>> GetAsync(
		[AliasAs("workspace_id")] long workspaceId,
		[AliasAs("status")] ClientStatus? clientStatus,
		[AliasAs("name")] string? nameContains,
		CancellationToken cancellationToken
		);
}

