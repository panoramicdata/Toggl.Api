using AwesomeAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Toggl.Api.Test;

public class ProjectTaskTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
{
	[Fact]
	public async Task Tasks_Get_ForProject_Succeeds()
	{
		var tasks = await TogglClient
			.Tasks
			.GetAsync(await GetWorkspaceIdAsync(), await GetProjectIdAsync(), CancellationToken);

		tasks.Should().NotBeNull();
	}

	[Fact]
	public async Task Tasks_Get_ForWorkspace_Succeeds()
	{
		var tasks = await TogglClient
			.Tasks
			.GetAsync(
				await GetWorkspaceIdAsync(),
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				null,
				CancellationToken);

		tasks.Should().NotBeNull();
	}
}