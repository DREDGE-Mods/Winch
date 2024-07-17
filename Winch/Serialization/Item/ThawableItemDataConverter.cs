using System.Collections.Generic;

namespace Winch.Serialization.Item;

public class ThawableItemDataConverter : DurableItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "damageMode", new(DamageMode.DESTROY, null) }
    };

    public ThawableItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}