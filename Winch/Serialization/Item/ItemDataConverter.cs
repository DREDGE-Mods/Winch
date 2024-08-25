using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using Winch.Util;

namespace Winch.Serialization.Item;

public class ItemDataConverter : DredgeTypeConverter<ItemData>
{
    internal const string ItemTableDefinition = "Items";

    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new( Guid.NewGuid().ToString(), null) },
        { "itemNameKey", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "itemDescriptionKey", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "itemInsaneTitleKey", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "itemInsaneDescriptionKey", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "hasAdditionalNote", new(false, o=> bool.Parse(o.ToString())) },
        { "additionalNoteKey", new (LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "dialogueNodeSpecificDescription", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "itemType", new(ItemType.GENERAL, o => DredgeTypeHelpers.GetEnumValue<ItemType>(o)) },
        { "itemSubtype", new(ItemSubtype.GENERAL, o => DredgeTypeHelpers.GetEnumValue<ItemSubtype>(o)) },
        { "tooltipTextColor", new(new Color(0.4902f, 0.3843f, 0.2667f, 255f), o => DredgeTypeHelpers.GetColorFromJsonObject(o)) },
        { "tooltipNotesColor", new(Color.white, o => DredgeTypeHelpers.GetColorFromJsonObject(o)) },
        { "itemTypeIcon", new(TextureUtil.GetSprite("EmptyIcon"), o => TextureUtil.GetSprite(o.ToString())) },
        { "harvestParticlePrefab", new(null, null) },
        { "overrideHarvestParticleDepth", new(false, o=> bool.Parse(o.ToString())) },
        { "harvestParticleDepthOffset", new(-3f, o=> float.Parse(o.ToString())) },
        { "flattenParticleShape", new(false, o=> bool.Parse(o.ToString())) },
        { "availableInDemo", new(false, null) },
        { "linkedDialogueNode", new("", null) },
        { "entitlementsRequired ", new(new List<Entitlement>(), o=>DredgeTypeHelpers.GetEnumValues<Entitlement>(o)) },
    };

    private readonly Dictionary<string, string> _reroutes = new()
    {
        { "itemInsaneTitleKey", "itemNameKey" }, { "itemInsaneDescriptionKey", "itemDescriptionKey" }
    };

    public ItemDataConverter()
    {
        AddDefinitions(_definitions);
        AddReroutes(_reroutes);
    }

    protected static LocalizedString CreateLocalizedString(string value) => CreateLocalizedString(ItemTableDefinition, value);
}
