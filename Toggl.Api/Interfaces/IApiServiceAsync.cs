using System.Collections.Generic;
using System.Threading.Tasks;
using Toggl.Api.DataObjects;
using Toggl.Api.Responses;
using Task = System.Threading.Tasks.Task;

namespace Toggl.Api.Interfaces
{
	public interface IApiServiceAsync
	{

		Task<Session> GetSession();
		Task<ApiResponse> Get(string url);
		Task<ApiResponse> Get(string url, List<KeyValuePair<string, string>> args);
		Task<TResponse> Get<TResponse>(string url, List<KeyValuePair<string, string>> args);
		Task<ApiResponse> Delete(string url);
		Task<ApiResponse> Delete(string url, List<KeyValuePair<string, string>> args);
		Task<ApiResponse> Post(string url, string data);
		Task<ApiResponse> Post(string url, List<KeyValuePair<string, string>> args, string data);
		Task<ApiResponse> Put(string url, string data);
		Task<ApiResponse> Put(string url, List<KeyValuePair<string, string>> args, string data);
		Task Initialize();

	}
}