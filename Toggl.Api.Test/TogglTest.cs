using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Toggl.Api.Models;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class TogglTest
{
	protected ILogger Logger { get; }

	protected TogglClient TogglClient { get; }

	protected Configuration Configuration { get; }

	protected TogglTest(ITestOutputHelper iTestOutputHelper)
	{
		Logger = iTestOutputHelper.BuildLogger(LogLevel.Debug);
		Configuration = LoadConfiguration("appsettings.json");
		TogglClient = new TogglClient(new TogglClientOptions
		{
			Key = Configuration.ApiKey,
			Logger = Logger,
			// Find missing properties during unit testing
			// Note that this is NOT the default behavior, so changes to the API won't cause backward compatibility issues
			JsonUnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow,
		});
	}

	private static Configuration LoadConfiguration(string jsonFilePath)
	{
		var location = typeof(TogglTest).GetTypeInfo().Assembly.Location;
		var dirPath = Path.Combine(Path.GetDirectoryName(location) ?? throw new ConfigurationErrorsException("Configuration location missing."), "../../..");

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
			var options = sp.GetService<IOptions<Configuration>>()
				?? throw new ConfigurationErrorsException("Options retrieved as null");
			configuration = options.Value;
		}

		return configuration;
	}

	protected async Task<long> GetWorkspaceIdAsync()
	{
		var me = await TogglClient
			.Me
			.GetAsync(true, default);
		var workspaceId = me.Workspaces!.SingleOrDefault(w => w.Name == Configuration.SampleWorkspaceName)?.Id
			?? throw new InvalidOperationException($"Missing {nameof(Workspace)} {Configuration.SampleWorkspaceName}");
		return workspaceId;
	}
}