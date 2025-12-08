using AwesomeAssertions;
using Refit;
using System;
using System.Linq;
using System.Threading.Tasks;
using Toggl.Api.Models;
using Xunit;

namespace Toggl.Api.Test;

public class ClientTests(ITestOutputHelper iTestOutputHelper, Fixture fixture) : TogglTest(iTestOutputHelper, fixture)
{
	private static readonly string _crudClientName = "Test Client " + Guid.NewGuid().ToString();

	[Fact]
	public async Task Crud_Client_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();

		// Delete any existing clients with the same name as the test client
		var clients = await TogglClient
			.Clients
			.GetAsync(
				workspaceId,
				ClientStatus.Both,
				null,
				CancellationToken
			);
		var matchingClients = clients
			.Where(p => p.Name == _crudClientName)
			.ToList();

		foreach (var client in matchingClients)
		{
			await TogglClient
				.Clients
				.DeleteAsync(workspaceId, client.Id, CancellationToken);
		}

		// Create a new client
		var newClient = new ClientCreationDto
		{
			Name = _crudClientName,
			WorkspaceId = workspaceId,
		};

		var createdClient = await TogglClient
			.Clients
			.CreateAsync(workspaceId, newClient, CancellationToken);
		createdClient.Should().NotBeNull();

		// Check that it's there
		var refetchedClient = await TogglClient
			.Clients
			.GetAsync(
				workspaceId,
				createdClient.Id,
				CancellationToken
			);
		refetchedClient.Should().NotBeNull();
		refetchedClient!.Name.Should().Be(_crudClientName);
		refetchedClient!.Id.Should().Be(createdClient.Id);

		// Check that it's there in a list all clients
		var allClients = await TogglClient
			.Clients
			.GetAsync(
				workspaceId,
				ClientStatus.Both,
				null,
				CancellationToken
			);

		allClients.Should().NotBeNullOrEmpty();
		allClients.Count(c => c.Name == _crudClientName).Should().Be(1);

		// Update the client
		refetchedClient!.Name = _crudClientName + " updated";
		var updatedClient = await TogglClient
			.Clients
			.UpdateAsync(
				workspaceId,
				refetchedClient.Id,
				refetchedClient,
				CancellationToken
			);
		updatedClient.Should().NotBeNull();

		// Check that it's updated
		var refetchedUpdatedClient = await TogglClient
			.Clients
			.GetAsync(
				workspaceId,
				updatedClient.Id,
				CancellationToken
			);

		refetchedUpdatedClient.Should().NotBeNull();
		refetchedUpdatedClient!.Name.Should().Be(_crudClientName + " updated");
		refetchedUpdatedClient!.Id.Should().Be(updatedClient.Id);

		// Delete the client
		await TogglClient
			.Clients
			.DeleteAsync(
				workspaceId,
				updatedClient.Id,
				CancellationToken
			);

		// Refetching the client should fail with a 404

		await (
			(Func<Task<Client>>)
			(async () =>
			{
				return await TogglClient
					.Clients
					.GetAsync(
						workspaceId,
						updatedClient.Id,
						default
					);
			}
			)
		)
		.Should()
		.ThrowAsync<ApiException>();
	}

	#region Phase 1: Archive and Restore Tests

	[Fact]
	public async Task Client_ArchiveAndRestore_Succeeds()
	{
		var workspaceId = await GetWorkspaceIdAsync();
		var uniqueClientName = $"ArchiveTest_{Guid.NewGuid():N}";

		// Create a new client
		var newClient = new ClientCreationDto
		{
			Name = uniqueClientName,
			WorkspaceId = workspaceId,
		};

		var createdClient = await TogglClient
			.Clients
			.CreateAsync(workspaceId, newClient, CancellationToken);

		try
		{
			createdClient.Should().NotBeNull();

			// Archive the client
			await TogglClient
				.Clients
				.ArchiveAsync(workspaceId, createdClient.Id, CancellationToken);

			// Verify it's archived
			var archivedClient = await TogglClient
				.Clients
				.GetAsync(workspaceId, createdClient.Id, CancellationToken);

			archivedClient.Should().NotBeNull();
			archivedClient.IsArchived.Should().BeTrue();

			// Restore the client
			await TogglClient
				.Clients
				.RestoreAsync(workspaceId, createdClient.Id, CancellationToken);

			// Verify it's restored
			var restoredClient = await TogglClient
				.Clients
				.GetAsync(workspaceId, createdClient.Id, CancellationToken);

			restoredClient.Should().NotBeNull();
			restoredClient.IsArchived.Should().BeFalse();
		}
		finally
		{
			// Clean up - delete the client
			await TogglClient
				.Clients
				.DeleteAsync(workspaceId, createdClient.Id, CancellationToken);
		}
	}

	#endregion
}