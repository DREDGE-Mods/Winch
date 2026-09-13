using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Runtime.Serialization;
using Winch.Core;

namespace Winch.Serialization;

/// <summary>
/// Special converter for <see cref="SerializedCrabPotPOIData"/> because it needs to be created uninitialized.
/// </summary>
public class SerializedCrabPotPOIConverter : JsonConverter<SerializedCrabPotPOIData>
{
    public override SerializedCrabPotPOIData? ReadJson(
        JsonReader reader,
        Type objectType,
        SerializedCrabPotPOIData? existingValue,
        bool hasExistingValue,
        JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
            return null;

        if (reader.TokenType != JsonToken.StartObject)
            throw new JsonException("Expected start of JSON object");

        var data = (SerializedCrabPotPOIData)FormatterServices
            .GetUninitializedObject(typeof(SerializedCrabPotPOIData));

        var meta = JObject.Load(reader);

        try
        {
            data.deployableItemId = meta.GetValueOrDefault(
                nameof(data.deployableItemId),
                string.Empty
            )?.ToString();

            data.x = meta[nameof(data.x)]?.Value<float>() ?? 0;
            data.z = meta[nameof(data.z)]?.Value<float>() ?? 0;
            data.durability = meta[nameof(data.durability)]?.Value<float>() ?? 0;
            data.timeUntilNextCatchRoll = meta[nameof(data.timeUntilNextCatchRoll)]?.Value<float>() ?? 0;
            data.lastUpdate = meta[nameof(data.lastUpdate)]?.Value<float>() ?? 0;
            data.grid = meta[nameof(data.grid)]?.ToObject<SerializableGrid>(serializer) ?? new SerializableGrid();
            data.hadDurabilityRemaining = meta[nameof(data.hadDurabilityRemaining)]?.Value<bool>() ?? false;
        }
        catch (Exception ex)
        {
            WinchCore.Log.Error(ex);
        }

        return data;
    }

    public override void WriteJson(
        JsonWriter writer,
        SerializedCrabPotPOIData? value,
        JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
            return;
        }

        writer.WriteStartObject();

        writer.WritePropertyName(nameof(value.x));
        serializer.Serialize(writer, value.x);

        writer.WritePropertyName(nameof(value.z));
        serializer.Serialize(writer, value.z);

        writer.WritePropertyName(nameof(value.deployableItemId));
        serializer.Serialize(writer, value.deployableItemId);

        writer.WritePropertyName(nameof(value.durability));
        serializer.Serialize(writer, value.durability);

        writer.WritePropertyName(nameof(value.timeUntilNextCatchRoll));
        serializer.Serialize(writer, value.timeUntilNextCatchRoll);

        writer.WritePropertyName(nameof(value.lastUpdate));
        serializer.Serialize(writer, value.lastUpdate);

        writer.WritePropertyName(nameof(value.grid));
        serializer.Serialize(writer, value.grid);

        writer.WritePropertyName(nameof(value.hadDurabilityRemaining));
        serializer.Serialize(writer, value.hadDurabilityRemaining);

        writer.WriteEndObject();
    }
}