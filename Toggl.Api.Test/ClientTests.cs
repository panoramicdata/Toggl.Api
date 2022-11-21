using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class ClientTests : TogglTest
{
	public ClientTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
	{
	}

	[Fact]
	public async Task GetClients()
	{
		var clients = await TogglClient
			.Clients
			.GetAllAsync()
			.ConfigureAwait(false);
		clients.Should().NotBeNullOrEmpty();
	}
}
