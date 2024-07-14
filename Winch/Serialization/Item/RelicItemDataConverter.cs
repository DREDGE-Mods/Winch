using System.Collections.Generic;
using UnityEngine;

namespace Winch.Serialization.Item;

public class RelicItemDataConverter : HarvestableItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemType", new(ItemType.GENERAL, null) },
        { "itemSubtype", new(ItemSubtype.RELIC, null) },
        { "canBeDiscardedByPlayer", new(false, null) },
        { "harvestPOICategory", new(HarvestPOICategory.RELIC, null) },
        { "harvestableType", new(HarvestableType.DREDGE, null) },
        { "itemColor", new(new Color(0.5294f, 0.1137f, 0.3451f, 255f), null)},
        { "showAlertOnDiscardHold", new(true, null) },
        { "discardHoldTimeOverride", new(true, null) },
        { "discardHoldTimeSec", new(2, null) }
    };
    public RelicItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}