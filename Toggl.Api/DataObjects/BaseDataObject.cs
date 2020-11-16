using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Linq;
using Toggl.Api.Extensions;

namespace Toggl.Api.DataObjects
{
	public class BaseDataObject
	{
		public List<KeyValuePair<string, string>> ToKeyValuePair()
		{
			var lst = new List<KeyValuePair<string, string>>();

			GetType().GetProperties().ToList()
				.ForEach(p =>
				{
					var val = p.GetValue(this, null);

					if (p.GetCustomAttributes(typeof(JsonPropertyAttribute), false).Single() is not JsonPropertyAttribute jsonProperty || val == null)
					{
						return;
					}

					if (val is IEnumerable<int> ints)
					{
						var param = string.Join(",", ints);
						var pair = new KeyValuePair<string, string>(jsonProperty.PropertyName, param);
						lst.Add(pair);
					}
					else
					{
						var pair = new KeyValuePair<string, string>(jsonProperty.PropertyName, val.ToString());
						lst.Add(pair);
					}
				});

			return lst;
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
}