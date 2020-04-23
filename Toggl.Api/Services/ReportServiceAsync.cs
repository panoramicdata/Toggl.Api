using System.Threading.Tasks;
using Toggl.Api.DataObjects;
using Toggl.Api.Interfaces;
using Toggl.Api.QueryObjects;
using Toggl.Api.Routes;

namespace Toggl.Api.Services
{
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

		public async Task<ProjectReportDashboard> ProjectReport(ProjectDashboardParams requestParameters) =>
			await TogglSrv.Get<ProjectReportDashboard>(ApiRoutes.Reports.Project, requestParameters.ToKeyValuePair());

		public async Task<DetailedReport> Detailed(DetailedReportParams requestParameters)
		{
			var report = await TogglSrv.Get<DetailedReport>(ApiRoutes.Reports.Detailed, requestParameters.ToKeyValuePair());
			return report;
		}

		public async Task<DetailedReport> FullDetailedReport(DetailedReportParams requestParameters)
		{
			var report = await Detailed(requestParameters);

			if (report.TotalCount < report.PerPage)
				return report;

			var pageCount = (report.TotalCount + report.PerPage - 1) / report.PerPage;

			DetailedReport resultReport = null;
			for (var page = 1; page <= pageCount; page++)
			{
				requestParameters.Page = page;
				var pagedReport = await Detailed(requestParameters);

				if (resultReport == null)
				{
					resultReport = pagedReport;
				}
				else
				{
					resultReport.Data.AddRange(pagedReport.Data);
				}
			}

			return resultReport;
		}
	}
}