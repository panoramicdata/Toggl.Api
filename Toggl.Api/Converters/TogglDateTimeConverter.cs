using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Toggl.Api.Converters
{
	public class TogglDateTimeConverter : DateTimeConverterBase
	{
		public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
		{
			long ticks;
			if (value is DateTime time)
			{
				var epoc = new DateTime(1970, 1, 1);
				var delta = time - epoc;
				if (delta.TotalSeconds < 0)
				{
					throw new ArgumentOutOfRangeException("Unix epoch starts January 1st, 1970");
				}

				ticks = (long)delta.TotalSeconds;
			}
			else
			{
				throw new Exception("Expected date object value.");
			}

			writer.WriteValue(ticks);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType != JsonToken.Integer)
			{
				throw new Exception(
					$"Unexpected token parsing date. Expected Integer, got {reader.TokenType}.");
			}

			var readerValue = reader.Value;
			if (readerValue is null)
			{
				throw new FormatException("Reader value is null");
			}

			var ticks = (long)readerValue;
			return new DateTime(1970, 1, 1).AddSeconds(ticks);
		}
	}
}
