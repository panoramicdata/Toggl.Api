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
				await List();
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
		/// 
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#get-clients-visible-to-user
		/// </summary>
		/// <returns></returns>
		public async Task<List<Dashboard>> List(bool includeDeleted = false)
		{
			var response = await TogglSrv.Get(ApiRoutes.Client.ClientsUrl);
			var result = response.GetData<List<Dashboard>>();

			return result.ToList();
		}

		public async Task<Dashboard> Get(int id)
		{
			if (_cache != null && _cache.ContainsKey(id))
				return _cache[id];

			var url = string.Format(ApiRoutes.Client.ClientUrl, id);
			var response = await TogglSrv.Get(url);
			var data = response.GetData<Dashboard>();
			return data;

		}

		public Task<Dashboard> Add(Dashboard obj)
		{
			throw new NotImplementedException();
		}

		public Task<Dashboard> Edit(Dashboard obj)
		{
			throw new NotImplementedException();
		}

		public async Task<Dashboard> GetByName(string name)
		{
			await EnsureCacheLoaded();

			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#create-a-client
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public async Task<Dashboard> Add(Client obj)
		{
			_cache = null;
			var url = ApiRoutes.Client.ClientsUrl;
			var response = await TogglSrv.Post(url, obj.ToJson());
			var data = response.GetData<Dashboard>();
			return data;

		}

		/// <summary>
		/// 
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#update-a-client
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public async Task<Dashboard> Edit(Client obj)
		{
			_cache = null;
			var url = string.Format(ApiRoutes.Client.ClientUrl, obj.Id);
			var response = await TogglSrv.Put(url, obj.ToJson());
			var data = response.GetData<Dashboard>();
			return data;
		}

		/// <summary>
		/// 
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#delete-a-client
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<bool> Delete(int id)
		{
			_cache = null;
			var url = string.Format(ApiRoutes.Client.ClientUrl, id);
			var res = await TogglSrv.Delete(url);
			return res.StatusCode == HttpStatusCode.OK;
		}

		public async Task<bool> DeleteIfAny(int[] ids)
		{
			if (!ids.Any() || ids == null)
				return true;

			return await Delete(ids);
		}

		public async Task<bool> Delete(int[] ids)
		{
			if (!ids.Any() || ids == null)
				throw new ArgumentNullException("ids");

			_cache = null;

			var result = new Dictionary<int, bool>(ids.Length);
			foreach (var id in ids)
			{
				result.Add(id, await Delete(id));
			}

			return !result.ContainsValue(false);
		}
	}
}