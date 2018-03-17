using System.Collections.Generic;
using System.Threading.Tasks;
using Toggl.Api.DataObjects;
using Toggl.Api.Interfaces;

namespace Toggl.Api.Services
{
	public class TagServiceAsync : ITagServiceAsync
	{
		private IApiServiceAsync TogglSrv { get; }

		public TagServiceAsync(string apiKey)
			: this(new ApiServiceAsync(apiKey))
		{

		}

		public TagServiceAsync(IApiServiceAsync srv)
		{
			TogglSrv = srv;
		}

		public Task<List<Tag>> List()
		{
			throw new System.NotImplementedException();
		}
	}
}