using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Winch.Core;
using Winch.Util;
using Yarn.Compiler;

namespace Winch.Serialization
{
    /// <summary>
    /// Special converter for <see cref="SerializedCrabPotPOIData"/> because they need to be uninitialized
    /// </summary>
    public class SerializedCrabPotPOIConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SerializedCrabPotPOIData);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            if (reader.TokenType != JsonToken.StartObject)
                throw new JsonException("Expected start of JSON object");

            var data = (SerializedCrabPotPOIData)FormatterServices.GetUninitializedObject(typeof(SerializedCrabPotPOIData));
            var meta = JObject.Load(reader);
            try
            {
                data.deployableItemId = meta.GetValueOrDefault("deployableItemId", string.Empty)?.ToString();
                data.x = meta["x"]?.Value<float>() ?? 0;
                data.z = meta["z"]?.Value<float>() ?? 0;
                data.durability = meta["durability"]?.Value<float>() ?? 0;
                data.timeUntilNextCatchRoll = meta["timeUntilNextCatchRoll"]?.Value<float>() ?? 0;
                data.lastUpdate = meta["lastUpdate"]?.Value<float>() ?? 0;
                data.grid = meta["grid"]?.ToObject<SerializableGrid>(serializer) ?? new SerializableGrid();
                data.hadDurabilityRemaining = meta["hadDurabilityRemaining"]?.Value<bool>() ?? false;
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error(ex);
            }
            return data;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value != null && value is SerializedCrabPotPOIData data)
            {
                writer.WriteStartObject();
                writer.WritePropertyName(nameof(data.x));
                serializer.Serialize(writer, data.x);
                writer.WritePropertyName(nameof(data.z));
                serializer.Serialize(writer, data.z);
                writer.WritePropertyName(nameof(data.deployableItemId));
                serializer.Serialize(writer, data.deployableItemId);
                writer.WritePropertyName(nameof(data.durability));
                serializer.Serialize(writer, data.durability);
                writer.WritePropertyName(nameof(data.timeUntilNextCatchRoll));
                serializer.Serialize(writer, data.timeUntilNextCatchRoll);
                writer.WritePropertyName(nameof(data.lastUpdate));
                serializer.Serialize(writer, data.lastUpdate);
                writer.WritePropertyName(nameof(data.grid));
                serializer.Serialize(writer, data.grid);
                writer.WritePropertyName(nameof(data.hadDurabilityRemaining));
                serializer.Serialize(writer, data.hadDurabilityRemaining);
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteNull();
            }
        }
    }
}
