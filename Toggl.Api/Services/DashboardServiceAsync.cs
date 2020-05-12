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
	public class DashboardServiceAsync : IServiceAsync<Dashboard>
	{
		private static Dictionary<int, Dashboard> _cache;

		private async Task EnsureCacheLoaded()
		{
			if (_cache == null)
				await List().ConfigureAwait(false);
		}

		public IApiServiceAsync TogglSrv { get; set; }

		public DashboardServiceAsync(string apiKey)
			: this(new ApiServiceAsync(apiKey))
		{
		}

		public DashboardServiceAsync(IApiServiceAsync srv)
		{
			TogglSrv = srv;
		}

		/// <summary>
		/// List dashboards
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#get-clients-visible-to-user
		/// </summary>
		public async Task<List<Dashboard>> List(bool includeDeleted = false)
		{
			var response = await TogglSrv.Get(ApiRoutes.Client.ClientsUrl).ConfigureAwait(false);
			var result = response.GetData<List<Dashboard>>();

			return result.ToList();
		}

		public async Task<Dashboard> Get(int id)
		{
			if (_cache?.ContainsKey(id) == true)
				return _cache[id];

			var url = string.Format(ApiRoutes.Client.ClientUrl, id);
			var response = await TogglSrv.Get(url).ConfigureAwait(false);
			var data = response.GetData<Dashboard>();
			return data;
		}

		public Task<Dashboard> Add(Dashboard obj) => throw new NotImplementedException();

		public Task<Dashboard> Edit(Dashboard obj) => throw new NotImplementedException();

		/// <summary>
		/// Gets a dashboard by name
		/// </summary>
		/// <param name="name"></param>
		public async Task<Dashboard> GetByName(string name)
		{
			await EnsureCacheLoaded().ConfigureAwait(false);

			throw new NotImplementedException();
		}

		/// <summary>
		/// Add a dashboard
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#create-a-client
		/// </summary>
		/// <param name="obj"></param>
		public async Task<Dashboard> Add(Client obj)
		{
			_cache = null;
			var response = await TogglSrv.Post(ApiRoutes.Client.ClientsUrl, obj.ToJson()).ConfigureAwait(false);
			var data = response.GetData<Dashboard>();
			return data;
		}

		/// <summary>
		/// Edit a dashboard
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#update-a-client
		/// </summary>
		/// <param name="obj"></param>
		public async Task<Dashboard> Edit(Client obj)
		{
			_cache = null;
			var url = string.Format(ApiRoutes.Client.ClientUrl, obj.Id);
			var response = await TogglSrv.Put(url, obj.ToJson()).ConfigureAwait(false);
			var data = response.GetData<Dashboard>();
			return data;
		}

		/// <summary>
		/// Delete a dashboard
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#delete-a-client
		/// </summary>
		/// <param name="id"></param>
		public async Task<bool> Delete(int id)
		{
			_cache = null;
			var url = string.Format(ApiRoutes.Client.ClientUrl, id);
			var res = await TogglSrv.Delete(url).ConfigureAwait(false);
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

			_cache = null;

			var result = new Dictionary<int, bool>(ids.Length);
			foreach (var id in ids)
			{
				result.Add(id, await Delete(id).ConfigureAwait(false));
			}

			return !result.ContainsValue(false);
		}
	}
}