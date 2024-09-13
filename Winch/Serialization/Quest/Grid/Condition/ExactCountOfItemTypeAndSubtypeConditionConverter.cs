using System.Collections.Generic;
using Winch.Serialization.Quest.Grid.Condition;

namespace Winch.Serialization.WorldEvent.Condition;

public class ExactCountOfItemTypeAndSubtypeConditionConverter : CompletedGridConditionConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemType", new(ItemType.GENERAL, o => DredgeTypeHelpers.ParseFlagsEnum<ItemType>(o)) },
        { "itemSubtype", new(ItemSubtype.GENERAL, o => DredgeTypeHelpers.ParseFlagsEnum<ItemSubtype>(o)) },
        { "targetItemCount", new(1, o=>int.Parse(o.ToString())) }
    };

    public ExactCountOfItemTypeAndSubtypeConditionConverter()
    {
        AddDefinitions(_definitions);
    }
}