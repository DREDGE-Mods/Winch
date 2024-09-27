using System.Collections.Generic;
using Winch.Serialization.Quest.Grid.Condition;

namespace Winch.Serialization.WorldEvent.Condition;

public class AberrationCountConditionConverter : CompletedGridConditionConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "targetItemCount", new(1, o=>int.Parse(o.ToString())) }
    };

    public AberrationCountConditionConverter()
    {
        AddDefinitions(_definitions);
    }
}