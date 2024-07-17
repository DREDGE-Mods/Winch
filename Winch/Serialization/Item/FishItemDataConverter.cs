using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Winch.Util;

namespace Winch.Serialization.Item;

public class FishItemDataConverter : HarvestableItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemTypeIcon", new(TextureUtil.GetSprite("FishIcon"), null) },
        { "harvestMinigameType", new( HarvestMinigameType.FISHING_RADIAL, null) },
        { "itemType", new(ItemType.GENERAL, null) },
        { "itemSubtype", new(ItemSubtype.FISH, null) },
        { "canBeDiscardedByPlayer", new(true, null) },
        { "minSizeCentimeters", new( 0f, o => float.Parse(o.ToString())) },
        { "maxSizeCentimeters", new( 0f, o => float.Parse(o.ToString())) },
        { "aberrations", new( new List<string>(), o => DredgeTypeHelpers.ParseStringList((JArray)o)) },
        { "isAberration", new( false, o => bool.Parse(o.ToString())) },
        { "nonAberrationParent", new( null, null) },
        { "minWorldPhaseRequired", new( 0, o => int.Parse(o.ToString())) },
        { "locationHiddenUntilCaught", new( false, o => bool.Parse(o.ToString())) },
        { "day", new( true, o => bool.Parse(o.ToString())) },
        { "night", new( true, o => bool.Parse(o.ToString())) },
        { "canAppearInBaitBalls", new( true, o => bool.Parse(o.ToString())) },
        { "canBeInfected", new( true, o => bool.Parse(o.ToString())) },
        { "cellsExcludedFromDisplayingInfection", new( new List<Vector2Int>(){new(0,0)}, o => DredgeTypeHelpers.ParseDimensions((JArray)o)) }
    };
    
    public FishItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}
