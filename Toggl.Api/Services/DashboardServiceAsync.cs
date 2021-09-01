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
		private static Dictionary<long, Dashboard>? _cache;

		private async Task EnsureCacheLoaded()
		{
			if (_cache is not null)
			{
				return;
			}
			await GetAllAsync().ConfigureAwait(false);
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
		public async Task<List<Dashboard>> GetAllAsync(bool includeDeleted = false)
		{
			var response = await TogglSrv.GetAsync(ApiRoutes.Client.ClientsUrl).ConfigureAwait(false);
			var result = response.GetData<List<Dashboard>>();

			return result.ToList();
		}

		public async Task<Dashboard> GetAsync(long id)
		{
			if (_cache?.ContainsKey(id) == true)
				return _cache[id];

			var url = string.Format(ApiRoutes.Client.ClientUrl, id);
			var response = await TogglSrv.GetAsync(url).ConfigureAwait(false);
			var data = response.GetData<Dashboard>();
			return data;
		}

		public Task<Dashboard> CreateAsync(Dashboard obj)
			=> throw new NotSupportedException();

		public Task<Dashboard> UpdateAsync(Dashboard obj)
			=> throw new NotSupportedException();

		/// <summary>
		/// Gets a dashboard by name
		/// </summary>
		/// <param name="name"></param>
		public async Task<Dashboard?> GetByNameAsync(string name)
		{
			await EnsureCacheLoaded()
				.ConfigureAwait(false);

			throw new NotSupportedException($"Fetching dashboard by name e.g. '{name}' is not supported.");
		}

		/// <summary>
		/// Add a dashboard
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#create-a-client
		/// </summary>
		/// <param name="obj"></param>
		public async Task<Dashboard> CreateAsync(Client obj)
		{
			_cache = null;
			var response = await TogglSrv
				.PostAsync(ApiRoutes.Client.ClientsUrl, obj.ToJson())
				.ConfigureAwait(false);
			var data = response.GetData<Dashboard>();
			return data;
		}

		/// <summary>
		/// Edit a dashboard
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#update-a-client
		/// </summary>
		/// <param name="obj"></param>
		public async Task<Dashboard> UpdateAsync(Client obj)
		{
			_cache = null;
			var url = string.Format(ApiRoutes.Client.ClientUrl, obj.Id);
			var response = await TogglSrv.PutAsync(url, obj.ToJson()).ConfigureAwait(false);
			var data = response.GetData<Dashboard>();
			return data;
		}

		/// <summary>
		/// Delete a dashboard
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/clients.md#delete-a-client
		/// </summary>
		/// <param name="id"></param>
		public async Task<bool> DeleteAsync(int id)
		{
			_cache = null;
			var url = string.Format(ApiRoutes.Client.ClientUrl, id);
			var res = await TogglSrv.DeleteAsync(url).ConfigureAwait(false);
			return res.StatusCode == HttpStatusCode.OK;
		}

		public async Task<bool> DeleteIfAnyAsync(int[] ids)
		{
			if (ids.Length == 0 || ids == null)
				return true;

			return await DeleteAsync(ids).ConfigureAwait(false);
		}

		public async Task<bool> DeleteAsync(int[] ids)
		{
			if (ids.Length == 0 || ids == null)
				throw new ArgumentNullException(nameof(ids));

			_cache = null;

			var result = new Dictionary<int, bool>(ids.Length);
			foreach (var id in ids)
			{
				result.Add(id, await DeleteAsync(id).ConfigureAwait(false));
			}

			return !result.ContainsValue(false);
		}
	}
}