using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine.AddressableAssets;

// ReSharper disable HeapView.BoxingAllocation

namespace Winch.Serialization.POI.Item;

public class CustomItemPOIConverter : CustomPOIConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "harvestableParticlePrefab", new( null, null) },
        { "items", new( new List<string>(), o => DredgeTypeHelpers.ParseStringList((JArray)o)) },
        { "cullable", new( true, o => bool.Parse(o.ToString())) },
        { "intermittentSFX", new( new List<AssetReference>(), o => DredgeTypeHelpers.ParseAudioReferences((JArray)o) ) }
    };
    
    public CustomItemPOIConverter()
    {
        AddDefinitions(_definitions);
    }
}
