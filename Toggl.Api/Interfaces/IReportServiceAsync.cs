using System.Threading.Tasks;
using Toggl.Api.DataObjects;
using Toggl.Api.QueryObjects;

namespace Toggl.Api.Interfaces
{
    public interface IReportServiceAsync
    {
        IApiServiceAsync ToggleSrv { get; set; }

        Task<DetailedReport> Detailed(DetailedReportParams requestParameters);
    }
}
