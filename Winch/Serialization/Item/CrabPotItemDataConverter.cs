using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Winch.Util;

namespace Winch.Serialization.Item;

public class CrabPotItemDataConverter : DeployableItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemTypeIcon", new(TextureUtil.GetSprite("CrabPotIcon"), null) },
        { "itemSubtype", new(ItemSubtype.POT, null) },
        { "harvestableTypes", new(new HarvestableType[1]{HarvestableType.CRAB}, null) },
    };

    public CrabPotItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}