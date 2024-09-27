using System.Collections.Generic;
using UnityEngine;
using Winch.Util;

namespace Winch.Serialization.Item;

public class FlagItemDataConverter : HarvestableItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemTypeIcon", new(TextureUtil.GetSprite("TrinketIcon"), null) },
        { "sprite", new(TextureUtil.GetSprite("FlagItemTemplate"), null) },
        { "itemType", new(ItemType.GENERAL, null) },
        { "itemSubtype", new(ItemSubtype.GENERAL, null) },
        { "canBeDiscardedByPlayer", new(true, null) },
        { "canBeDiscardedDuringQuestPickup", new(true, null) },
        { "canBeSoldByPlayer", new(false, null) },
        { "canBeSoldInBulkAction", new(false, null) },
        { "itemColor", new(new Color(0.2275f, 0.1569f, 0.1255f, 1f), null)},
        { "damageMode", new(DamageMode.DESTROY, null) },
        { "harvestMinigameType", new( HarvestMinigameType.DREDGE_RADIAL, null) },
        { "harvestPOICategory", new(HarvestPOICategory.TRINKET, null) },
        { "harvestableType", new(HarvestableType.DREDGE, null) },
        { "harvestDifficulty", new(HarvestDifficulty.MEDIUM, null) },
        { "minDepth", new(DepthEnum.VERY_SHALLOW, null) },
        { "maxDepth", new(DepthEnum.VERY_SHALLOW, null) },
        { "showAlertOnDiscardHold", new(true, null) },
        { "discardHoldTimeOverride", new(true, null) },
        { "discardHoldTimeSec", new(2, null) },
        { "canBeCaughtByRod", new(false, null) },
        { "regenHarvestSpotOnDestroy", new(true, null) },
        { "squishFactor", new(0.25f, null) },
        { "value", new(decimal.Zero, null) },
        { "perSpotMin", new(1, null) },
        { "perSpotMax", new(1, null) }
    };
    
    public FlagItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}
