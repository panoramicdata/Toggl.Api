using FluentAssertions;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class MeTests(ITestOutputHelper testOutputHelper) : TogglTest(testOutputHelper)
{
	[Fact]
	public async Task Me_Get_WithoutRelatedData_Succeeds()
	{
		var me = await TogglClient
			.Me
			.GetAsync(false, default);

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
			.GetAsync(true, default);

		me.Should().NotBeNull();
	}

	[Fact]
	public async Task Me_GetClients_Succeeds()
	{
		var clients = await TogglClient
			.Me
			.GetClientsAsync(null, default);

		clients.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task Me_GetFeatures_Succeeds()
	{
		var features = await TogglClient
			.Me
			.GetFeaturesAsync(default);

		features.Should().NotBeNullOrEmpty();
	}

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public async Task Me_GetTasks_Succeeds(bool includeInactive)
	{
		var tasks = await TogglClient
			.Me
			.GetTasksAsync(null, includeInactive, default);
		tasks.Should().NotBeNull();
	}

	[Fact]
	public async Task Me_GetWebTimer_Succeeds()
		=> await TogglClient
			.Me
			.GetWebTimerAsync(default);

	[Fact]
	public async Task Me_GetLastKnownLocation_Succeeds()
	{
		var location = await TogglClient
			.Me
			.GetLastKnownLocationAsync(default);

		location.Should().NotBeNull();
	}

	[Fact]
	public async Task Me_GetOrganizations_Succeeds()
	{
		var organizations = await TogglClient
			.Me
			.GetOrganizationsAsync(default);

		organizations.Should().NotBeNull();
	}

	[Fact]
	public async Task Me_GetLogged_Succeeds() => await TogglClient
		.Me
		.GetLoggedAsync(default);

	[Theory]
	[InlineData(true)]
	[InlineData(false)]
	public async Task Me_GetProjects_Succeeds(bool includeArchived)
	{
		var projects = await TogglClient
			.Me
			.GetProjectsAsync(includeArchived, null, default);

		projects.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task Me_GetProjectsPaginated_Succeeds()
	{
		var projects = await TogglClient
			.Me
			.GetProjectsPaginatedAsync(null, null, 201, default);

		projects.Should().NotBeNullOrEmpty();
	}

	[Fact]
	public async Task Me_GetTags_Succeeds()
	{
		var projects = await TogglClient
			.Me
			.GetTagsAsync(null, default);

		projects.Should().NotBeNullOrEmpty();
	}
}