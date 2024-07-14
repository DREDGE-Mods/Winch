using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
// ReSharper disable HeapView.BoxingAllocation

namespace Winch.Serialization.POI.Harvest;

public class CustomHarvestPOIConverter : CustomPOIConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "harvestableParticlePrefab", new( null, null) },
        { "items", new( null, o=>JarrayToList((JArray)o)) },
        { "nightItems", new( null, o=>JarrayToList((JArray)o)) },
        { "startStock", new( 3, o=> int.Parse(o.ToString())) },
        { "maxStock", new( 5 , o=> int.Parse(o.ToString())) },
        { "doesRestock", new( true, null) },
        { "useTimeSpecificStock", new( false, null) },
        { "isCurrentlySpecial", new( false, null) },
    };
    
    public CustomHarvestPOIConverter()
    {
        AddDefinitions(_definitions);
    }
}
