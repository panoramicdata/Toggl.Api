using AwesomeAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Toggl.Api.Test;

public class GroupTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
{
	[Fact]
	public async Task Tasks_Get_Groups_Succeeds()
	{
		var tasks = await TogglClient
			.Groups
			.GetAsync(
				await GetOrganizationIdAsync(),
				null,
				null,
				CancellationToken);

		tasks.Should().NotBeNull();
	}
}
