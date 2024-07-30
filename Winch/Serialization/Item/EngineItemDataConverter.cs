using System.Collections.Generic;
using Winch.Util;

namespace Winch.Serialization.Item;

public class EngineItemDataConverter : SpatialItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemTypeIcon", new(TextureUtil.GetSprite("EngineIcon"), null) },
        { "damageMode", new(DamageMode.OPERATION, null) },
        { "moveMode", new(MoveMode.INSTALL, null) },
        { "canBeDiscardedByPlayer", new(true, null) },
        { "canBeSoldInBulkAction", new(false, null) },
        { "itemType", new(ItemType.EQUIPMENT, null) },
        { "itemSubtype", new(ItemSubtype.ENGINE, null) },
        { "speedBonus", new(0f, o => float.Parse(o.ToString())) }
    };

    public EngineItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}