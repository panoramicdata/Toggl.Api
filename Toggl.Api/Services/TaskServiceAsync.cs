using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Toggl.Api.DataObjects;
using Toggl.Api.Extensions;
using Toggl.Api.Interfaces;
using Toggl.Api.QueryObjects;
using Toggl.Api.Routes;
using Task = Toggl.Api.DataObjects.Task;

namespace Toggl.Api.Services
{
	public class TaskServiceAsync : ITaskServiceAsync
	{
		private readonly string _togglTasksUrl = ApiRoutes.Task.TogglTasksUrl;

		private IApiServiceAsync TogglSrv { get; }

		public TaskServiceAsync(string apiKey)
			: this(new ApiServiceAsync(apiKey))
		{
		}

		public TaskServiceAsync(IApiServiceAsync srv)
		{
			TogglSrv = srv;
		}

		public async Task<Task> GetAsync(int id)
		{
			var url = string.Format(ApiRoutes.Task.TogglTasksGet, id);
			var response = await TogglSrv.GetAsync(url).ConfigureAwait(false);
			var data = response.GetData<Task>();
			return data;
		}

		/// <summary>
		///Add a task
		/// https://www.toggl.com/public/api#post_tasks
		/// </summary>
		/// <param name="t"></param>
		public async Task<Task> CreateAsync(Task t)
		{
			var response = await TogglSrv.PostAsync(_togglTasksUrl, t.ToJson()).ConfigureAwait(false);
			var data = response.GetData<Task>();
			return data;
		}

		/// <summary>
		/// Edit a task
		/// https://www.toggl.com/public/api#put_tasks
		/// </summary>
		/// <param name="t"></param>
		public async Task<Task> UpdateAsync(Task t)
		{
			var url = string.Format(ApiRoutes.Task.TogglTasksGet, t.Id);
			var response = await TogglSrv.PutAsync(url, t.ToJson()).ConfigureAwait(false);
			var data = response.GetData<Task>();
			return data;
		}

		/// <summary>
		///
		/// https://www.toggl.com/public/api#del_tasks
		/// </summary>
		/// <param name="id"></param>
		public async Task<bool> DeleteAsync(int id)
		{
			var url = string.Format(ApiRoutes.Task.TogglTasksGet, id);

			var rsp = await TogglSrv.DeleteAsync(url).ConfigureAwait(false);

			return rsp.StatusCode == HttpStatusCode.OK;
		}

		public async Task<bool> DeleteIfAnyAsync(int[] ids)
		{
			if (ids.Length == 0 || ids == null)
				return true;
			return await DeleteAsync(ids).ConfigureAwait(false);
		}

		public async Task<bool> DeleteAsync(int[] ids)
		{
			if (ids.Length == 0 || ids == null)
				throw new ArgumentNullException(nameof(ids));

			var url = string.Format(
				ApiRoutes.Task.TogglTasksGet,
				string.Join(",", ids.Select(id => id.ToString()).ToArray()));

			var rsp = await TogglSrv.DeleteAsync(url).ConfigureAwait(false);

			return rsp.StatusCode == HttpStatusCode.OK;
		}

		public async Task<Task> GetForProjectByNameAsync(Project project, string taskName)
		{
			if (!project.Id.HasValue)
				throw new InvalidOperationException("Project Id not set");

			return await GetForProjectByNameAsync(project.Id.Value, taskName).ConfigureAwait(false);
		}

		public async Task<Task> GetForProjectByNameAsync(int projectId, string taskName)
		{
			var projectTasks = await GetForProjectAsync(projectId).ConfigureAwait(false);
			return projectTasks.Single(task => task.Name == taskName);
		}

		public async Task<Task> TryGetForProjectByName(int projectId, string taskName)
		{
			var projectTasks = await GetForProjectAsync(projectId).ConfigureAwait(false);
			return projectTasks.SingleOrDefault(task => task.Name == taskName);
		}

		public async Task<List<Task>> GetForProjectAsync(int id)
		{
			var url = string.Format(ApiRoutes.Project.ProjectTasksUrl, id);
			var response = await TogglSrv.GetAsync(url).ConfigureAwait(false);
			var data = response.GetData<List<Task>>();
			return data;
		}

