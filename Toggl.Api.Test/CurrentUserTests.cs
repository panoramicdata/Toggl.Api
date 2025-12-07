using AwesomeAssertions;
using System.Threading.Tasks;
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
}