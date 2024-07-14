using System.Collections.Generic;
using Winch.Util;

namespace Winch.Serialization.Item;

public class TrawlNetItemDataConverter : DeployableItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemSubtype", new(ItemSubtype.NET, null) },
        { "moveMode", new(MoveMode.INSTALL, null) },
    };

    public TrawlNetItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}