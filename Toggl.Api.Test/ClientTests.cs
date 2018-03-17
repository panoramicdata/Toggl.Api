using System.Linq;
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
			var clients = await TogglClient.Client.List();
			Assert.True(clients.Any());
		}
	}
}
