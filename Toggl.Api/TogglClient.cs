using Toggl.Api.Interfaces;
using Toggl.Api.Services;

namespace Toggl.Api;

/// <summary>
/// A Toggl client
/// </summary>
public class TogglClient
{
	public const string UserAgent = "Toggl.Api";

	public TogglClient(string key)
	{
		ApiService = new ApiServiceAsync(key);
		Clients = new ClientServiceAsync(ApiService);
		Projects = new ProjectServiceAsync(ApiService);
		Reports = new ReportServiceAsync(ApiService);
		Tags = new TagServiceAsync(ApiService);
		Tasks = new TaskServiceAsync(ApiService);
		TimeEntries = new TimeEntryServiceAsync(ApiService);
		Users = new UserServiceAsync(ApiService);
		Workspaces = new WorkspaceServiceAsync(ApiService);
	}

	private IApiServiceAsync ApiService { get; }

	/// <summary>
	/// Holds methods to access client information
	/// </summary>
	public IClientServiceAsync Clients { get; }

	/// <summary>
	/// Holds methods to access project information
	/// </summary>
	public IProjectServiceAsync Projects { get; }

	/// <summary>
	/// Holds methods to access report information
	/// </summary>
	public ReportServiceAsync Reports { get; }

	/// <summary>
	/// Holds methods to access tag information
	/// </summary>
	public ITagServiceAsync Tags { get; }

	/// <summary>
	/// Holds methods to access task information
	/// </summary>
	public ITaskServiceAsync Tasks { get; }

	/// <summary>
	/// Holds methods to access time entry information
	/// </summary>
	public ITimeEntryServiceAsync TimeEntries { get; }

	/// <summary>
	/// Holds methods to access user information
	/// </summary>
	public IUserServiceAsync Users { get; }

	/// <summary>
	/// Holds methods to access workspace information
	/// </summary>
	public IWorkspaceServiceAsync Workspaces { get; }
}