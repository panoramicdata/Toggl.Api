using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
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
	private static ReportRequest? _reportRequest;
	private static DetailedReportRequest? _detailedReportRequest;
	private long? _workspaceId;
	private long? _organizationId;
	private long? _projectId;

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
		if (_workspaceId is null)
		{
			var me = await TogglClient
				.Me
				.GetAsync(true, default);
			_workspaceId = me.DefaultWorkspaceId;
		}

		return _workspaceId.Value;
	}

	protected async Task<long> GetOrganizationIdAsync()
	{
		if (_organizationId is null)
		{
			var workspaceId = await GetWorkspaceIdAsync();
			var workspace = await TogglClient
				.Workspaces
				.GetAsync(workspaceId, default);
			_organizationId = workspace.OrganizationId;
		}

		return _organizationId.Value;
	}

	protected async Task<long> GetProjectIdAsync()
	{
		if (_projectId is null)
		{
			var projects = await GetProjectsPageAsync();
			_projectId = projects.First().Id;
		}

		return _projectId.Value;
	}

	protected static ReportRequest GetReportRequest()
	{
		if (_reportRequest is null)
		{
			var endDate = DateTime.Now.Date;
			var startDate = endDate.AddMonths(-1);
			var startDateOnly = new DateOnly(startDate.Date.Year, startDate.Date.Month, startDate.Date.Day);
			var endDateOnly = new DateOnly(endDate.Date.Year, endDate.Date.Month, endDate.Date.Day);
			_reportRequest = new ReportRequest
			{
				StartDate = startDateOnly,
				EndDate = endDateOnly,
				StartTime = TimeOnly.MinValue
			};
		}

		return _reportRequest;
	}
	protected static DetailedReportRequest GetDetailedReportRequest()
	{
		if (_detailedReportRequest is null)
		{
			var endDate = DateTime.Now.Date;
			var startDate = endDate.AddMonths(-1);
			var startDateOnly = new DateOnly(startDate.Date.Year, startDate.Date.Month, startDate.Date.Day);
			var endDateOnly = new DateOnly(endDate.Date.Year, endDate.Date.Month, endDate.Date.Day);
			_detailedReportRequest = new DetailedReportRequest
			{
				StartDate = startDateOnly,
				EndDate = endDateOnly,
				StartTime = TimeOnly.MinValue
			};
		}

		return _detailedReportRequest;
	}

	protected async Task<ICollection<Project>> GetProjectsPageAsync()
	{
		var workspaceId = await GetWorkspaceIdAsync();
		return await TogglClient
				.Projects
				.GetPageAsync(
					workspaceId,
					null,
					null,
					null,
					null,
					null,
					null,
					null,
					"",
					1,
					"name",
					SortDirection.Asc,
					false,
					null,
					default);
	}
}