using AwesomeAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Toggl.Api.Test;

public class WorkspaceTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
{
	[Fact]
	public async Task Workspaces_GetById_Succeeds()
	{
		var workspace = await TogglClient
			.Workspaces
			.GetAsync(await GetWorkspaceIdAsync(), CancellationToken);

		workspace.Should().NotBeNull();
	}


	[Fact]
	public async Task Workspaces_GetAll_Succeeds()
	{
		var workspaces = await TogglClient.Me.GetWorkspacesAsync(null, CancellationToken.None);
		workspaces.Count.Should().NotBe(0);
	}

	[Fact]
	public async Task Workspaces_GetClients_Succeeds()
	{
		var workspace = await TogglClient
			.Workspaces
			.GetClientsAsync(await GetWorkspaceIdAsync(), null, null, CancellationToken);

		workspace.Should().NotBeNull();
	}

	[Fact]
	public async Task Workspaces_GetUsers_Succeeds()
	{
		var organizationId = await GetOrganizationIdAsync();
		var workspaceId = await GetWorkspaceIdAsync();

		var users = await TogglClient
			.Workspaces
			.GetUsersAsync(organizationId, workspaceId, CancellationToken);

		users.Should().NotBeNull();
	}

	[Fact]
	public async Task Workspaces_GetProjects_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();

		var projects = await TogglClient
			.Workspaces
			.GetProjectsAsync(workspaceId, CancellationToken);

		projects.Should().NotBeNull();
	}
}
