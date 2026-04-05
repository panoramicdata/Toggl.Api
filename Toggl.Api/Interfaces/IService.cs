using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Toggl.Api.Models;

namespace Toggl.Api.Interfaces;

/// <summary>
/// Generic service interface for CRUD operations.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
public interface IService<T> where T : IdentifiedItem
{
	/// <summary>
	/// List API Services
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#get-clients-visible-to-user
	/// </summary>
	Task<List<T>> GetAllAsync(bool includeDeleted, CancellationToken cancellationToken);

	/// <summary>
	/// Get an API service
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#get-client-projects
	/// </summary>
	/// <param name="id">The entity ID</param>
	/// <param name="cancellationToken">The cancellation token</param>
	Task<T> GetAsync(long id, CancellationToken cancellationToken);

	/// <summary>
	/// Add an API service
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#create-a-client
	/// </summary>
	/// <param name="obj">The entity to create</param>
	/// <param name="cancellationToken">The cancellation token</param>
	Task<T> CreateAsync(T obj, CancellationToken cancellationToken);

	/// <summary>
	/// Edit an API Service
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#update-a-client
	/// </summary>
	/// <param name="obj">The entity to update</param>
	/// <param name="cancellationToken">The cancellation token</param>
	Task<T> UpdateAsync(T obj, CancellationToken cancellationToken);

	/// <summary>
	/// Delete an API service
	/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#delete-a-client
	/// </summary>
	/// <param name="id">The entity ID</param>
	/// <param name="cancellationToken">The cancellation token</param>
	Task<bool> DeleteAsync(long id, CancellationToken cancellationToken);
}