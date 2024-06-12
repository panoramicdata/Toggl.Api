using Refit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;


namespace Toggl.Api.Interfaces;

/// <summary>
/// https://engineering.toggl.com/docs/api/clients
/// </summary>
public interface IClients
{
	/// <summary>
	/// Get clients for a workspace
	/// https://engineering.toggl.com/docs/api/clients#get-list-clients
	/// </summary>
	/// <param name="workspaceId"></param>
	/// <param name="clientStatus"></param>
	/// <param name="nameContains"></param>
	/// <param name="cancellationToken">The cancellation token</param>
	/// <returns></returns>
	[Get("/api/v9/workspaces/{workspaceId}/clients")]
	Task<ICollection<Client>> GetAsync(
		long workspaceId,
		[AliasAs("status")] ClientStatus? clientStatus,
		[AliasAs("name")] string? nameContains,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Create a client for a workspace
	/// https://engineering.toggl.com/docs/api/clients#post-create-client
	/// </summary>
	/// <param name="client">The client to create</param>
	/// <returns></returns>
	[Post("/api/v9/workspaces/{workspaceId}/clients")]
	Task<Client> CreateAsync(
		long workspaceId,
		[Body] ClientCreationDto client,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Get a client by id for a workspace
	/// https://engineering.toggl.com/docs/api/clients#get-load-client-from-id
	/// </summary>
	/// <param name="workspaceId"></param>
	/// <param name="clientId"></param>
	/// <returns></returns>
	[Get("/api/v9/workspaces/{workspaceId}/clients/{clientId}")]
	Task<Client> GetAsync(
		long workspaceId,
		long clientId,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Update a client for a workspace
	/// </summary>
	/// <param name="workspaceId"></param>
	/// <param name="clientId"></param>
	/// <param name="client"></param>
	/// <returns></returns>
	[Put("/api/v9/workspaces/{workspaceId}/clients/{clientId}")]
	Task<Client> UpdateAsync(
		long workspaceId,
		long clientId,
		[Body] Client client,
		CancellationToken cancellationToken
		);

	/// <summary>
	/// Delete a client for a workspace
	/// https://engineering.toggl.com/docs/api/clients#delete-delete-client
	/// </summary>
	/// <param name="workspaceId"></param>
	/// <param name="clientId"></param>
	/// <returns></returns>
	[Delete("/api/v9/workspaces/{workspaceId}/clients/{clientId}")]
	Task DeleteAsync(
		long workspaceId,
		long clientId,
		CancellationToken cancellationToken
		);
}