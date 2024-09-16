using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine.AddressableAssets;
using UnityEngine.Localization;
using Winch.Data.Character;
using Winch.Util;

namespace Winch.Serialization.Character;

public class AdvancedSpeakerDataConverter : DredgeTypeConverter<AdvancedSpeakerData>
{
    internal static readonly string CharacterTableDefinition = LanguageManager.CHARACTER_TABLE;

    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new(string.Empty, null) },
        { "paralinguisticsNameKey", new(ParalinguisticsNameKey.NONE, o=> DredgeTypeHelpers.GetEnumValue<ParalinguisticsNameKey>(o)) },
        { "portraitSprite", new(TextureUtil.GetSprite("EmptyPortrait"), o=> TextureUtil.GetSprite(o.ToString())) },
        { "speakerNameKey", new(null, null) },
        { "yarnRootNode", new(null, null) },
        { "smallPortraitSprite", new(TextureUtil.GetSprite("EmptySmallPortrait"), o=> TextureUtil.GetSprite(o.ToString())) },
        { "isIndoors", new(false, o=> bool.Parse(o.ToString())) },
        { "alwaysAvailable", new(false, o=> bool.Parse(o.ToString())) },
        { "hideNameplate", new(false, o=> bool.Parse(o.ToString())) },
        { "availableInDemo", new(false, null) },
        { "speakerNameKeyOverrides", new(new List<NameKeyOverride>(), o=>DredgeTypeHelpers.ParseNameKeyOverrides((JArray)o)) },
        { "portraitOverrideConditions", new(new List<AdvancedPortraitOverride>(), o=>DredgeTypeHelpers.ParsePortraitOverrides((JArray)o)) },
        { "highlightConditions", new(new List<HighlightCondition>(), o=>DredgeTypeHelpers.ParseHighlightConditions((JArray)o)) },
        { "paralinguistics", new(new Dictionary<ParalinguisticType, List<AssetReference>>(), o=>DredgeTypeHelpers.GetParalinguisticsFromJsonObject(o)) },
        { "paralinguisticOverrideConditions", new(new List<ParalinguisticOverride>(), o=>DredgeTypeHelpers.ParseParalinguisticsOverrides((JArray)o)) },
        { "loopSFX", new(string.Empty, null) },
        { "visitSFX", new(AddressablesUtil.EmptyAssetReference, o=>DredgeTypeHelpers.ParseAudioReference(o.ToString())) },
    };

    public AdvancedSpeakerDataConverter() : base()
    {
        AddDefinitions(_definitions);
    }

    protected static LocalizedString CreateLocalizedString(string value) => CreateLocalizedString(CharacterTableDefinition, value);
}