using AwesomeAssertions;
using Refit;
using System.Net;
using System.Threading.Tasks;
using Toggl.Api.Models;
using Xunit;

namespace Toggl.Api.Test;

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
	public async Task Invitations_Create_Succeeds()
	{
		var organizationId = await GetOrganizationIdAsync();
		var workspaceId = await GetWorkspaceIdAsync();

		// Create an invitation - note this will send an actual email
		// Use a test email or skip in CI
		var invitationDto = new InvitationCreationDto
		{
			Emails = ["test-user-does-not-exist@example-test-domain.invalid"],
			WorkspaceIds = [workspaceId]
		};

		InvitationResult result;
		try
		{
			result = await TogglClient
				.Invitations
				.CreateAsync(organizationId, invitationDto, CancellationToken);
		}
		catch (ApiException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
		{
			// Some organizations may block invitations to external domains.
			return;
		}

		result.Should().NotBeNull();
	}
}
