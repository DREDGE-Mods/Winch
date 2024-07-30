using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

// ReSharper disable HeapView.BoxingAllocation

namespace Winch.Serialization.HarvestZone;

public class CustomHarvestZoneConverter : DredgeTypeConverter<CustomHarvestZone>
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "location", new( Vector3.zero, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "radius", new( 200, o=> float.Parse(o.ToString())) },
        { "harvestableItems", new( new List<string>(), o => DredgeTypeHelpers.ParseStringList((JArray)o)) },
        { "day", new( true, o => bool.Parse(o.ToString())) },
        { "night", new( true, o => bool.Parse(o.ToString())) },
    };

    public CustomHarvestZoneConverter()
    {
        AddDefinitions(_definitions);
    }
}
