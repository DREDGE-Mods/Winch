using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using Winch.Components;
using Winch.Core;
using Winch.Data.WorldEvent;
using Winch.Util;

namespace Winch.Serialization.WorldEvent.Condition;

public class NumConditionConverter : InventoryConditionConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "minNumber", new(1, o=> int.Parse(o.ToString())) }
    };

    public NumConditionConverter()
    {
        AddDefinitions(_definitions);
    }
}