using System.Collections.Generic;
using Winch.Serialization;

namespace Winch.Data.WorldEvent.Condition;

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