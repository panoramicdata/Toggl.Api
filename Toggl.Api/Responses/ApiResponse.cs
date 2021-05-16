using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using Toggl.Api.Exceptions;

namespace Toggl.Api.Responses
{
	public class ApiResponse
	{
		[JsonProperty(PropertyName = "data")]
		public object? Data { get; set; }

		[JsonProperty(PropertyName = "related_data_updated_at")]
		[JsonConverter(typeof(IsoDateTimeConverter))]
		public DateTime RelatedDataUpdatedAt { get; set; }

		public HttpStatusCode StatusCode { get; set; }

		public string Method { get; set; } = string.Empty;

		public T GetData<T>()
		{
			var cverts = new List<JsonConverter>();
			var iso = new IsoDateTimeConverter();
			cverts.Add(iso);

			if (Method == "DELETE" && StatusCode.Equals(HttpStatusCode.OK))
			{
				return (T)Activator.CreateInstance(typeof(T));
			}
			else if (Data != null)
			{
				if (Data is JArray jArray)
				{
					T t = jArray.ToObject<T>() ?? (T)Activator.CreateInstance(typeof(T));
					return t;
				}
				if (Data is JToken jToken)
				{
					return jToken.ToObject<T>()
						?? throw new TogglApiException("Could not create data object from JToken");
				}
				else
				{
					var json = JsonConvert.SerializeObject(Data, cverts.ToArray());
					return JsonConvert.DeserializeObject<T>(json, cverts.ToArray())
						?? throw new TogglApiException("Could not create data object");
				}
			}
			else
			{
				return (T)Activator.CreateInstance(typeof(T));
			}
		}
	}
}