using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Linq;
using Toggl.Api.Extensions;

namespace Toggl.Api.DataObjects;

public class BaseDataObject
{
	public List<KeyValuePair<string, string>> ToKeyValuePair()
	{
		var list = new List<KeyValuePair<string, string>>();

		GetType().GetProperties().ToList().ForEach(propertyInfo =>
		{
			var val = propertyInfo.GetValue(this, null);

			if (propertyInfo.GetCustomAttributes(typeof(JsonPropertyAttribute), false).Single() is not JsonPropertyAttribute jsonProperty || val == null || jsonProperty.PropertyName is null)
			{
				return;
			}

			if (val is IEnumerable<int> ints)
			{
				var param = string.Join(",", ints);
				var pair = new KeyValuePair<string, string>(jsonProperty.PropertyName, param);
				list.Add(pair);
			}
			else if (val is IEnumerable<long> longs)
			{
				var param = string.Join(",", longs);
				var pair = new KeyValuePair<string, string>(jsonProperty.PropertyName, param);
				list.Add(pair);
			}
			else
			{
				var pair = new KeyValuePair<string, string>(jsonProperty.PropertyName, val.ToString());
				list.Add(pair);
			}
		});

		return list;
	}

	public string ToJson(string objName = "")
	{
		var cverts = new List<JsonConverter>
		{
			new IsoDateTimeConverter()
		};
		var data = JsonConvert.SerializeObject(this,
			Formatting.None,
			new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore,
				Converters = cverts
			}

		);
		var propNm = string.IsNullOrEmpty(objName) ? GetType().Name.LowerCaseUnderscore() : objName;

		return "{\"" + propNm + "\":" + data + "}";
	}
}