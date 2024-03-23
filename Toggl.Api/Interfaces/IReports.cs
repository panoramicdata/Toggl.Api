using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;
using Toggl.Api.QueryObjects;

namespace Toggl.Api.Interfaces;

public interface IReports
{
	Task<DetailedReport> DetailedAsync(DetailedReportParams requestParameters, CancellationToken cancellationToken);
}