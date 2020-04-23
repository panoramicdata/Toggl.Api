using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test
{
	public class WorkspaceTests : TogglTest
	{
		public WorkspaceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
		{
		}

		[Fact]
		public async void List()
		{
			var workspaces = await TogglClient.Workspaces.List().ConfigureAwait(false);
			Assert.True(workspaces.Count > 0);
		}

		[Fact]
		public async void ListProjectUsers()
		{
			var workspaces = await TogglClient.Workspaces.List().ConfigureAwait(false);
			Assert.True(workspaces.Count > 0);
			var workspaceId = workspaces[0].Id;
			var projectUsers = await TogglClient.Workspaces.ProjectUsers(workspaceId).ConfigureAwait(false);
			Assert.True(projectUsers.Count > 0);
			Assert.All(projectUsers, pu => Assert.NotEqual(0, pu.Id));
			Assert.All(projectUsers, pu => Assert.NotEqual(0, pu.UserId));
			Assert.All(projectUsers, pu => Assert.NotEqual(0, pu.ProjectId));
			Assert.All(projectUsers, pu => Assert.NotEqual(0, pu.WorkspaceId));
		}
	}
}
