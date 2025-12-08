using AwesomeAssertions;
using System;
using System.Threading.Tasks;
using Toggl.Api.Models;
using Xunit;

namespace Toggl.Api.Test;

public class TagTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
{
	[Fact]
	public async Task Tags_Get_Succeeds()
	{
		var tasks = await TogglClient
			.Tags
			.GetAsync(await GetWorkspaceIdAsync(), CancellationToken);

		tasks.Should().NotBeNull();
	}

	#region Phase 1: Tag CRUD Tests

	[Fact]
	public async Task Tags_Crud_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();
		var uniqueTagName = $"TestTag_{Guid.NewGuid():N}";

		// Create a tag
		var createDto = new TagCreationDto
		{
			Name = uniqueTagName,
			WorkspaceId = workspaceId
		};

		var createdTag = await TogglClient
			.Tags
			.CreateAsync(workspaceId, createDto, CancellationToken);

		try
		{
			createdTag.Should().NotBeNull();
			createdTag.Name.Should().Be(uniqueTagName);

			// Update the tag
			var updateDto = new TagCreationDto
			{
				Name = $"Updated_{uniqueTagName}",
				WorkspaceId = workspaceId
			};

			var updatedTag = await TogglClient
				.Tags
				.UpdateAsync(workspaceId, createdTag.Id, updateDto, CancellationToken);

			updatedTag.Should().NotBeNull();
			updatedTag.Name.Should().Be($"Updated_{uniqueTagName}");
		}
		finally
		{
			// Clean up - delete the tag
			await TogglClient
				.Tags
				.DeleteAsync(workspaceId, createdTag.Id, CancellationToken);
		}
	}

	#endregion
}
