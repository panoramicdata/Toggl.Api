using AwesomeAssertions;
using System;
using System.Threading.Tasks;
using Toggl.Api.Models;
using Xunit;

namespace Toggl.Api.Test;

public class ProjectTaskTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
{
	[Fact]
	public async Task Tasks_Get_ForProject_Succeeds()
	{
		var tasks = await TogglClient
			.Tasks
			.GetAsync(await GetWorkspaceIdAsync(), await GetProjectIdAsync(), CancellationToken);

		tasks.Should().NotBeNull();
	}

	[Fact]
	public async Task Tasks_Get_ForWorkspace_Succeeds()
	{
		var tasks = await TogglClient
			.Tasks
			.GetAsync(
				await GetWorkspaceIdAsync(),
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				CancellationToken);

		tasks.Should().NotBeNull();
	}

	#region Phase 1: Task CRUD Tests

	[Fact]
	public async Task Tasks_Crud_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();
		var projectId = await GetProjectIdAsync();
		var uniqueTaskName = $"TestTask_{Guid.NewGuid():N}";

		// Create a task
		var createDto = new TaskCreationDto
		{
			Name = uniqueTaskName,
			ProjectId = projectId,
			WorkspaceId = workspaceId,
			Active = true
		};

		var createdTask = await TogglClient
			.Tasks
			.CreateAsync(workspaceId, projectId, createDto, CancellationToken);

		try
		{
			createdTask.Should().NotBeNull();
			createdTask.Name.Should().Be(uniqueTaskName);

			// Get the task by ID
			var fetchedTask = await TogglClient
				.Tasks
				.GetByIdAsync(workspaceId, projectId, createdTask.Id, CancellationToken);

			fetchedTask.Should().NotBeNull();
			fetchedTask.Id.Should().Be(createdTask.Id);

			// Update the task
			var updateDto = new TaskCreationDto
			{
				Name = $"Updated_{uniqueTaskName}",
				ProjectId = projectId,
				WorkspaceId = workspaceId,
				Active = true
			};

			var updatedTask = await TogglClient
				.Tasks
				.UpdateAsync(workspaceId, projectId, createdTask.Id, updateDto, CancellationToken);

			updatedTask.Should().NotBeNull();
			updatedTask.Name.Should().Be($"Updated_{uniqueTaskName}");
		}
		finally
		{
			// Clean up - delete the task
			await TogglClient
				.Tasks
				.DeleteAsync(workspaceId, projectId, createdTask.Id, CancellationToken);
		}
	}

	#endregion
}