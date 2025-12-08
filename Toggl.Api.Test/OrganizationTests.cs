using AwesomeAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Toggl.Api.Test;

public class OrganizationTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
{
	[Fact]
	public async Task Organizations_Get_Succeeds()
	{
		var organizationId = await GetOrganizationIdAsync();

		var organization = await TogglClient
			.Organizations
			.GetAsync(organizationId, CancellationToken);

		organization.Should().NotBeNull();
		organization.Name.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task Organizations_GetWorkspaces_Succeeds()
	{
		var organizationId = await GetOrganizationIdAsync();

		var workspaces = await TogglClient
			.Organizations
			.GetWorkspacesAsync(organizationId, CancellationToken);

		workspaces.Should().NotBeNull();
	}

	[Fact]
	public async Task Organizations_GetGroups_Succeeds()
	{
		var organizationId = await GetOrganizationIdAsync();

		var groups = await TogglClient
			.Organizations
			.GetGroupsAsync(organizationId, CancellationToken);

		groups.Should().NotBeNull();
	}

	#region Phase 2: Organization Owner & Plans Tests

	[Fact]
	public async Task Organizations_GetOwner_Succeeds()
	{
		var organizationId = await GetOrganizationIdAsync();

		var owner = await TogglClient
			.Organizations
			.GetOwnerAsync(organizationId, CancellationToken);

		owner.Should().NotBeNull();
		owner.Email.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task Organizations_GetPlans_Succeeds()
	{
		var organizationId = await GetOrganizationIdAsync();

		var plans = await TogglClient
			.Organizations
			.GetPlansAsync(organizationId, CancellationToken);

		plans.Should().NotBeNull();
	}

	[Fact]
	public async Task Organizations_GetRoles_Succeeds()
	{
		var organizationId = await GetOrganizationIdAsync();

		var roles = await TogglClient
			.Organizations
			.GetRolesAsync(organizationId, CancellationToken);

		roles.Should().NotBeNull();
	}

	#endregion
}
