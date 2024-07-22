using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using Winch.Components;
using Winch.Core;
using Winch.Data.WorldEvent;
using Winch.Util;

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