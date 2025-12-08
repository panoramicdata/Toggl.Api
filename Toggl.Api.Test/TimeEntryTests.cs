using AwesomeAssertions;
using System;
using System.Threading.Tasks;
using Toggl.Api.Models;
using Xunit;

namespace Toggl.Api.Test;

public class TimeEntryTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
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
			.GetAsync(includeMeta, includeSharingDetails, null, null, null, null, CancellationToken);

		timeEntries.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task TimeEntries_Get_WithDates_Succeeds()
	{
		var startDate = DateTimeOffset.Now.AddDays(-5);
		var endDate = DateTimeOffset.Now;
		var timeEntries = await TogglClient
			.TimeEntries
			.GetAsync(false, false, null, null, startDate, endDate, CancellationToken);

		timeEntries.Should().NotBeNull();
	}

	#region Phase 1: Time Entry CRUD Tests

	[Fact]
	public async Task TimeEntries_GetCurrent_Succeeds()
	{
		// Get current running time entry (may be null if none running)
		var currentEntry = await TogglClient
			.TimeEntries
			.GetAsync(CancellationToken);

		// Current entry can be null if no timer is running
		// This test just verifies the endpoint works
	}

	[Fact]
	public async Task TimeEntries_Crud_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();
		var startTime = DateTimeOffset.UtcNow;

		// Create a time entry
		var createDto = new TimeEntryCreationDto
		{
			WorkspaceId = workspaceId,
			CreatedWith = "Toggl.Api.Test",
			Description = "Test Time Entry from Unit Tests",
			Start = startTime,
			Duration = -1 // Running entry
		};

		var createdEntry = await TogglClient
			.TimeEntries
			.CreateAsync(workspaceId, createDto, CancellationToken);

		try
		{
			createdEntry.Should().NotBeNull();
			createdEntry.Description.Should().Be("Test Time Entry from Unit Tests");
			createdEntry.WorkspaceId.Should().Be(workspaceId);

			// Get the time entry by ID
			var fetchedEntry = await TogglClient
				.TimeEntries
				.GetAsync(createdEntry.Id, CancellationToken);

			fetchedEntry.Should().NotBeNull();
			fetchedEntry.Id.Should().Be(createdEntry.Id);

			// Stop the time entry
			var stoppedEntry = await TogglClient
				.TimeEntries
				.StopAsync(workspaceId, createdEntry.Id, CancellationToken);

			stoppedEntry.Should().NotBeNull();
			stoppedEntry.Duration.Should().BeGreaterThan(0);

			// Update the time entry
			var updateDto = new TimeEntryUpdateDto
			{
				WorkspaceId = workspaceId,
				Description = "Updated Test Time Entry"
			};

			var updatedEntry = await TogglClient
				.TimeEntries
				.UpdateAsync(workspaceId, createdEntry.Id, updateDto, CancellationToken);

			updatedEntry.Should().NotBeNull();
			updatedEntry.Description.Should().Be("Updated Test Time Entry");
		}
		finally
		{
			// Clean up - delete the time entry
			await TogglClient
				.TimeEntries
				.DeleteAsync(workspaceId, createdEntry.Id, CancellationToken);
		}
	}

	#endregion
}
