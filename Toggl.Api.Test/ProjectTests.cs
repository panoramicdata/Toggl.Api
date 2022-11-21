using FluentAssertions;
using System.Linq;
using Toggl.Api.QueryObjects;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class ProjectTests : TogglTest
{
	public ProjectTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
	}

	[Fact]
	public async void List()
	{
		var projects = await TogglClient
			.Projects
			.ListAsync()
			.ConfigureAwait(false);
		projects.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async void GetProjectReportDashboard()
	{
		var workspaces = await TogglClient
			.Workspaces
			.GetAllAsync()
			.ConfigureAwait(false);
		var togglWorkspace = workspaces.SingleOrDefault(w => w.Name == Configuration.SampleWorkspaceName);
		togglWorkspace.Should().NotBeNull();

		var projects = await TogglClient
			.Projects
			.ListAsync()
			.ConfigureAwait(false);
		var togglProject = projects.SingleOrDefault(p => p.Name == Configuration.SampleProjectName);
		togglProject.Should().NotBeNull();

		var projectReportDashboard = await TogglClient.Reports.GetProjectReportAsync(new ProjectDashboardParams
		{
			UserAgent = "TogglAPI.Net",
			WorkspaceId = togglWorkspace!.Id,
			ProjectId = togglProject!.Id!.Value,
			OrderDesc = "on",
			OrderField = "name"
		})
		.ConfigureAwait(false);

		projectReportDashboard.Should().NotBeNull();
	}
}