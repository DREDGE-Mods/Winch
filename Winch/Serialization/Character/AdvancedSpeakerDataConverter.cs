using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using Winch.Core;
using Winch.Util;

namespace Winch.Serialization.Character;

public class AdvancedSpeakerDataConverter : SpeakerDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new(null, null) },
        { "paralinguisticsNameKey", new(null, null) },
        { "portraitSprite", new(TextureUtil.GetSprite("EmptyPortrait"), o=> TextureUtil.GetSprite(o.ToString())) },
    };

    public AdvancedSpeakerDataConverter() : base()
    {
        AddDefinitions(_definitions);
    }
}