using FluentAssertions;
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
	public async void TimeEntries_Get_WithAndWithoutMetaAndSharingDetails_Succeeds(
		bool includeMeta,
		bool includeSharingDetails)
	{
		var timeEntries = await TogglClient
			.TimeEntries
			.GetAsync(includeMeta, includeSharingDetails, null, null, null, null, default);

		timeEntries.Should().NotBeNullOrEmpty();
	}
}