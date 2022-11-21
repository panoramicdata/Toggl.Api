using System.Threading.Tasks;
using Toggl.Api.DataObjects;
using Toggl.Api.Interfaces;
using Toggl.Api.QueryObjects;
using Toggl.Api.Routes;

namespace Toggl.Api.Services;

public class ReportServiceAsync : IReportServiceAsync
{
	public IApiServiceAsync TogglSrv { get; set; }

	public ReportServiceAsync(string apiKey)
		: this(new ApiServiceAsync(apiKey))
	{
	}

	public ReportServiceAsync(IApiServiceAsync srv)
	{
		TogglSrv = srv;
	}

	public Task<ProjectReportDashboard> GetProjectReportAsync(ProjectDashboardParams requestParameters) =>
		TogglSrv.GetAsync<ProjectReportDashboard>(ApiRoutes.Reports.Project, requestParameters.ToKeyValuePair());

	public Task<DetailedReport> Detailed(DetailedReportParams requestParameters)
		=> TogglSrv.GetAsync<DetailedReport>(ApiRoutes.Reports.Detailed, requestParameters.ToKeyValuePair());

	public async Task<DetailedReport> GetFullDetailedReportAsync(DetailedReportParams requestParameters)
	{
		var report = await Detailed(requestParameters).ConfigureAwait(false);

		if (report.TotalCount < report.PerPage)
		{
			return report;
		}

		var pageCount = (report.TotalCount + report.PerPage - 1) / report.PerPage;

		var resultReport = default(DetailedReport?);
		for (var page = 1; page <= pageCount; page++)
		{
			requestParameters.Page = page;
			var pagedReport = await Detailed(requestParameters).ConfigureAwait(false);

			if (resultReport?.Data == null)
			{
				resultReport = pagedReport;
			}
			else
			{
				resultReport.Data.AddRange(pagedReport.Data);
			}
		}

		return resultReport!;
	}
}