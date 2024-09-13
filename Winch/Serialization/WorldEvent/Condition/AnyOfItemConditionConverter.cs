using System.Collections.Generic;

namespace Winch.Serialization.WorldEvent.Condition;

public class AnyOfItemConditionConverter : InventoryConditionConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new(string.Empty, null) }
    };

    public AnyOfItemConditionConverter()
    {
        AddDefinitions(_definitions);
    }
}