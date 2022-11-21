using System.Collections.Generic;
using System.Threading.Tasks;
using Toggl.Api.DataObjects;
using Toggl.Api.Responses;
using Task = System.Threading.Tasks.Task;

namespace Toggl.Api.Interfaces;

public interface IApiServiceAsync
{
	Task<Session> GetSessionAsync();
	Task<ApiResponse> GetAsync(string url);
	Task<ApiResponse> GetAsync(string url, List<KeyValuePair<string, string>> args);
	Task<TResponse> GetAsync<TResponse>(string url, List<KeyValuePair<string, string>> args);
	Task<ApiResponse> DeleteAsync(string url);
	Task<ApiResponse> DeleteAsync(string url, List<KeyValuePair<string, string>> args);
	Task<ApiResponse> PostAsync(string url, string? data);
	Task<ApiResponse> PostAsync(string url, List<KeyValuePair<string, string>> args, string data);
	Task<ApiResponse> PutAsync(string url, string data);
	Task<ApiResponse> PutAsync(string url, List<KeyValuePair<string, string>> args, string data);
	Task InitializeAsync();
}