using System.Collections.Generic;
using System.Threading.Tasks;
using Toggl.Api.DataObjects;

namespace Toggl.Api.Interfaces
{
	public interface IClientServiceAsync
	{
		IApiServiceAsync TogglSrv { get; set; }

		/// <summary>
		///
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#get-clients-visible-to-user
		/// </summary>
		/// <returns></returns>
		Task<List<Client>> GetAllAsync(bool includeDeleted = false);

		/// <summary>
		/// Get a client
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#get-client-projects
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Client> GetAsync(long id);

		/// <summary>
		/// Add a client
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#create-a-client
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		Task<Client> CreateAsync(Client obj);

		/// <summary>
		/// Edit a client
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#update-a-client
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		Task<Client> UpdateAsync(Client obj);

		/// <summary>
		/// Delete a client
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#delete-a-client
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<bool> DeleteAsync(int id);
	}
}