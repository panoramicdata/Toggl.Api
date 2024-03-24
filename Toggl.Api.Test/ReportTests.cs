using FluentAssertions;
using System;
using System.Linq;
using Toggl.Api.Extensions;
using Toggl.Api.QueryObjects;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class ReportTests(ITestOutputHelper testOutputHelper) : TogglTest(testOutputHelper)
{
	[Fact]
	public async void List()
	{
		var workspaceId = await GetWorkspaceIdAsync();

		var projects = await TogglClient
			.Projects
			.GetAllAsync(workspaceId, default);

		projects.Should().NotBeNullOrEmpty();

		var togglProject = projects.SingleOrDefault(p => p.Name == Configuration.SampleProjectName);
		togglProject.Should().NotBeNull();
		togglProject.Id.Should().NotBe(0);

		var utcNow = DateTime.UtcNow;
		var endDateTime = new DateTime(utcNow.Year, utcNow.Month, 1);
		var startDateTime = endDateTime.AddMonths(-1);

		var detailedReport = await TogglClient
			.Reports
			.DetailedAsync(new DetailedReportParams
			{
				UserAgent = "TogglAPI.Net",
				WorkspaceId = workspaceId,
				Since = startDateTime.ToIsoDateStr(),
				Until = endDateTime.ToIsoDateStr(),
				ProjectIds = [togglProject!.Id],
				Page = 1
			}, default);

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
					.GetAsync(timeEntryId, default);
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
