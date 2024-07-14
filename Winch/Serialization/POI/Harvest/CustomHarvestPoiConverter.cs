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
        { "items", new( new List<string>(), o => DredgeTypeHelpers.ParseStringList((JArray)o)) },
        { "nightItems", new( new List<string>(), o => DredgeTypeHelpers.ParseStringList((JArray)o)) },
        { "startStock", new( 3, o=> int.Parse(o.ToString())) },
        { "maxStock", new( 5 , o=> int.Parse(o.ToString())) },
        { "doesRestock", new( true, o => bool.Parse(o.ToString())) },
        { "usesTimeSpecificStock", new( true, o => bool.Parse(o.ToString())) },
        { "overrideDefaultDaySpecialChance", new( false, o => bool.Parse(o.ToString())) },
        { "overriddenDaytimeSpecialChance", new( 0, o => Mathf.Clamp01(float.Parse(o.ToString()))) },
        { "overrideDefaultNightSpecialChance", new( false, o => bool.Parse(o.ToString())) },
        { "overriddenNighttimeSpecialChance", new( 0, o => Mathf.Clamp01(float.Parse(o.ToString()))) },
    };

    public CustomHarvestPOIConverter()
    {
        AddDefinitions(_definitions);
    }
}
