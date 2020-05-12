using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Xunit.Abstractions;

namespace Toggl.Api.Test
{
	public class TogglTest
	{
		protected ILogger Logger { get; }
		protected TogglClient TogglClient {get;}
		protected Configuration Configuration { get; }

		protected TogglTest(ITestOutputHelper iTestOutputHelper)
		{
			Logger = iTestOutputHelper.BuildLogger();
			Configuration = LoadConfiguration("appsettings.json");
			TogglClient = new TogglClient(Configuration.ApiKey);
		}

		private static Configuration LoadConfiguration(string jsonFilePath)
		{
			var location = typeof(TogglTest).GetTypeInfo().Assembly.Location;
			var dirPath = Path.Combine(Path.GetDirectoryName(location), "../../..");

			Configuration configuration;
			var configurationRoot = new ConfigurationBuilder()
				.SetBasePath(dirPath)
				.AddJsonFile(jsonFilePath, false, false)
				.Build();
			var services = new ServiceCollection();
			services.AddOptions();
			services.Configure<Configuration>(configurationRoot);
			using (var sp = services.BuildServiceProvider())
			{
				var options = sp.GetService<IOptions<Configuration>>();
				configuration = options.Value;
			}

			return configuration;
		}
	}
}