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
			var workspaces = await TogglClient.Workspaces.List();
			var togglWorkspace = workspaces.SingleOrDefault(w=>w.Name == Configuration.SampleWorkspaceName);
			Assert.NotNull(togglWorkspace);

			var projects = await TogglClient.Projects.List();
			var togglProject = projects.SingleOrDefault(p => p.Name == Configuration.SampleProjectName);
			Assert.NotNull(togglProject);

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
			});
			Assert.NotNull(detailedReport);
		}
	}
}