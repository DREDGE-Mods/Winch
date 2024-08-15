using System.Collections.Generic;
using Winch.Util;

namespace Winch.Serialization.Item;

public class TrawlNetItemDataConverter : DeployableItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemTypeIcon", new(TextureUtil.GetSprite("TrawlIcon"), null) },
        { "itemSubtype", new(ItemSubtype.NET, null) },
        { "gridKey", new( GridKey.TRAWL_NET, null ) },
        { "moveMode", new(MoveMode.INSTALL, null) },
    };

    public TrawlNetItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}