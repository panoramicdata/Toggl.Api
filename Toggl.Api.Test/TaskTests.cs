using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class TaskTests(ITestOutputHelper testOutputHelper) : TogglTest(testOutputHelper)
{
	[Fact]
	public async void Tasks_Get_ForProject_Succeeds()
	{
		var tasks = await TogglClient
			.Tasks
			.GetAsync(await GetWorkspaceIdAsync(), await GetProjectIdAsync(), default);

		tasks.Should().NotBeNull();
	}

	[Fact]
	public async void Tasks_Get_ForWorkspace_Succeeds()
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
				default);

		tasks.Should().NotBeNull();
	}
}