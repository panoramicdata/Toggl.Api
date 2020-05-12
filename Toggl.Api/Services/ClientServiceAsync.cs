using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Toggl.Api.DataObjects;
using Toggl.Api.Interfaces;
using Toggl.Api.Routes;
using Task = System.Threading.Tasks.Task;

namespace Toggl.Api.Services
{
	public class ClientServiceAsync : IClientServiceAsync
	{
		private static Dictionary<int, Client> _cachedClients;

		private async Task EnsureCacheLoaded()
		{
			if (_cachedClients == null)
				await List().ConfigureAwait(false);
		}

		public IApiServiceAsync TogglSrv { get; set; }

		public ClientServiceAsync(string apiKey)
			: this(new ApiServiceAsync(apiKey))
		{
		}

		public ClientServiceAsync(IApiServiceAsync srv)
		{
			TogglSrv = srv;
		}

		/// <summary>
		///
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#get-clients-visible-to-user
		/// </summary>
		public async Task<List<Client>> List(bool includeDeleted = false)
		{
			var response = await TogglSrv.Get(ApiRoutes.Client.ClientsUrl).ConfigureAwait(false);
			var result = response.GetData<List<Client>>();

			_cachedClients = result.ToDictionary(client => client.Id.Value, client => client);

			return includeDeleted
				? result
				: result.Where(client => client.DeletedAt == null).ToList();
		}

		public async Task<Client> Get(int id)
		{
			if (_cachedClients?.ContainsKey(id) == true)
				return _cachedClients[id];

			var url = string.Format(ApiRoutes.Client.ClientUrl, id);
			var response = await TogglSrv.Get(url).ConfigureAwait(false);
			var data = response.GetData<Client>();
			return data;
		}

		public async Task<Client> GetByName(string name)
		{
			await EnsureCacheLoaded().ConfigureAwait(false);

			return _cachedClients
				.Values
				.Single(client => client.Name == name && client.DeletedAt == null);
		}

		/// <summary>
		///
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#create-a-client
		/// </summary>
		/// <param name="obj"></param>
		public async Task<Client> Add(Client obj)
		{
			_cachedClients = null;
			var response = await TogglSrv
				.Post(ApiRoutes.Client.ClientsUrl, obj.ToJson())
				.ConfigureAwait(false);
			var data = response.GetData<Client>();
			return data;
		}

		/// <summary>
		///
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#update-a-client
		/// </summary>
		/// <param name="obj"></param>
		public async Task<Client> Edit(Client obj)
		{
			_cachedClients = null;
			var url = string.Format(ApiRoutes.Client.ClientUrl, obj.Id);
			var response = await TogglSrv
				.Put(url, obj.ToJson())
				.ConfigureAwait(false);
			var data = response.GetData<Client>();
			return data;
		}

		/// <summary>
		///
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#delete-a-client
		/// </summary>
		/// <param name="id"></param>
		public async Task<bool> Delete(int id)
		{
			_cachedClients = null;
			var url = string.Format(ApiRoutes.Client.ClientUrl, id);
			var res = await TogglSrv
				.Delete(url)
				.ConfigureAwait(false);
			return res.StatusCode == HttpStatusCode.OK;
		}

		public async Task<bool> DeleteIfAny(int[] ids)
		{
			if (ids.Length == 0 || ids == null)
				return true;

			return await Delete(ids).ConfigureAwait(false);
		}

		public async Task<bool> Delete(int[] ids)
		{
			if (ids.Length == 0 || ids == null)
				throw new ArgumentNullException(nameof(ids));

			_cachedClients = null;

			var result = new Dictionary<int, bool>(ids.Length);
			foreach (var id in ids)
			{
				result.Add(id, await Delete(id).ConfigureAwait(false));
			}

			return !result.ContainsValue(false);
		}
	}
}