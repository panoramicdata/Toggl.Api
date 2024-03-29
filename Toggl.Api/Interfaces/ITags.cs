using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;

namespace Toggl.Api.Interfaces;

public interface ITags
{
	/// <summary>
	/// List Workspace tags.
	/// https://engineering.toggl.com/docs/api/tags#get-tags
	/// </summary>
	/// <param name="workspaceId">The workspace id</param>
	/// <returns></returns>
	[Get("/api/v9/workspaces/{workspace_id}/tags")]
	Task<ICollection<Tag>> GetAsync(
		[AliasAs("workspace_id")] long workspaceId,
		CancellationToken cancellationToken
		);
}