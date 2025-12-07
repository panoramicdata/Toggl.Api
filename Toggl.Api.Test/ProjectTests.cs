using AwesomeAssertions;
using System.Threading.Tasks;
using Toggl.Api.Models;
using Xunit;

namespace Toggl.Api.Test;

public class ProjectTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
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
			.GetAsync(workspaceId, projectId, CancellationToken);

		project.Should().NotBeNull();
	}

	[Fact]
	public async Task Projects_GetProjectUsers_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();

		var report = await TogglClient
			.Projects
			.GetUsersAsync(workspaceId, null, null, CancellationToken);

		report.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task Projects_CreateProject_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();

		var projectCreationDto = new ProjectCreationDto
		{
			IsActive = true,
			IsPrivate = false,
			IsShared = false,
			Name = "ABC"
		};

		// Create a project
		var project =
			await TogglClient
			.Projects
			.CreateAsync(workspaceId, projectCreationDto, CancellationToken);
		try
		{
			project.Should().NotBeNull();
		}
		finally
		{
			// Clean up
			await TogglClient
				.Projects
				.DeleteAsync(
					workspaceId,
					project.Id,
					CancellationToken);
		}
	}
}