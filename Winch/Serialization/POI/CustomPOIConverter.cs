using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Winch.Data.POI;
// ReSharper disable HeapView.BoxingAllocation

namespace Winch.Serialization.POI;

public class CustomPOIConverter : DredgeTypeConverter<CustomPOI>
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new( string.Empty, null) },
        { "location", new( Vector3.zero, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "canBeGhostWindTarget", new( false, o=> bool.Parse(o.ToString())) },
        { "ghostWindTarget", new( Vector3.zero, o=> DredgeTypeHelpers.ParseVector3(o)) },
        { "interactPointTarget", new( Vector3.zero, o=> DredgeTypeHelpers.ParseVector3(o)) }
    };
    
    public CustomPOIConverter()
    {
        AddDefinitions(_definitions);
    }
    
    public static List<string> JarrayToList(JArray jArray)
    {
        var list = new List<string>();
        foreach (var item in jArray)
        {
            list.Add(item.ToString());
        }
        return list;
    }
}
