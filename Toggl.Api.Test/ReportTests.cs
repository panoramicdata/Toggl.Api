using FluentAssertions;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class ReportTests(ITestOutputHelper testOutputHelper) : TogglTest(testOutputHelper)
{
	[Fact]
	public async void Reports_GetWorkspaceProjectSummary_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();
		var reportRequest = GetReportRequest();

		var report = await TogglClient
			.Reports
			.GetWorkspaceProjectSummaryAsync(workspaceId, reportRequest, default);

		report.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async void Reports_GetProjectSummary_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();
		var reportRequest = GetReportRequest();

		var projects = await GetProjectsPageAsync();

		// Test the last 10 projects
		foreach (var project in projects.Reverse().Take(10))
		{
			var report = await TogglClient
			.Reports
				.GetProjectSummaryAsync(workspaceId, project.Id, reportRequest, default);

			report.Should().NotBeNull();
		}
	}
}