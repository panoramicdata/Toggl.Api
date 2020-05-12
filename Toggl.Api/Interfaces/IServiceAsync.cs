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
		Task<List<T>> List(bool includeDeleted = false);

		/// <summary>
		/// Get an API service
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#get-client-projects
		/// </summary>
		/// <param name="id"></param>
		Task<T> Get(int id);

		/// <summary>
		/// Add an API service
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#create-a-client
		/// </summary>
		/// <param name="obj"></param>
		Task<T> Add(T obj);

		/// <summary>
		/// Edit an API Service
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#update-a-client
		/// </summary>
		/// <param name="obj"></param>
		Task<T> Edit(T obj);

		/// <summary>
		/// Delete an API service
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#delete-a-client
		/// </summary>
		/// <param name="id"></param>
		Task<bool> Delete(int id);
	}
}