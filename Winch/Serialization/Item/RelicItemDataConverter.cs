using System.Collections.Generic;
using UnityEngine;
using Winch.Util;

namespace Winch.Serialization.Item;

public class RelicItemDataConverter : HarvestableItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemTypeIcon", new(TextureUtil.GetSprite("QuestIcon"), null) },
        { "itemType", new(ItemType.GENERAL, null) },
        { "itemSubtype", new(ItemSubtype.RELIC, null) },
        { "canBeDiscarded", new(true, null) },
        { "canBeDiscardedByPlayer", new(false, null) },
        { "canBeSoldByPlayer", new(false, null) },
        { "canBeSoldInBulkAction", new(true, null) },
        { "harvestPOICategory", new(HarvestPOICategory.RELIC, null) },
        { "harvestableType", new(HarvestableType.DREDGE, null) },
        { "itemColor", new(new Color(0.5294f, 0.1137f, 0.3451f, 1f), null)},
        { "tooltipTextColor", new(new Color(0.5294f, 0.1137f, 0.3451f, 1f), null)},
        { "showAlertOnDiscardHold", new(true, null) },
        { "discardHoldTimeOverride", new(true, null) },
        { "discardHoldTimeSec", new(2, null) },
        { "canBeCaughtByRod", new(false, null) },
        { "regenHarvestSpotOnDestroy", new(true, null) },
        { "squishFactor", new(0, null) },
        { "value", new(decimal.Zero, null) },
        { "perSpotMin", new(1, null) },
        { "perSpotMax", new(1, null) }
    };
    public RelicItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}