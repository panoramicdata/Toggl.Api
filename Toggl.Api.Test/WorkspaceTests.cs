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
			var clients = await TogglClient.Workspaces.List();
			Assert.True(clients.Any());
		}
	}
}
