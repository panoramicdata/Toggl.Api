using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test
{
	public class ProjectTests : TogglTest
	{
		public ProjectTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
		{
		}

		[Fact]
		public async void List()
		{
			var projects = await TogglClient.Project.List();
			Assert.True(projects.Any());
		}
	}
}