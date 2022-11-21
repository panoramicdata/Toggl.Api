using System.Collections.Generic;
using Toggl.Api.DataObjects;
using Toggl.Api.Responses;

namespace Toggl.Api.Interfaces;

public interface ITogglService
{
	Session GetSession();

	ApiResponse Get(string url);

	ApiResponse Get(string url, List<KeyValuePair<string, string>> args);

	ApiResponse Delete(string url);

	ApiResponse Delete(string url, List<KeyValuePair<string, string>> args);

	ApiResponse Post(string url, string data);

	ApiResponse Post(string url, List<KeyValuePair<string, string>> args, string data);

	ApiResponse Put(string url, string data);

	ApiResponse Put(string url, List<KeyValuePair<string, string>> args, string data);

	void Initialize();
}