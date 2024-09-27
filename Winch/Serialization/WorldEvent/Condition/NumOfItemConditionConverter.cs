using System.Collections.Generic;

namespace Winch.Serialization.WorldEvent.Condition;

public class NumOfItemConditionConverter : NumConditionConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new(string.Empty, null) }
    };

    public NumOfItemConditionConverter()
    {
        AddDefinitions(_definitions);
    }
}