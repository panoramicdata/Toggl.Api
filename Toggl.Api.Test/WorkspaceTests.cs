using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class WorkspaceTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
{
	[Fact]
	public async Task Workspaces_GetById_Succeeds()
	{
		var workspace = await TogglClient
			.Workspaces
			.GetAsync(await GetWorkspaceIdAsync(), default);

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
			.GetClientsAsync(await GetWorkspaceIdAsync(), null, null, default);

		workspace.Should().NotBeNull();
	}

	[Fact]
	public async Task Workspaces_GetUsers_Succeeds()
	{
		var organizationId = await GetOrganizationIdAsync();
		var workspaceId = await GetWorkspaceIdAsync();

		var users = await TogglClient
			.Workspaces
			.GetUsersAsync(organizationId, workspaceId, default);

		users.Should().NotBeNull();
	}

	[Fact]
	public async Task Workspaces_GetProjects_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();

		var projects = await TogglClient
			.Workspaces
			.GetProjectsAsync(workspaceId, default);

		projects.Should().NotBeNull();
	}
}
