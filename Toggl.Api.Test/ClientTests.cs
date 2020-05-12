using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test
{
	public class ClientTests : TogglTest
	{
		public ClientTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
		{
		}

		[Fact]
		public async void GetClients()
		{
			var clients = await TogglClient
				.Clients
				.List()
				.ConfigureAwait(false);
			Assert.True(clients.Count > 0);
		}
	}
}
