using System.Collections.Generic;

namespace Winch.Serialization.WorldEvent.Condition;

public class NumItemsOfTypeConditionConverter : NumConditionConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemType", new(ItemType.GENERAL, o => DredgeTypeHelpers.ParseFlagsEnum<ItemType>(o)) },
        { "itemSubtype", new(ItemSubtype.GENERAL, o => DredgeTypeHelpers.ParseFlagsEnum<ItemSubtype>(o)) },
    };

    public NumItemsOfTypeConditionConverter()
    {
        AddDefinitions(_definitions);
    }
}