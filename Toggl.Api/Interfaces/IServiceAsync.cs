using System.Collections.Generic;
using System.Threading.Tasks;

namespace Toggl.Api.Interfaces
{
	public interface IServiceAsync<T>
	{	
		IApiServiceAsync TogglSrv { get; set; }

		/// <summary>
		/// 
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#get-clients-visible-to-user
		/// </summary>
		/// <returns></returns>
		Task<List<T>> List(bool includeDeleted = false);

		/// <summary>
		/// 
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#get-client-projects
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<T> Get(int id);

		/// <summary>
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#create-a-client
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		Task<T> Add(T obj);

		/// <summary>
		/// 
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#update-a-client
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		Task<T> Edit(T obj);

		/// <summary>
		/// 
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#delete-a-client
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<bool> Delete(int id);
	}
}