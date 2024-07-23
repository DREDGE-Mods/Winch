using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using Winch.Core;
using Winch.Data.Character;
using Winch.Util;

namespace Winch.Serialization.Character;

public class AdvancedSpeakerDataConverter : SpeakerDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new(null, null) },
        { "paralinguisticsNameKey", new(ParalinguisticsNameKey.NONE, o=> DredgeTypeHelpers.GetEnumValue<ParalinguisticsNameKey>(o)) },
        { "portraitSprite", new(TextureUtil.GetSprite("EmptyPortrait"), o=> TextureUtil.GetSprite(o.ToString())) },
    };

    public AdvancedSpeakerDataConverter() : base()
    {
        AddDefinitions(_definitions);
    }
}