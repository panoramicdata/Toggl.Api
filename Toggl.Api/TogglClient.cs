using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Interfaces;

namespace Toggl.Api;

/// <summary>
/// A Toggl client
/// </summary>
public class TogglClient : IDisposable
{
	private readonly HttpClient _httpClient;

	public TogglClient(TogglClientOptions options)
	{
		ArgumentNullException.ThrowIfNull(options);

		// Validate that all of the necessary configuration has been provided
		options.Validate();

		_httpClient = new HttpClient(new AuthenticatedHttpClientHandler(options))
		{
			BaseAddress = new Uri("https://api.track.toggl.com/"),
			Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds)
		};

		var refitSettings = new RefitSettings
		{
			ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				WriteIndented = true,
				UnmappedMemberHandling = options.JsonUnmappedMemberHandling,
				Converters =
				{
					new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
				}
			})
		};

		Clients = RestService.For<IClients>(_httpClient, refitSettings);
		Me = RestService.For<IMe>(_httpClient, refitSettings);
		Groups = RestService.For<IGroups>(_httpClient, refitSettings);
		Organizations = RestService.For<IOrganizations>(_httpClient, refitSettings);
		Projects = RestService.For<IProjects>(_httpClient);
		Reports = RestService.For<IReports>(_httpClient);
		Tags = RestService.For<ITags>(_httpClient);
		Tasks = RestService.For<ITasks>(_httpClient);
		TimeEntries = RestService.For<ITimeEntries>(_httpClient);
		Workspaces = RestService.For<IWorkspaces>(_httpClient, refitSettings);
	}

	/// <summary>
	/// Methods to access client information
	/// </summary>
	public IClients Clients { get; }

	/// <summary>
	/// Methods to access information about the current user
	/// </summary>
	public IMe Me { get; }

	/// <summary>
	/// Methods to access information about user groups
	/// </summary>
	public IGroups Groups { get; }

	/// <summary>
	/// Holds methods to access organization information
	/// </summary>
	public IOrganizations Organizations { get; }

	/// <summary>
	/// Holds methods to access project information
	/// </summary>
	public IProjects Projects { get; }

	/// <summary>
	/// Holds methods to access report information
	/// </summary>
	public IReports Reports { get; }

	/// <summary>
	/// Holds methods to access tag information
	/// </summary>
	public ITags Tags { get; }

	/// <summary>
	/// Holds methods to access task information
	/// </summary>
	public ITasks Tasks { get; }

	/// <summary>
	/// Holds methods to access time entry information
	/// </summary>
	public ITimeEntries TimeEntries { get; }

	/// <summary>
	/// Holds methods to access workspace information
	/// </summary>
	public IWorkspaces Workspaces { get; }

	public Task<ICollection<T>> GetAllAsync<T>(long workspaceId, CancellationToken cancellationToken)
		=> throw new NotImplementedException("Not yet implemented in the V9 client.");

	public void Dispose()
	{
		_httpClient.Dispose();
		GC.SuppressFinalize(this);
	}
}
