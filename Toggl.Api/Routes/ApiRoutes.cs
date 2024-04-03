namespace Toggl.Api.Routes;

public static class ApiRoutes
{
	private const string TogglBaseUrl = "https://api.track.toggl.com/api/v8";
	private const string TogglReportUrl = "https://api.track.toggl.com/reports/api/v2";

	public static class Reports
	{
		public static readonly string Detailed = TogglReportUrl + "/details";
		public static readonly string Weekly = TogglReportUrl + "/weekly";
		public static readonly string Summary = TogglReportUrl + "/summary";
		public static readonly string Project = TogglReportUrl + "/projects";
	}

	public static class Session
	{
		public static readonly string Me = TogglBaseUrl + "/me";
	}

	public static class Client
	{
		public static readonly string ClientsUrl = TogglBaseUrl + "/clients";
		public static readonly string ClientUrl = TogglBaseUrl + "/clients/{0}";
		public static readonly string ClientProjectsUrl = TogglBaseUrl + "/clients/{0}/projects";
	}

	public static class Workspace
	{
		public static readonly string ListWorkspaceUrl = TogglBaseUrl + "/workspaces";
		public static readonly string ListWorkspaceProjectUsersUrl = TogglBaseUrl + "/workspaces/{0}/project_users";
		public static readonly string ListWorkspaceUsersUrl = TogglBaseUrl + "/workspaces/{0}/users";
		public static readonly string ListWorkspaceProjectsUrl = TogglBaseUrl + "/workspaces/{0}/projects";
		public static readonly string ListWorkspaceClientsUrl = TogglBaseUrl + "/workspaces/{0}/clients";
		public static readonly string ListWorkspaceTasksUrl = TogglBaseUrl + "/workspaces/{0}/tasks";
		public static readonly string ListWorkspaceTagsUrl = TogglBaseUrl + "/workspaces/{0}/tags";
		public static readonly string GetWorkspaceTimeEntry = TogglBaseUrl + "/workspaces/{0}/time_entries/{1}";
	}

	public static class Task
	{
		public static readonly string TogglTasksUrl = TogglBaseUrl + "/tasks";
		public static readonly string TogglTasksGet = TogglBaseUrl + "/tasks/{0}";
	}

	public static class TimeEntry
	{
		public static readonly string TimeEntriesUrl = TogglBaseUrl + "/time_entries";
		public static readonly string TimeEntryStartUrl = TogglBaseUrl + "/time_entries/start";
		public static readonly string TimeEntryStopUrl = TogglBaseUrl + "/time_entries/{0}/stop";
		public static readonly string TimeEntryUrl = TogglBaseUrl + "/time_entries/{0}";
		public static readonly string TimeEntryCurrentUrl = TogglBaseUrl + "/time_entries/current";
	}

	public static class Project
	{
		public static readonly string ProjectsBulkDeleteUrl = TogglBaseUrl + "/projects/{0}";
		public static readonly string ProjectsUrl = TogglBaseUrl + "/projects";
		public static readonly string DetailUrl = TogglBaseUrl + "/projects/{0}";
		public static readonly string ProjectTasksUrl = TogglBaseUrl + "/projects/{0}/tasks";
	}

	public static class User
	{
		public static readonly string CurrentUrl = TogglBaseUrl + "/me";
		public static readonly string CurrentExtendedUrl = TogglBaseUrl + "/me?with_related_data=true";
		public static readonly string CurrentSinceUrl = TogglBaseUrl + "/me?since={0}&with_related_data=true";
		public static readonly string ResetApiTokenUrl = TogglBaseUrl + "/reset_token";
		public static readonly string EditUrl = TogglBaseUrl + "/me";
		public static readonly string AddUrl = TogglBaseUrl + "/signups";
	}

	public static class Dashboard
	{
		public static readonly string DashboardUrl = TogglBaseUrl + "/dashboard/{0}";
	}
}
