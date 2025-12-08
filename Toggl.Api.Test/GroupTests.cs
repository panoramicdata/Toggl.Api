using AwesomeAssertions;
using System.Threading.Tasks;
using Toggl.Api.Models;
using Xunit;

namespace Toggl.Api.Test;

public class GroupTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
{
	[Fact]
	public async Task Groups_GetOrganizationGroups_Succeeds()
	{
		var groups = await TogglClient
			.Groups
			.GetAsync(
				await GetOrganizationIdAsync(),
				null,
				null,
				CancellationToken);

		groups.Should().NotBeNull();
	}

	#region Phase 3: Organization Group CRUD Tests

	[Fact]
	public async Task Groups_CrudOrganizationGroup_Succeeds()
	{
		var organizationId = await GetOrganizationIdAsync();

		// Create a group
		var groupCreationDto = new GroupCreationDto
		{
			Name = "Test Group from Unit Tests"
		};

		var createdGroup = await TogglClient
			.Groups
			.CreateAsync(organizationId, groupCreationDto, CancellationToken);

		try
		{
			createdGroup.Should().NotBeNull();
			createdGroup.Name.Should().Be("Test Group from Unit Tests");

			// Update the group
			var groupUpdateDto = new GroupUpdateDto
			{
				Name = "Updated Test Group"
			};

			var updatedGroup = await TogglClient
				.Groups
				.UpdateAsync(organizationId, createdGroup.GroupId, groupUpdateDto, CancellationToken);

			updatedGroup.Should().NotBeNull();
			updatedGroup.Name.Should().Be("Updated Test Group");

			// Get groups to verify it exists
			var groups = await TogglClient
				.Groups
				.GetAsync(organizationId, "Updated Test Group", null, CancellationToken);

			groups.Should().Contain(g => g.GroupId == createdGroup.GroupId);
		}
		finally
		{
			// Clean up - delete the group
			await TogglClient
				.Groups
				.DeleteAsync(organizationId, createdGroup.GroupId, CancellationToken);
		}
	}

	#endregion

	#region Phase 3: Workspace Group Tests

	[Fact]
	public async Task Groups_GetWorkspaceGroups_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();

		var groups = await TogglClient
			.Groups
			.GetWorkspaceGroupsAsync(workspaceId, CancellationToken);

		groups.Should().NotBeNull();
	}

	#endregion
}
