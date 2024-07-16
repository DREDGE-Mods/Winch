using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
// ReSharper disable HeapView.BoxingAllocation

namespace Winch.Serialization.POI.Item;

public class CustomItemPOIConverter : CustomPOIConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "harvestableParticlePrefab", new( null, null) },
        { "items", new( new List<string>(), o => DredgeTypeHelpers.ParseStringList((JArray)o)) }
    };
    
    public CustomItemPOIConverter()
    {
        AddDefinitions(_definitions);
    }
}
