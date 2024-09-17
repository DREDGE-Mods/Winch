using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

internal class DynamicConverter : JsonConverter
{
	private List<JsonConverter> _converters = new List<JsonConverter>();

	public void AddConverter(JsonConverter converter)
	{
		_converters.Add(converter);
	}

	public IEnumerable<JsonConverter> ConvertersForType(Type objectType)
	{
		return _converters.Where(converter => converter.CanConvert(objectType));
	}

	public override bool CanConvert(Type objectType)
	{
		return ConvertersForType(objectType).Any();
	}

	public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
	{
		foreach (var property in ConvertersForType(objectType))
		{
			return property.ReadJson(reader, objectType, existingValue, serializer);
		}

		return null;
	}

	public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
	{
		foreach (var property in ConvertersForType(value.GetType()))
		{
			property.WriteJson(writer, value, serializer);
			return;
		}

		writer.WriteNull();
	}
}