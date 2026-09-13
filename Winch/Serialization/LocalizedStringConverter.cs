using System;
using Newtonsoft.Json;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using Winch.Util;

namespace Winch.Serialization;

public sealed class LocalizedStringConverter : JsonConverter<LocalizedString>
{
    public override void WriteJson(
        JsonWriter writer,
        LocalizedString? value,
        JsonSerializer serializer)
    {
        if (value == null || value.IsEmpty)
        {
            writer.WriteNull();
            return;
        }

        writer.WriteValue(
            LocalizationUtil.SerializeReference(value)
        );
    }

    public override LocalizedString ReadJson(
        JsonReader reader,
        Type objectType,
        LocalizedString? existingValue,
        bool hasExistingValue,
        JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
            return null;

        var reference = reader.Value?.ToString();

        return string.IsNullOrWhiteSpace(reference)
            ? null
            : LocalizationUtil.CreateReference(reference);
    }
}