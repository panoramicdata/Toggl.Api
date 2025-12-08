using AwesomeAssertions;
using System.Threading.Tasks;
using Toggl.Api.Models;
using Xunit;

namespace Toggl.Api.Test;

public class CurrentUserTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
{
	[Fact]
	public async Task CurrentUser_Get_WithoutRelatedData_Succeeds()
	{
		var me = await TogglClient
			.CurrentUser
			.GetAsync(false, CancellationToken);

		me.Should().NotBeNull();
		me.Clients.Should().BeNullOrEmpty();
		me.Workspaces.Should().BeNullOrEmpty();
		me.Projects.Should().BeNullOrEmpty();
	}

	[Fact]
	public async Task CurrentUser_Get_WithRelatedData_Succeeds()
	{
		var me = await TogglClient
			.CurrentUser
			.GetAsync(true, CancellationToken);

		me.Should().NotBeNull();
	}

	[Fact]
	public async Task CurrentUser_GetClients_Succeeds()
	{
		var clients = await TogglClient
			.CurrentUser
			.GetClientsAsync(null, CancellationToken);

		clients.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task CurrentUser_GetFeatures_Succeeds()
	{
		var features = await TogglClient
			.CurrentUser
			.GetFeaturesAsync(CancellationToken);

		features.Should().NotBeNullOrEmpty();
	}

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public async Task CurrentUser_GetTasks_Succeeds(bool includeInactive)
	{
		var tasks = await TogglClient
			.CurrentUser
			.GetTasksAsync(null, includeInactive, CancellationToken);
		tasks.Should().NotBeNull();
	}

	[Fact]
	public async Task CurrentUser_GetWebTimer_Succeeds()
		=> await TogglClient
			.CurrentUser
			.GetWebTimerAsync(CancellationToken);

	[Fact]
	public async Task CurrentUser_GetLastKnownLocation_Succeeds()
	{
		var location = await TogglClient
			.CurrentUser
			.GetLastKnownLocationAsync(CancellationToken);

		location.Should().NotBeNull();
	}

	[Fact]
	public async Task CurrentUser_GetOrganizations_Succeeds()
	{
		var organizations = await TogglClient
			.CurrentUser
			.GetOrganizationsAsync(CancellationToken);

		organizations.Should().NotBeNull();
	}

	[Fact]
	public async Task CurrentUser_GetLogged_Succeeds() => await TogglClient
		.CurrentUser
		.GetLoggedAsync(CancellationToken);

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public async Task CurrentUser_GetProjects_Succeeds(bool includeArchived)
	{
		var projects = await TogglClient
			.CurrentUser
			.GetProjectsAsync(includeArchived, null, CancellationToken);

		projects.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task CurrentUser_GetProjectsPaginated_Succeeds()
	{
		var projects = await TogglClient
			.CurrentUser
			.GetProjectsPaginatedAsync(null, null, 201, CancellationToken);

		projects.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task CurrentUser_GetTags_Succeeds()
	{
		var projects = await TogglClient
			.CurrentUser
			.GetTagsAsync(null, CancellationToken);

		projects.Should().NotBeNullOrEmpty();
	}

	#region Phase 1: Favorites Tests

	[Fact]
	public async Task CurrentUser_GetFavorites_Succeeds()
	{
		var favorites = await TogglClient
			.CurrentUser
			.GetFavoritesAsync(null, CancellationToken);

		// Favorites may be empty, but should not be null
		favorites.Should().NotBeNull();
	}

	[Fact]
	public async Task CurrentUser_Crud_Favorite_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();

		// Create a favorite
		var favoriteDto = new FavoriteDto
		{
			WorkspaceId = workspaceId,
			Description = "Test Favorite from Unit Tests"
		};

		var createdFavorite = await TogglClient
			.CurrentUser
			.CreateFavoriteAsync(true, favoriteDto, CancellationToken);

		try
		{
			createdFavorite.Should().NotBeNull();
			createdFavorite.Description.Should().Be("Test Favorite from Unit Tests");
			createdFavorite.WorkspaceId.Should().Be(workspaceId);

			// Get favorites to verify it exists
			var favorites = await TogglClient
				.CurrentUser
				.GetFavoritesAsync(null, CancellationToken);

			favorites.Should().Contain(f => f.Id == createdFavorite.Id);
		}
		finally
		{
			// Clean up - delete the favorite
			await TogglClient
				.CurrentUser
				.DeleteFavoriteAsync(createdFavorite.Id, CancellationToken);
		}
	}

	#endregion

	#region Phase 1: Flags Tests

	[Fact]
	public async Task CurrentUser_GetFlags_Succeeds()
	{
		var flags = await TogglClient
			.CurrentUser
			.GetFlagsAsync(CancellationToken);

		// Flags may be empty, but should not be null
		flags.Should().NotBeNull();
	}

	[Fact]
	public async Task CurrentUser_PostFlags_Succeeds()
	{
		// Create a test flag
		var testFlags = new UserFlags
		{
			["test_flag_key"] = "test_value"
		};

		var result = await TogglClient
			.CurrentUser
			.PostFlagsAsync(testFlags, CancellationToken);

		result.Should().NotBeNull();
	}

	#endregion

	#region Phase 1: Preferences Tests

	[Fact]
	public async Task CurrentUser_GetPreferences_Succeeds()
	{
		var preferences = await TogglClient
			.CurrentUser
			.GetPreferencesAsync(CancellationToken);

		preferences.Should().NotBeNull();
	}

	[Theory]
	[InlineData("desktop")]
	[InlineData("web")]
	public async Task CurrentUser_GetPreferences_ByClient_Succeeds(string client)
	{
		var preferences = await TogglClient
			.CurrentUser
			.GetPreferencesAsync(client, null, CancellationToken);

		preferences.Should().NotBeNull();
	}

	#endregion

	#region Phase 1: Export Tests

	[Fact]
	public async Task CurrentUser_GetExports_Succeeds()
	{
		var exports = await TogglClient
			.CurrentUser
			.GetExportsAsync(CancellationToken);

		// Exports may be empty, but should not be null
		exports.Should().NotBeNull();
	}

	#endregion

	#region Phase 1: Quota Tests

	[Fact]
	public async Task CurrentUser_GetQuota_Succeeds()
	{
		var quotas = await TogglClient
			.CurrentUser
			.GetQuotaAsync(CancellationToken);

		quotas.Should().NotBeNull();
	}

	#endregion

	#region Phase 1: Track Reminders and Timesheets Tests

	[Fact]
	public async Task CurrentUser_GetTrackReminders_Succeeds()
	{
		var trackReminders = await TogglClient
			.CurrentUser
			.GetTrackRemindersAsync(CancellationToken);

		// Track reminders may be empty, but should not be null
		trackReminders.Should().NotBeNull();
	}

	[Fact]
	public async Task CurrentUser_GetTimesheets_Succeeds()
	{
		var timesheets = await TogglClient
			.CurrentUser
			.GetTimesheetsAsync(CancellationToken);

		// Timesheets may be empty, but should not be null
		timesheets.Should().NotBeNull();
	}

	#endregion

	#region Phase 1: Other Me Endpoints Tests

	[Fact]
	public async Task CurrentUser_GetId_Succeeds()
	{
		var userId = await TogglClient
			.CurrentUser
			.GetIdAsync(CancellationToken);

		userId.Should().BeGreaterThan(0);
	}

	[Fact]
	public async Task CurrentUser_AcceptTos_Succeeds()
	{
		// This just verifies the endpoint is callable
		// In a real scenario, this would accept the Terms of Service
		await TogglClient
			.CurrentUser
			.AcceptTosAsync(CancellationToken);
	}

	[Fact]
	public async Task CurrentUser_GetPushServices_Succeeds()
	{
		var pushServices = await TogglClient
			.CurrentUser
			.GetPushServicesAsync(CancellationToken);

		// Push services may be empty, but should not be null
		pushServices.Should().NotBeNull();
	}

	#endregion
}