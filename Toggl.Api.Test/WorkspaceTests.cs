using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class WorkspaceTests : TogglTest
{
	public WorkspaceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
	}

	[Fact]
	public async void List()
	{
		var workspaces = await TogglClient
			.Workspaces
			.GetAllAsync()
			.ConfigureAwait(false);
		workspaces.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async void ListProjectUsers()
	{
		var workspaces = await TogglClient
			.Workspaces
			.GetAllAsync()
			.ConfigureAwait(false);
		workspaces.Should().NotBeNullOrEmpty();
		var workspaceId = workspaces[0].Id;

		var projectUsers = await TogglClient
			.Workspaces
			.GetProjectUsersAsync(workspaceId)
			.ConfigureAwait(false);
		projectUsers.Should().NotBeNullOrEmpty();
		projectUsers.Should().OnlyContain(pu => pu.Id != 0);
		projectUsers.Should().OnlyContain(pu => pu.UserId != 0);
		projectUsers.Should().OnlyContain(pu => pu.ProjectId != 0);
		projectUsers.Should().OnlyContain(pu => pu.WorkspaceId != 0);
	}
}
