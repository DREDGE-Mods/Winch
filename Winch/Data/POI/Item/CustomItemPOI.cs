using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using Winch.Util;

namespace Winch.Data.POI.Item;

/// <summary>
/// An object used by Winch to create a real <see cref="ItemPOI"/>
/// </summary>
public class CustomItemPOI : CustomPOI
{
    /// <summary>
    /// Name of the particle prefab to use
    /// </summary>
    [SerializeField]
    public string harvestableParticlePrefab = string.Empty;

    /// <summary>
    /// The items that the player can take from this point of interest.
    /// </summary>
    [SerializeField]
    public List<string> items = new List<string>();

    /// <summary>
    /// <see cref="items"/> converted to actual items
    /// </summary>
    [JsonIgnore]
    public List<ItemData> Items => ItemUtil.TryGetItems(items);

    /// <summary>
    /// <see cref="harvestableParticlePrefab"/> converted to an actual particle prefab
    /// </summary>
    [JsonIgnore]
    public GameObject HarvestableParticlePrefab => PoiUtil.GetHarvestableParticlePrefab(harvestableParticlePrefab);
}


