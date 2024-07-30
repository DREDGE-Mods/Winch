using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using Winch.Components;
using Winch.Core;
using Winch.Data.WorldEvent;
using Winch.Util;

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