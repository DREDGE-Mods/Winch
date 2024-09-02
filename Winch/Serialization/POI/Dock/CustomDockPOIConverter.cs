using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Winch.Serialization.POI.Dock;

public class CustomDockPOIConverter : CustomPOIConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "dockSlots", new( new List<Vector3>(), o=>DredgeTypeHelpers.ParseVector3Array((JArray)o) ) },
    };

    public CustomDockPOIConverter()
    {
        AddDefinitions(_definitions);
    }
}
