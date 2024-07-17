using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;
using Winch.Core;
using Winch.Util;

namespace Winch.Serialization.Character;

public class SpeakerDataConverter : DredgeTypeConverter<AdvancedSpeakerData>
{
    internal const string CharacterTableDefinition = "Characters";

    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "speakerNameKey", new(null, null) },
        { "yarnRootNode", new(null, null) },
        { "smallPortraitSprite", new(TextureUtil.GetSprite("EmptySmallPortrait"), o=> TextureUtil.GetSprite(o.ToString())) },
        { "isIndoors", new(false, o=> bool.Parse(o.ToString())) },
        { "alwaysAvailable", new(false, o=> bool.Parse(o.ToString())) },
        { "hideNameplate", new(false, o=> bool.Parse(o.ToString())) },
        { "availableInDemo", new(false, null) },
        { "speakerNameKeyOverrides", new(new List<NameKeyOverride>(), null) },
        { "portraitOverrideConditions", new(new List<PortraitOverride>(), null) },
        { "highlightConditions", new(new List<HighlightCondition>(), null) },
        { "paralinguisticOverrideConditions", new(new List<ParalinguisticOverride>(), null) }
    };

    public SpeakerDataConverter()
    {
        AddDefinitions(_definitions);
    }

    protected static LocalizedString CreateLocalizedString(string value) => CreateLocalizedString(CharacterTableDefinition, value);
}