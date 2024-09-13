using System.Collections.Generic;
using Winch.Serialization.Quest.Grid.Condition;

namespace Winch.Serialization.WorldEvent.Condition;

public class ItemCountConditionConverter : CompletedGridConditionConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "item", new(string.Empty, null) },
        { "count", new(1, o=>int.Parse(o.ToString())) },
        { "allowLinkedAberrations", new(true, o=>bool.Parse(o.ToString())) },
    };

    public ItemCountConditionConverter()
    {
        AddDefinitions(_definitions);
    }
}