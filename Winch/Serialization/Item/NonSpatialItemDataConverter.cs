using System.Collections.Generic;

namespace Winch.Serialization.Item;

public class NonSpatialItemDataConverter : ItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemType", new(ItemType.NONE, null) },
        { "itemSubtype", new(ItemSubtype.NONE, null) },
        { "showInCabin", new(false, o => bool.Parse(o.ToString()))}
    };

    public NonSpatialItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}
