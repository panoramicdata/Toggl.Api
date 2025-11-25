using AwesomeAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Toggl.Api.Test;

public class MeTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
{
	[Fact]
	public async Task Me_Get_WithoutRelatedData_Succeeds()
	{
		var me = await TogglClient
			.Me
			.GetAsync(false, CancellationToken);

		me.Should().NotBeNull();
		me.Clients.Should().BeNullOrEmpty();
		me.Workspaces.Should().BeNullOrEmpty();
		me.Projects.Should().BeNullOrEmpty();
	}

	[Fact]
	public async Task Me_Get_WithRelatedData_Succeeds()
	{
		var me = await TogglClient
			.Me
			.GetAsync(true, CancellationToken);

		me.Should().NotBeNull();
	}

	[Fact]
	public async Task Me_GetClients_Succeeds()
	{
		var clients = await TogglClient
			.Me
			.GetClientsAsync(null, CancellationToken);

		clients.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task Me_GetFeatures_Succeeds()
	{
		var features = await TogglClient
			.Me
			.GetFeaturesAsync(CancellationToken);

		features.Should().NotBeNullOrEmpty();
	}

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public async Task Me_GetTasks_Succeeds(bool includeInactive)
	{
		var tasks = await TogglClient
			.Me
			.GetTasksAsync(null, includeInactive, CancellationToken);
		tasks.Should().NotBeNull();
	}

	[Fact]
	public async Task Me_GetWebTimer_Succeeds()
		=> await TogglClient
			.Me
			.GetWebTimerAsync(CancellationToken);

	[Fact]
	public async Task Me_GetLastKnownLocation_Succeeds()
	{
		var location = await TogglClient
			.Me
			.GetLastKnownLocationAsync(CancellationToken);

		location.Should().NotBeNull();
	}

	[Fact]
	public async Task Me_GetOrganizations_Succeeds()
	{
		var organizations = await TogglClient
			.Me
			.GetOrganizationsAsync(CancellationToken);

		organizations.Should().NotBeNull();
	}

	[Fact]
	public async Task Me_GetLogged_Succeeds() => await TogglClient
		.Me
		.GetLoggedAsync(CancellationToken);

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public async Task Me_GetProjects_Succeeds(bool includeArchived)
	{
		var projects = await TogglClient
			.Me
			.GetProjectsAsync(includeArchived, null, CancellationToken);

		projects.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task Me_GetProjectsPaginated_Succeeds()
	{
		var projects = await TogglClient
			.Me
			.GetProjectsPaginatedAsync(null, null, 201, CancellationToken);

		projects.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task Me_GetTags_Succeeds()
	{
		var projects = await TogglClient
			.Me
			.GetTagsAsync(null, CancellationToken);

		projects.Should().NotBeNullOrEmpty();
	}
}