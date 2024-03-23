using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;

namespace Toggl.Api.Interfaces;

public interface ITags
{
	Task<List<Tag>> GetAllAsync(long workspaceId, CancellationToken cancellationToken);
}