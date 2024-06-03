using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class TimeEntryTests(ITestOutputHelper testOutputHelper) : TogglTest(testOutputHelper)
{
	[Theory]
	[InlineData(true, true)]
	[InlineData(true, false)]
	[InlineData(false, true)]
	[InlineData(false, false)]
	public async Task TimeEntries_Get_WithAndWithoutMetaAndSharingDetails_Succeeds(
		bool includeMeta,
		bool includeSharingDetails)
	{
		var timeEntries = await TogglClient
			.TimeEntries
			.GetAsync(includeMeta, includeSharingDetails, null, null, null, null, default);

		timeEntries.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task TimeEntries_Get_WithDates_Succeeds()
	{
		var startDate = DateTimeOffset.Now.AddDays(-5);
		var endDate = DateTimeOffset.Now;
		var timeEntries = await TogglClient
			.TimeEntries
			.GetAsync(false, false, null, null, startDate, endDate, default);

		timeEntries.Should().NotBeNullOrEmpty();
	}
}
