using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;

namespace Toggl.Api.Interfaces;

public interface IProjects
{
	/// <summary>
	///List project services
	/// https://www.toggl.com/public/api#get_projects
	/// </summary>
	Task<List<Project>> GetAllAsync(long workspaceId, CancellationToken cancellationToken);

	Task<Project> GetAsync(long id, CancellationToken cancellationToken);
}