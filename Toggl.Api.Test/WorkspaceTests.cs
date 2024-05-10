using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class WorkspaceTests(ITestOutputHelper testOutputHelper) : TogglTest(testOutputHelper)
{
	[Fact]
	public async void Workspaces_GetById_Succeeds()
	{
		var workspace = await TogglClient
			.Workspaces
			.GetAsync(await GetWorkspaceIdAsync(), default);

		workspace.Should().NotBeNull();
	}

	[Fact]
	public async void Workspaces_GetClients_Succeeds()
	{
		var workspace = await TogglClient
			.Workspaces
			.GetClientsAsync(await GetWorkspaceIdAsync(), null, null, default);

		workspace.Should().NotBeNull();
	}

	[Fact]
	public async void Workspaces_GetUsers_Succeeds()
	{
		var organizationId = await GetOrganizationIdAsync();
		var workspaceId = await GetWorkspaceIdAsync();

		var users = await TogglClient
			.Workspaces
			.GetUsersAsync(organizationId, workspaceId, default);

		users.Should().NotBeNull();
	}
}
