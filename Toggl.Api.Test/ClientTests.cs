using FluentAssertions;
using Refit;
using System.Linq;
using Toggl.Api.Models;
using Xunit;
using Xunit.Abstractions;

namespace Toggl.Api.Test;

public class ClientTests(ITestOutputHelper testOutputHelper) : TogglTest(testOutputHelper)
{
	[Fact]
	public async void Crud_Client_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();

		// Delete any existing clients with the same name as the test client
		var clients = await TogglClient
			.Clients
			.GetAsync(
				workspaceId,
				ClientStatus.Both,
				null,
				default
			);
		var matchingClients = clients
			.Where(p => p.Name == Configuration.CrudClientName)
			.ToList();
		switch (matchingClients.Count)
		{
			case 0:
				// None there. Good.
				break;
			default:
				// Remove them all
				foreach (var client in matchingClients)
				{
					await TogglClient
						.Clients
						.DeleteAsync(workspaceId, client.Id, default);
				}

				break;
		}

		// Create a new client
		var newClient = new ClientCreationDto
		{
			Name = Configuration.CrudClientName,
			WorkspaceId = workspaceId,
		};

		var createdClient = await TogglClient
			.Clients
			.CreateAsync(workspaceId, newClient, default);
		createdClient.Should().NotBeNull();

		// Check that it's there
		var refetchedClient = await TogglClient
			.Clients
			.GetAsync(
				workspaceId,
				createdClient.Id,
				default
			);
		refetchedClient.Should().NotBeNull();
		refetchedClient!.Name.Should().Be(Configuration.CrudClientName);
		refetchedClient!.Id.Should().Be(createdClient.Id);

		// Check that it's there in a list all clients
		var allClients = await TogglClient
			.Clients
			.GetAsync(
				workspaceId,
				ClientStatus.Both,
				null,
				default
			);

		allClients.Should().NotBeNullOrEmpty();
		allClients.Count(c => c.Name == Configuration.CrudClientName).Should().Be(1);

		// Update the client
		refetchedClient!.Name = Configuration.CrudClientName + " updated";
		var updatedClient = await TogglClient
			.Clients
			.UpdateAsync(
				workspaceId,
				refetchedClient.Id,
				refetchedClient,
				default
			);
		updatedClient.Should().NotBeNull();

		// Check that it's updated
		var refetchedUpdatedClient = await TogglClient
			.Clients
			.GetAsync(
				workspaceId,
				updatedClient.Id,
				default
			);

		refetchedUpdatedClient.Should().NotBeNull();
		refetchedUpdatedClient!.Name.Should().Be(Configuration.CrudClientName + " updated");
		refetchedUpdatedClient!.Id.Should().Be(updatedClient.Id);

		// Delete the client
		await TogglClient
			.Clients
			.DeleteAsync(
				workspaceId,
				updatedClient.Id,
				default
			);

		// Refetching the client should fail with a 404
		await Assert.ThrowsAsync<ApiException>(async () =>
			{
				await TogglClient
					.Clients
					.GetAsync(
						workspaceId,
						updatedClient.Id,
						default
					);
			}
		);
	}
}