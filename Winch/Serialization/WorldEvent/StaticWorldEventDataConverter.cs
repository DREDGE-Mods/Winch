using System.Collections.Generic;
using UnityEngine;
using Winch.Data.WorldEvent;

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