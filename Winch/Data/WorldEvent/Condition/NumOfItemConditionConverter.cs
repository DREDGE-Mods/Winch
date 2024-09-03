using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using Winch.Components;
using Winch.Core;
using Winch.Data.WorldEvent;
using Winch.Serialization;
using Winch.Util;

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