using System.Collections.Generic;
using Winch.Util;

namespace Winch.Serialization.Item;

public class LightItemDataConverter : SpatialItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemTypeIcon", new(TextureUtil.GetSprite("LightIcon"), null) },
        { "damageMode", new(DamageMode.OPERATION, null) },
        { "moveMode", new(MoveMode.INSTALL, null) },
        { "canBeDiscardedByPlayer", new(true, null) },
        { "canBeSoldInBulkAction", new(false, null) },
        { "itemType", new(ItemType.EQUIPMENT, null) },
        { "itemSubtype", new(ItemSubtype.LIGHT, null) },
        { "lumens", new(500f, o => float.Parse(o.ToString())) },
        { "range", new(10f, o => float.Parse(o.ToString())) }
    };

    public LightItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}