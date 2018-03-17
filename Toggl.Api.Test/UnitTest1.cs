using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Toggl.Api.Test
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
		{
			_togglClientServiceAsync = new ClientServiceAsync(togglApiKey ?? throw new ArgumentNullException(nameof(togglApiKey)));
		}

		private static Configuration LoadConfiguration(string jsonFilePath)
		{
			var location = typeof(ConfigurationFileTests).GetTypeInfo().Assembly.Location;
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
