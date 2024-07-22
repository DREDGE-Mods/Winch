using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using Winch.Components;
using Winch.Core;
using Winch.Data.WorldEvent;
using Winch.Util;

namespace Winch.Serialization.WorldEvent.Condition;

public class AnyOfItemConditionConverter : InventoryConditionConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new(null, null) }
    };

    public AnyOfItemConditionConverter()
    {
        AddDefinitions(_definitions);
    }
}