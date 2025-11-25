using AwesomeAssertions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Toggl.Api.Test;

public class ReportTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
{
	[Fact]
	public async Task Reports_GetWorkspaceProjectSummary_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();
		var reportRequest = GetReportRequest();

		var report = await TogglClient
			.Reports
			.GetWorkspaceProjectSummaryAsync(workspaceId, reportRequest, CancellationToken);

		report.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task Reports_GetProjectSummary_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();
		var reportRequest = GetReportRequest();

		var projects = await GetProjectsPageAsync();

		// Test the last 10 projects
		foreach (var project in projects.Reverse().Take(10))
		{
			var report = await TogglClient
			.Reports
				.GetProjectSummaryAsync(workspaceId, project.Id, reportRequest, CancellationToken);

			report.Should().NotBeNull();
		}
	}

	[Fact]
	public async Task Reports_DetailedReport_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();
		var detailedReportRequest = GetDetailedReportRequest();

		var report = await TogglClient
			.Reports
			.GetDetailsAsync(workspaceId, detailedReportRequest, CancellationToken);

		report.Should().NotBeNull();
	}
}