using AwesomeAssertions;
using Refit;
using System.Net;
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

		Group createdGroup;
		try
		{
			createdGroup = await TogglClient
				.Groups
				.CreateAsync(organizationId, groupCreationDto, CancellationToken);
		}
		catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
		{
			// Some organizations restrict group creation via API.
			return;
		}

		var createdGroupId = createdGroup.GroupId;
		createdGroupId.Should().NotBeNull();

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
				.UpdateAsync(organizationId, createdGroupId!.Value, groupUpdateDto, CancellationToken);

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
				.DeleteAsync(organizationId, createdGroupId!.Value, CancellationToken);
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
