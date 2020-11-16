using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Toggl.Api.DataObjects;
using Toggl.Api.Interfaces;

namespace Toggl.Api.Services
{
	public class TagServiceAsync : ITagServiceAsync
	{
		private readonly IApiServiceAsync _apiServiceAsync;

		public TagServiceAsync(string apiKey)
			: this(new ApiServiceAsync(apiKey))
		{
		}

		public TagServiceAsync(IApiServiceAsync apiServiceAsync)
		{
			_apiServiceAsync = apiServiceAsync;
		}

		public Task<List<Tag>> GetAllAsync()
			=> throw new NotImplementedException();
	}
}