using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;

namespace Toggl.Api.Interfaces;

/// <summary>
/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#workspaces
/// </summary>
public interface IProjectUsers
{
	/// <summary>
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/workspaces.md#get-workspaces
	/// </summary>
	Task<List<ProjectUser>> GetAllAsync(long workspaceId, CancellationToken cancellationToken);
}