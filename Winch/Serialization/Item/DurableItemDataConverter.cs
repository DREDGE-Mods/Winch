using System.Collections.Generic;

namespace Winch.Serialization.Item;

public class DurableItemDataConverter : SpatialItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "damageMode", new(DamageMode.DESTROY, null) },
        { "displayDurabilityAsPercentage", new(true, o => bool.Parse(o.ToString())) },
        { "maxDurabilityDays", new(1f, o => float.Parse(o.ToString())) },
        { "canBeDiscardedByPlayer", new(true, null) },
        { "canBeSoldInBulkAction", new(false, null) },
    };

    public DurableItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}