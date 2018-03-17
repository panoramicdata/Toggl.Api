using Toggl.Api.DataObjects;
using Toggl.Api.Interfaces;
using Toggl.Api.Routes;

namespace Toggl.Api.Services
{
	public class DashboardService : IDashboardService
	{
		public IApiService ToggleSrv { get; set; }

		public Dashboard Get(int workspaceId)
		{
			var url = string.Format(ApiRoutes.Dashboard.DashboardUrl, workspaceId);
			var dashboard = ToggleSrv.Get<Dashboard>(url);

			return dashboard;
		}

		public DashboardService(string apiKey)
			: this(new ApiService(apiKey))
		{

		}

		public DashboardService(IApiService srv)
		{
			ToggleSrv = srv;
		}
	}
}