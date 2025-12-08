using AwesomeAssertions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Toggl.Api.Test;

public class UserTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
{
	#region Phase 3: Workspace User Tests

	[Fact]
	public async Task Users_GetWorkspaceUsers_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();

		var users = await TogglClient
			.Users
			.GetAsync(workspaceId, CancellationToken);

		users.Should().NotBeNull();
		users.Should().NotBeEmpty();
	}

	[Fact]
	public async Task Users_GetWorkspaceUsersDetailed_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();

		var users = await TogglClient
			.Users
			.GetWorkspaceUsersAsync(workspaceId, CancellationToken);

		users.Should().NotBeNull();
		users.Should().NotBeEmpty();
	}

	[Fact]
	public async Task Users_GetWorkspaceUsers_ContainsCurrentUser()
	{
		var workspaceId = await GetWorkspaceIdAsync();

		var currentUser = await TogglClient
			.CurrentUser
			.GetAsync(false, CancellationToken);

		var users = await TogglClient
			.Users
			.GetAsync(workspaceId, CancellationToken);

		users.Should().NotBeNull();
		users.Should().Contain(u => u.UserId == currentUser.Id || u.Email == currentUser.Email);
	}

	#endregion
}
