using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using Winch.Components;
using Winch.Core;
using Winch.Data.WorldEvent;
using Winch.Util;

namespace Winch.Serialization.WorldEvent;

public class StaticWorldEventDataConverter : DredgeTypeConverter<StaticWorldEventData>
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new(string.Empty, null) },
        { "location", new( Vector3.zero, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "eventType", new(WorldEventType.NONE, o=> DredgeTypeHelpers.GetEnumValue<WorldEventType>(o) )}
    };

    public StaticWorldEventDataConverter()
    {
        AddDefinitions(_definitions);
    }
}