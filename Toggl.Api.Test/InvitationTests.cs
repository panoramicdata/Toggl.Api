using AwesomeAssertions;
using Refit;
using System;
using System.Net;
using System.Threading.Tasks;
using Toggl.Api.Models;
using Xunit;

namespace Toggl.Api.Test;

/// <summary>
/// Live invitation tests. Invitations_Create_Succeeds leaves an invitation that no API call can remove, so it runs only against a dedicated test organisation set in Configuration:InvitationTestOrganizationId and Configuration:InvitationTestWorkspaceId, and is excluded from default runs by its IrreversibleLiveWrite trait (see the README).
/// </summary>
public class InvitationTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
{
	/// <summary>
	/// Note: We can't fully test invitation creation/acceptance without a second account,
	/// but we can test that the endpoint is accessible and returns expected error for invalid codes.
	/// </summary>
	[Fact]
	public async Task Invitations_Get_InvalidCode_Returns404()
	{
		// Using an invalid code should return 404
		var exception = await Assert.ThrowsAsync<ApiException>(async () =>
		{
			await TogglClient
				.Invitations
				.GetAsync("invalid-code-12345", CancellationToken);
		});

		exception.StatusCode.Should().Be(HttpStatusCode.NotFound);
	}

	[Fact]
	[Trait("Category", "IrreversibleLiveWrite")]
	public async Task Invitations_Create_Succeeds()
	{
		// Fail fast, before any network call, unless the dedicated test organisation is configured.
		var configurationProblem = InvitationTestGate.GetConfigurationProblem(
			Configuration.InvitationTestOrganizationId,
			Configuration.InvitationTestWorkspaceId);
		if (configurationProblem is not null)
		{
			Assert.Fail(configurationProblem);
		}

		var organizationId = Configuration.InvitationTestOrganizationId!.Value;
		var workspaceId = Configuration.InvitationTestWorkspaceId!.Value;

		// A read-only lookup, to refuse the organisation that the API key's default workspace belongs to.
		var productionProblem = InvitationTestGate.GetProductionProblem(organizationId, await GetOrganizationIdAsync());
		if (productionProblem is not null)
		{
			Assert.Fail(productionProblem);
		}

		var inviteeEmail = $"toggl-api-test-{Guid.NewGuid():N}@example-test-domain.invalid";

		// The invitation cannot be removed through the API afterwards, hence the dedicated organisation.
		var invitationDto = new InvitationCreationDto
		{
			Emails = [inviteeEmail],
			WorkspaceIds = [workspaceId]
		};

		var result = await TogglClient
			.Invitations
			.CreateAsync(organizationId, invitationDto, CancellationToken);

		result.Should().NotBeNull();
	}
}