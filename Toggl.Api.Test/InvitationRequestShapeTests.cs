using AwesomeAssertions;
using Refit;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Interfaces;
using Toggl.Api.Models;
using Xunit;

namespace Toggl.Api.Test;

/// <summary>
/// Offline tests of the invitation request and of the guard on the live invitation test, with no network access.
/// </summary>
public class InvitationRequestShapeTests
{
	private sealed class StubHandler : HttpMessageHandler
	{
		public HttpRequestMessage? Request { get; private set; }

		public string? Body { get; private set; }

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			Request = request;
			Body = request.Content is null ? null : await request.Content.ReadAsStringAsync(cancellationToken);
			return new HttpResponseMessage(HttpStatusCode.OK)
			{
				Content = new StringContent("{\"data\":[{\"email\":\"a@example.invalid\",\"invitation_id\":7}]}", Encoding.UTF8, "application/json")
			};
		}
	}

	[Fact]
	public async Task Create_SendsPostWithEmailsAndWorkspacesToOrganizationInvitations()
	{
		using var handler = new StubHandler();
		using var httpClient = new HttpClient(handler) { BaseAddress = new Uri("https://stub.invalid/") };
		var invitations = RestService.For<IInvitations>(httpClient, new RefitSettings
		{
			ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
				Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
			})
		});

		var result = await invitations.CreateAsync(
			123,
			new InvitationCreationDto { Emails = ["a@example.invalid"], WorkspaceIds = [456] },
			TestContext.Current.CancellationToken);

		handler.Request.Should().NotBeNull();
		handler.Request!.Method.Should().Be(HttpMethod.Post);
		handler.Request.RequestUri!.AbsolutePath.Should().Be("/api/v9/organizations/123/invitations");
		using var body = JsonDocument.Parse(handler.Body!);
		body.RootElement.GetProperty("emails").EnumerateArray().Should().ContainSingle().Which.GetString().Should().Be("a@example.invalid");
		body.RootElement.GetProperty("workspaces").EnumerateArray().Should().ContainSingle().Which.GetProperty("workspace_id").GetInt64().Should().Be(456);
		result.Data.Should().ContainSingle().Which.InvitationId.Should().Be(7);
	}

	[Theory]
	[InlineData(null, null)]
	[InlineData(1L, null)]
	[InlineData(null, 2L)]
	public void GetConfigurationProblem_WhenNotFullyConfigured_NamesBothSettings(long? organizationId, long? workspaceId)
	{
		var problem = InvitationTestGate.GetConfigurationProblem(organizationId, workspaceId);

		problem.Should().Contain(InvitationTestGate.OrganizationSetting).And.Contain(InvitationTestGate.WorkspaceSetting);
	}

	[Fact]
	public void GetConfigurationProblem_WhenConfigured_ReturnsNull()
		=> InvitationTestGate.GetConfigurationProblem(1, 2).Should().BeNull();

	[Fact]
	public void GetProductionProblem_WhenSameAsDefaultOrganization_Refuses()
		=> InvitationTestGate.GetProductionProblem(5, 5).Should().Contain("production");

	[Fact]
	public void GetProductionProblem_WhenDifferent_ReturnsNull()
		=> InvitationTestGate.GetProductionProblem(5, 6).Should().BeNull();
}
