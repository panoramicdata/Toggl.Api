using FluentAssertions;
using System.Linq;
using System.Threading.Tasks;
using Toggl.Api.QueryObjects;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class ProjectTests(ITestOutputHelper testOutputHelper) : TogglTest(testOutputHelper)
{
	[Fact]
	public async Task List()
	{
		var projects = await TogglClient
			.Projects
			.ListAsync();
		projects.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task GetProjectReportDashboard()
	{
		var workspaces = await TogglClient
			.Workspaces
			.GetAllAsync();
		var togglWorkspace = workspaces.SingleOrDefault(w => w.Name == Configuration.SampleWorkspaceName);
		togglWorkspace.Should().NotBeNull();

		var projects = await TogglClient
			.Projects
			.ListAsync();
		var togglProject = projects.SingleOrDefault(p => p.Name == Configuration.SampleProjectName);
		togglProject.Should().NotBeNull();

		var projectReportDashboard = await TogglClient.Reports.GetProjectReportAsync(new ProjectDashboardParams
		{
			UserAgent = "TogglAPI.Net",
			WorkspaceId = togglWorkspace!.Id,
			ProjectId = togglProject!.Id!.Value,
			OrderDesc = "on",
			OrderField = "name"
		});

		projectReportDashboard.Should().NotBeNull();
	}
}