using System.Collections.Generic;
using System.Net;

namespace Toggl.Api.Requests;

public class ApiRequest
{
	public string? Url { get; set; }
	public List<KeyValuePair<string, string>>? Args { get; set; }
	public CookieContainer? Container { get; set; }
	public string Method { get; set; } = "GET";
	public string? Data { get; set; }
	public string ContentType { get; set; } = "application/json";
	public NetworkCredential? Credential { get; set; }
}