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

		await DeleteClientsNamedAsync(workspaceId, _crudClientName);

		var createdClient = await CreateClientAsync(workspaceId, _crudClientName);

		await AssertClientIsPresentAsync(workspaceId, createdClient.Id, _crudClientName);

		var updatedName = _crudClientName + " updated";
		var updatedClient = await RenameClientAsync(workspaceId, createdClient.Id, updatedName);

		await AssertClientIsPresentAsync(workspaceId, updatedClient.Id, updatedName);

		await TogglClient
			.Clients
			.DeleteAsync(
				workspaceId,
				updatedClient.Id,
				CancellationToken
			);

		await AssertClientIsAbsentAsync(workspaceId, updatedClient.Id);
	}

	/// <summary>
	/// Removes any clients left behind by an earlier run, so that the count assertions below are exact.
	/// </summary>
	private async Task DeleteClientsNamedAsync(long workspaceId, string name)
	{
		var clients = await TogglClient
			.Clients
			.GetAsync(
				workspaceId,
				ClientStatus.Both,
				null,
				CancellationToken
			);

		var matchingClients = clients
			.Where(p => p.Name == name)
			.ToList();

		foreach (var client in matchingClients)
		{
			await TogglClient
				.Clients
				.DeleteAsync(workspaceId, client.Id, CancellationToken);
		}
	}

	private async Task<Client> CreateClientAsync(long workspaceId, string name)
	{
		var newClient = new ClientCreationDto
		{
			Name = name,
			WorkspaceId = workspaceId,
		};

		var createdClient = await TogglClient
			.Clients
			.CreateAsync(workspaceId, newClient, CancellationToken);
		createdClient.Should().NotBeNull();

		return createdClient;
	}

	private async Task<Client> RenameClientAsync(long workspaceId, long clientId, string newName)
	{
		var client = await TogglClient
			.Clients
			.GetAsync(
				workspaceId,
				clientId,
				CancellationToken
			);
		client.Should().NotBeNull();

		client!.Name = newName;

		var updatedClient = await TogglClient
			.Clients
			.UpdateAsync(
				workspaceId,
				client.Id,
				client,
				CancellationToken
			);
		updatedClient.Should().NotBeNull();

		return updatedClient;
	}

	/// <summary>
	/// Asserts that the client can be fetched by id, and that it appears exactly once when all
	/// clients in the workspace are listed.
	/// </summary>
	private async Task AssertClientIsPresentAsync(long workspaceId, long clientId, string expectedName)
	{
		var refetchedClient = await TogglClient
			.Clients
			.GetAsync(
				workspaceId,
				clientId,
				CancellationToken
			);

		refetchedClient.Should().NotBeNull();
		refetchedClient!.Name.Should().Be(expectedName);
		refetchedClient!.Id.Should().Be(clientId);

		var allClients = await TogglClient
			.Clients
			.GetAsync(
				workspaceId,
				ClientStatus.Both,
				null,
				CancellationToken
			);

		allClients.Should().NotBeNullOrEmpty();
		allClients.Count(c => c.Name == expectedName).Should().Be(1);
	}

	private async Task AssertClientIsAbsentAsync(long workspaceId, long clientId)
	{
		// Refetching the client should fail with a 404
		await (
			(Func<Task<Client>>)
			(async () =>
			{
				return await TogglClient
					.Clients
					.GetAsync(
						workspaceId,
						clientId,
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