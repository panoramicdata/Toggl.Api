using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class ProjectUserTests(ITestOutputHelper testOutputHelper) : TogglTest(testOutputHelper)
{
	[Fact]
	public async void ListProjectUsers()
	{
		var workspaceId = await GetWorkspaceIdAsync();

		var projectUsers = await TogglClient
			.ProjectUsers
			.GetAllAsync(
				workspaceId,
				default
			);
		projectUsers.Should().NotBeNullOrEmpty();
		projectUsers.Should().OnlyContain(pu => pu.Id != 0);
	}
}