using System.Collections.Generic;
using Winch.Util;

namespace Winch.Serialization.Item;
public class RodItemDataConverter : HarvesterItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemTypeIcon", new( TextureUtil.GetSprite("RodIcon"), null) },
        { "damageMode", new(DamageMode.OPERATION, null) },
        { "moveMode", new(MoveMode.INSTALL, null) },
        { "canBeDiscardedByPlayer", new(true, null) },
        { "canBeSoldInBulkAction", new(false, null) },
        { "itemSubtype", new(ItemSubtype.ROD, null) },
        { "fishingSpeedModifier", new(1f, o => float.Parse(o.ToString())) },
        { "aberrationCatchBonus", new(0f, o => float.Parse(o.ToString())) }
    };

    public RodItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}
