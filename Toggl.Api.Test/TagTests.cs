using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class TagTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
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
