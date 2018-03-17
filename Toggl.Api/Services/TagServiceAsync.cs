using System;
using System.Collections.Generic;
using Toggl.Api.DataObjects;
using Toggl.Api.Interfaces;

namespace Toggl.Api.Services
{
	public class TagServiceAsync : ITagServiceAsync
	{
		private IApiServiceAsync ToggleSrv { get; set; }


		public TagServiceAsync(string apiKey)
			: this(new ApiServiceAsync(apiKey))
		{

		}

		public TagServiceAsync(IApiServiceAsync srv)
		{
			ToggleSrv = srv;
		}


		/// <summary>
		/// 
		/// https://github.com/toggl/toggl_api_docs/blob/master/chapters/tasks.md
		/// </summary>
		/// <returns></returns>
		public async System.Threading.Tasks.Task<List<Client>> List()
		{
			throw new NotImplementedException();
		}
	}
}