		public async Task<List<Task>> GetForProjectAsync(Project project)
		{
			if (!project.Id.HasValue)
				throw new InvalidOperationException("Project Id not set");

			return await GetForProjectAsync(project.Id.Value).ConfigureAwait(false);
		}

		public async void MergeAsync(Task masterTask, Task slaveTask, int workspaceId, string userAgent = TogglClient.UserAgent)
		{
			if (!masterTask.Id.HasValue)
				throw new InvalidOperationException("Master task Id not set");

			if (!slaveTask.Id.HasValue)
				throw new InvalidOperationException("Slave task Id not set");

			await MergeAsync(masterTask.Id.Value, slaveTask.Id.Value, workspaceId, userAgent).ConfigureAwait(false);
		}

		public async System.Threading.Tasks.Task MergeAsync(int masterTaskId, int slaveTaskId, int workspaceId, string userAgent = TogglClient.UserAgent)
		{
			var reportService = new ReportServiceAsync(TogglSrv);
			var timeEntryService = new TimeEntryServiceAsync(TogglSrv);

			var reportParams = new DetailedReportParams
			{
				UserAgent = userAgent,
				WorkspaceId = workspaceId,
				TaskIds = slaveTaskId.ToString(),
				Since = DateTime.Now.AddYears(-1).ToIsoDateStr()
			};

			var result = await reportService.Detailed(reportParams).ConfigureAwait(false);

			if (result.TotalCount > result.PerPage)
				result = await reportService.GetFullDetailedReportAsync(reportParams).ConfigureAwait(false);

			foreach (var reportTimeEntry in result.Data ?? throw new FormatException("Data was unexpectedly null"))
			{
				if (reportTimeEntry.Id == null) continue;
				var timeEntry = await timeEntryService.GetAsync(reportTimeEntry.Id.Value).ConfigureAwait(false);
				timeEntry.TaskId = masterTaskId;
				try
				{
					var _ = await timeEntryService.UpdateAsync(timeEntry).ConfigureAwait(false);
				}
				catch (Exception ex)
				{
					var _ = ex.Data;
				}
			}

			if (!await DeleteAsync(slaveTaskId).ConfigureAwait(false))
			{
				throw new InvalidOperationException(string.Format("Can't delete task #{0}", slaveTaskId));
			}
		}

		public async void MergeAsync(int masterTaskId, int[] slaveTasksIds, int workspaceId, string userAgent = TogglClient.UserAgent)
		{
			var reportService = new ReportServiceAsync(TogglSrv);
			var timeEntryService = new TimeEntryServiceAsync(TogglSrv);

			var reportParams = new DetailedReportParams
			{
				UserAgent = userAgent,
				WorkspaceId = workspaceId,
				TaskIds = string.Join(",", slaveTasksIds.Select(id => id.ToString())),
				Since = DateTime.Now.AddYears(-1).ToIsoDateStr()
			};

			var result = await reportService.Detailed(reportParams).ConfigureAwait(false);

			if (result.TotalCount > result.PerPage)
				result = await reportService.GetFullDetailedReportAsync(reportParams).ConfigureAwait(false);

			foreach (var reportTimeEntry in result.Data ?? throw new FormatException("Data was unexpectedly null"))
			{
				if (reportTimeEntry.Id == null)
				{
					continue;
				}
				var timeEntry = await timeEntryService
					.GetAsync(reportTimeEntry.Id.Value)
					.ConfigureAwait(false);
				timeEntry.TaskId = masterTaskId;
				var editedTimeEntry = await timeEntryService
					.UpdateAsync(timeEntry)
					.ConfigureAwait(false);
				if (editedTimeEntry == null)
				{
					throw new ArgumentNullException(string.Format("Can't edit timeEntry #{0}", reportTimeEntry.Id));
				}
			}

			foreach (var slaveTaskId in slaveTasksIds)
			{
				if (!await DeleteAsync(slaveTaskId).ConfigureAwait(false))
				{
					throw new InvalidOperationException(string.Format("Can't delete task #{0}", slaveTaskId));
				}
			}
		}
	}
}