using Toggl.Api.DataObjects;
using Toggl.Api.QueryObjects;

namespace Toggl.Api.Interfaces
{
    public interface IReportService
    {
        IApiService ToggleSrv { get; set; }

        DetailedReport Detailed(DetailedReportParams requestParameters);
    }
}
