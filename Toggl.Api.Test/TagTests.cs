using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class TagTests(ITestOutputHelper testOutputHelper) : TogglTest(testOutputHelper)
{
	[Fact]
	public async Task Tags_Get_Succeeds()
	{
		var tasks = await TogglClient
			.Tags
			.GetAsync(await GetWorkspaceIdAsync(), default);

		tasks.Should().NotBeNull();
	}
}
