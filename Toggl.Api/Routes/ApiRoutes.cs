namespace Toggl.Api.Routes
{
	public static class ApiRoutes
	{
		private const string TogglBaseUrl = "https://www.toggl.com/api/v8";
		private const string TogglReportUrl = "https://toggl.com/reports/api/v2";

		public static class Reports
		{
			public const string Detailed = TogglReportUrl + "/details";
			public const string Weekly = TogglReportUrl + "/weekly";
			public const string Summary = TogglReportUrl + "/summary";
			public const string Project = TogglReportUrl + "/project";
		}

		public static class Session
		{
			public const string Me = TogglBaseUrl + "/me";
		}

		public static class Client
		{
			public const string ClientsUrl = TogglBaseUrl + "/clients";
			public const string ClientUrl = TogglBaseUrl + "/clients/{0}";
			public const string ClientProjectsUrl = TogglBaseUrl + "/clients/{0}/projects";
		}

		public static class Workspace
		{
			public const string ListWorkspaceUrl = TogglBaseUrl + "/workspaces";
			public const string AddWorkspaceUserUrl = TogglBaseUrl + "/workspaces/{0}/project_users";
			public const string ListWorkspaceUsersUrl = TogglBaseUrl + "/workspaces/{0}/users";
			public const string ListWorkspaceProjectsUrl = TogglBaseUrl + "/workspaces/{0}/projects";
			public const string ListWorkspaceClientsUrl = TogglBaseUrl + "/workspaces/{0}/clients";
			public const string ListWorkspaceTasksUrl = TogglBaseUrl + "/workspaces/{0}/tasks";
			public const string ListWorkspaceTagsUrl = TogglBaseUrl + "/workspaces/{0}/tags";
		}

		public static class Task
		{
			public const string TogglTasksUrl = TogglBaseUrl + "/tasks";
			public const string TogglTasksGet = TogglBaseUrl + "/tasks/{0}";
		}

		public static class TimeEntry
		{
			public const string TimeEntriesUrl = TogglBaseUrl + "/time_entries";
			public const string TimeEntryStartUrl = TogglBaseUrl + "/time_entries/start";
			public const string TimeEntryStopUrl = TogglBaseUrl + "/time_entries/{0}/stop";
			public const string TimeEntryUrl = TogglBaseUrl + "/time_entries/{0}";
			public const string TimeEntryCurrentUrl = TogglBaseUrl + "/time_entries/current";
		}

		public static class Project
		{
			public const string ProjectsBulkDeleteUrl = TogglBaseUrl + "/projects/{0}";
			public const string ProjectsUrl = TogglBaseUrl + "/projects";
			public const string DetailUrl = TogglBaseUrl + "/projects/{0}";
			public const string UsersUrl = TogglBaseUrl + "/projects/{0}/project_users";
			public const string ProjectTasksUrl = TogglBaseUrl + "/projects/{0}/tasks";
		}

		public static class User
		{
			public const string CurrentUrl = TogglBaseUrl + "/me";
			public const string CurrentExtendedUrl = TogglBaseUrl + "/me?with_related_data=true";
			public const string CurrentSinceUrl = TogglBaseUrl + "/me?since={0}&with_related_data=true";
			public const string ResetApiTokenUrl = TogglBaseUrl + "/reset_token";
			public const string EditUrl = TogglBaseUrl + "/me";
			public const string AddUrl = TogglBaseUrl + "/signups";
		}

		public static class Dashboard
		{
			public const string DashboardUrl = TogglBaseUrl + "/dashboard/{0}";
		}
	}
}
