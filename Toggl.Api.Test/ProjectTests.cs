using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class ProjectTests(ITestOutputHelper testOutputHelper) : TogglTest(testOutputHelper)
{
	[Fact]
	public async Task Projects_GetPage_Succeeds()
	{
		var projects = await GetProjectsPageAsync();
		projects.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task Projects_Get_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();
		var projectId = await GetProjectIdAsync();
		var project = await TogglClient
			.Projects
			.GetAsync(workspaceId, projectId, default);

		project.Should().NotBeNull();
	}

	[Fact]
	public async Task Projects_GetProjectUsers_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();

		var report = await TogglClient
			.Projects
			.GetUsersAsync(workspaceId, null, null, default);

		report.Should().NotBeNullOrEmpty();
	}

}