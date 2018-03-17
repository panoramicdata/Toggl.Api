using Toggl.Api.DataObjects;

namespace Toggl.Api.Interfaces
{
	public interface IDashboardService
	{
		IApiService ToggleSrv { get; set; }

		Dashboard Get(int workspaceId);
	}
}