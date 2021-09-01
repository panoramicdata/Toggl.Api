using FluentAssertions;
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
			togglWorkspace.Should().NotBeNull();

			List<DataObjects.Project> projects = await TogglClient
				.Projects
				.ListAsync()
				.ConfigureAwait(false);

			projects.Should().NotBeNullOrEmpty();

			var togglProject = projects.SingleOrDefault(p => p.Name == Configuration.SampleProjectName);
			togglProject.Should().NotBeNull();
			togglProject!.Id.Should().NotBeNull();

			var utcNow = DateTime.UtcNow;
			var endDateTime = new DateTime(utcNow.Year, utcNow.Month, 1);
			var startDateTime = endDateTime.AddMonths(-1);

			var detailedReport = await TogglClient.Reports.Detailed(new DetailedReportParams
			{
				UserAgent = "TogglAPI.Net",
				WorkspaceId = togglWorkspace!.Id,
				Since = startDateTime.ToIsoDateStr(),
				Until = endDateTime.ToIsoDateStr(),
				ProjectIds = new List<long> { togglProject!.Id!.Value },
				Page = 1
			}).ConfigureAwait(false);
			detailedReport.Should().NotBeNull();
			detailedReport.Data.Should().NotBeNull();

			// Re-fetch the time entries
			var timeEntryIds = detailedReport?.Data?.ConvertAll(d => d.Id);
			timeEntryIds.Should().NotBeNull();

			var success = false;
			foreach (var timeEntryId in timeEntryIds!)
			{
				try
				{
					var refetchedTimeEntry = await TogglClient
						.TimeEntries
						.GetAsync(timeEntryId!.Value)
						.ConfigureAwait(false);
					refetchedTimeEntry.Id.Should().Be(timeEntryId);
					success = true;
				}
				catch
				{
					// This happens, but should not happen all the time.
				}
			}
			success.Should().Be(true);
		}
	}
}