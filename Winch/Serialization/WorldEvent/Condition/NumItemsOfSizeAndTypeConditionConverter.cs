using System.Collections.Generic;

namespace Winch.Serialization.WorldEvent.Condition;

public class NumItemsOfSizeAndTypeConditionConverter : NumItemsOfTypeConditionConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "size", new(1, o=> int.Parse(o.ToString())) },
        { "min", new(true, o=> bool.Parse(o.ToString())) },
        { "max", new(false, o=> bool.Parse(o.ToString())) },
    };

    public NumItemsOfSizeAndTypeConditionConverter()
    {
        AddDefinitions(_definitions);
    }
}