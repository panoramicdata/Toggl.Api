using System;
using System.Collections.Generic;
using System.Linq;
using Toggl.Api.Extensions;
using Toggl.Api.QueryObjects;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test
{
	public class ReportTests : TogglTest
	{
		public ReportTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
		{
		}

		[Fact]
		public async void List()
		{
			var workspaces = await TogglClient
				.Workspaces
				.GetAllAsync()
				.ConfigureAwait(false);
			var togglWorkspace = workspaces.SingleOrDefault(w => w.Name == Configuration.SampleWorkspaceName);
			Assert.NotNull(togglWorkspace);

			List<DataObjects.Project> projects = await TogglClient
				.Projects
				.ListAsync()
				.ConfigureAwait(false);
			var togglProject = projects.SingleOrDefault(p => p.Name == Configuration.SampleProjectName);
			Assert.NotNull(togglProject);
			Assert.NotNull(togglProject.Id);

			var utcNow = DateTime.UtcNow;
			var endDateTime = new DateTime(utcNow.Year, utcNow.Month, 1);
			var startDateTime = endDateTime.AddMonths(-1);

			var detailedReport = await TogglClient.Reports.Detailed(new DetailedReportParams
			{
				UserAgent = "TogglAPI.Net",
				WorkspaceId = togglWorkspace.Id,
				Since = startDateTime.ToIsoDateStr(),
				Until = endDateTime.ToIsoDateStr(),
				ProjectIds = new List<int> { togglProject.Id.Value },
				Page = 1
			}).ConfigureAwait(false);
			Assert.NotNull(detailedReport);

			// Refetch the time entries
			var timeEntryIds = detailedReport.Data.ConvertAll(d => d.Id);

			foreach (var timeEntryId in timeEntryIds)
			{
				var refetchedTimeEntry = await TogglClient
					.TimeEntries
					.GetAsync(timeEntryId.Value)
					.ConfigureAwait(false);
				Assert.Equal(timeEntryId, refetchedTimeEntry.Id);
			}
		}
	}
}