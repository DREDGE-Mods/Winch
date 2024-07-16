using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
// ReSharper disable HeapView.BoxingAllocation

namespace Winch.Serialization.POI;

public class CustomPOIConverter : DredgeTypeConverter<CustomPOI>
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new( null, null) },
        { "location", new( new Vector3(0,0,0), o=> DredgeTypeHelpers.ParseVector3(o)) }
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
