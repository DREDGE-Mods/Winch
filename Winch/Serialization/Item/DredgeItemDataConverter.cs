using System.Collections.Generic;
using Winch.Util;

namespace Winch.Serialization.Item;

public class DredgeItemDataConverter : HarvesterItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemTypeIcon", new(TextureUtil.GetSprite("DredgeIcon"), null) },
        { "itemSubtype", new(ItemSubtype.DREDGE, null) },
        { "harvestableTypes", new(new HarvestableType[1]{HarvestableType.DREDGE}, null) },
    };

    public DredgeItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}