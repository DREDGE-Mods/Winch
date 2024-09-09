using System.Collections.Generic;
using Winch.Serialization;

namespace Winch.Data.WorldEvent.Condition;

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