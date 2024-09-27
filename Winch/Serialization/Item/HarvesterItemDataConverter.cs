using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Winch.Serialization.Item;

public class HarvesterItemDataConverter : SpatialItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemType", new(ItemType.EQUIPMENT, null) },
        { "harvestableTypes", new(new HarvestableType[]{}, o => DredgeTypeHelpers.ParseHarvestableTypes((JArray)o)) },
        { "aberrationBonus", new(0f, o => float.Parse(o.ToString())) },
        { "showAlertOnDiscardHold", new(true, null) },
        { "discardHoldTimeOverride", new(true, null) },
        { "discardHoldTimeSec", new(2, null) }
    };

    public HarvesterItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}