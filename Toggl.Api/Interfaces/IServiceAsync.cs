using System.Collections.Generic;
using System.Threading.Tasks;

namespace Toggl.Api.Interfaces
{
	public interface IServiceAsync<T>
	{
		IApiServiceAsync TogglSrv { get; set; }

		/// <summary>
		/// List API Services
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#get-clients-visible-to-user
		/// </summary>
		Task<List<T>> GetAllAsync(bool includeDeleted = false);

		/// <summary>
		/// Get an API service
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#get-client-projects
		/// </summary>
		/// <param name="id"></param>
		Task<T> GetAsync(long id);

		/// <summary>
		/// Add an API service
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#create-a-client
		/// </summary>
		/// <param name="obj"></param>
		Task<T> CreateAsync(T obj);

		/// <summary>
		/// Edit an API Service
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#update-a-client
		/// </summary>
		/// <param name="obj"></param>
		Task<T> UpdateAsync(T obj);

		/// <summary>
		/// Delete an API service
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#delete-a-client
		/// </summary>
		/// <param name="id"></param>
		Task<bool> DeleteAsync(int id);
	}
}