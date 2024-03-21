using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class ClientTests(ITestOutputHelper testOutputHelper) : TogglTest(testOutputHelper)
{
	[Fact]
	public async Task GetClients()
	{
		var clients = await TogglClient
			.Clients
			.GetAllAsync();
		clients.Should().NotBeNullOrEmpty();
	}
}
