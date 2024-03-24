using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class ProjectTests(ITestOutputHelper testOutputHelper) : TogglTest(testOutputHelper)
{
	[Fact]
	public async void Projects_GetPage_Succeeds()
	{
		var projects = await GetProjectsPageAsync();
		projects.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async void Projects_Get_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();
		var projectId = await GetProjectIdAsync();
		var project = await TogglClient
			.Projects
			.GetAsync(workspaceId, projectId, default);

		project.Should().NotBeNull();
	}
}