using FluentAssertions;
using System.Linq;
using Toggl.Api.QueryObjects;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class ProjectTests(ITestOutputHelper testOutputHelper) : TogglTest(testOutputHelper)
{
	[Fact]
	public async void List()
	{
		var workspaceId = await GetWorkspaceIdAsync();

		var projects = await TogglClient
			.Projects
			.GetAllAsync(workspaceId, default);

		projects.Should().NotBeNullOrEmpty();
		projects.Count(p => p.Name == Configuration.SampleProjectName).Should().Be(1);
	}

	[Fact]
	public async void GetProjectReportDashboard()
	{
		var workspaceId = await GetWorkspaceIdAsync();

		var projects = await TogglClient
			.Projects
			.GetAllAsync(workspaceId, default);
		var togglProject = projects.SingleOrDefault(p => p.Name == Configuration.SampleProjectName);
		togglProject.Should().NotBeNull();

		var projectReportDashboard = await TogglClient.Reports.DetailedAsync(new DetailedReportParams
		{
			UserAgent = "TogglAPI.Net",
			WorkspaceId = workspaceId,
		}, default);

		projectReportDashboard.Should().NotBeNull();
	}
}