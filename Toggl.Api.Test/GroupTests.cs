using AwesomeAssertions;
using Refit;
using System;
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
		var workspaceId = await GetWorkspaceIdAsync();
		var groupName = $"Test Group {Guid.NewGuid():N}";

		// Create a group
		var groupCreationDto = new GroupCreationDto
		{
			Name = groupName,
			WorkspaceIds = [workspaceId]
		};

		var createdGroup = await TogglClient
			.Groups
			.CreateAsync(organizationId, groupCreationDto, CancellationToken);

		var createdGroupId = createdGroup.GroupId
			?? throw new InvalidOperationException("Created group did not return a group ID.");

		try
		{
			createdGroup.Should().NotBeNull();
			createdGroup.Name.Should().Be(groupName);
			createdGroupId.Should().BeGreaterThan(0);
		}
		finally
		{
			// Clean up - delete the group
			try
			{
				await TogglClient
					.Groups
					.DeleteAsync(organizationId, createdGroupId, CancellationToken);
			}
			catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
			{
				// The live API can return a group_id on create that is already gone by cleanup time.
			}
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
