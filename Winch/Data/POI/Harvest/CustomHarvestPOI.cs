using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEngine;
using Winch.Data.POI;
using Winch.Serialization.Item;
using Winch.Util;

namespace Winch.Data.POI.Harvest;

/// <summary>
/// An object used by Winch to create a real <see cref="HarvestPOI"/>
/// </summary>
public class CustomHarvestPOI : CustomPOI
{
    /// <summary>
    /// Name of the particle prefab to use
    /// </summary>
    [SerializeField]
    public string harvestableParticlePrefab = string.Empty;

    /// <summary>
    /// The items to harvest from this point of interest.
    /// If <see cref="usesTimeSpecificStock"/> is <see langword="true"/>, this becomes the daytime items.
    /// </summary>
    [SerializeField]
    public List<string> items = new List<string>();

    /// <summary>
    /// The items to harvest from this point of interest at nighttime.
    /// Only works if <see cref="usesTimeSpecificStock"/> is <see langword="true"/>.
    /// </summary>
    [SerializeField]
    public List<string> nightItems = new List<string>();

    /// <summary>
    /// The stock this point of interest will start with on a new save file.
    /// </summary>
    [SerializeField]
    public int startStock = 3;

    /// <summary>
    /// The maximum stock this point of interest can have.
    /// </summary>
    [SerializeField]
    public int maxStock = 5;

    /// <summary>
    /// Whether this point of interest can restock.
    /// </summary>
    [SerializeField]
    public bool doesRestock = true;

    /// <summary>
    /// Whether to alternate between <see cref="items"/> and <see cref="nightItems"/> depending on the time.
    /// </summary>
    [SerializeField]
    public bool usesTimeSpecificStock = true;

    /// <summary>
    /// Whether to override the default special spot chance for daytime with <see cref="overriddenDaytimeSpecialChance"/>
    /// </summary>
    [SerializeField]
    public bool overrideDefaultDaySpecialChance = false;

    /// <summary>
    /// The special spot chance to override for daytime if <see cref="overrideDefaultDaySpecialChance"/> is <see langword="true"/>.
    /// </summary>
    [Range(0f, 1f)]
    [SerializeField]
    public float overriddenDaytimeSpecialChance = 0;

    /// <summary>
    /// Whether to override the default special spot chance for nighttime with <see cref="overriddenNighttimeSpecialChance"/>
    /// </summary>
    [SerializeField]
    public bool overrideDefaultNightSpecialChance = false;

    /// <summary>
    /// The special spot chance to override for nighttime if <see cref="overrideDefaultNightSpecialChance"/> is <see langword="true"/>.
    /// </summary>
    [Range(0f, 1f)]
    [SerializeField]
    public float overriddenNighttimeSpecialChance = 0;

    /// <summary>
    /// <see cref="items"/> converted to actual items
    /// </summary>
    [JsonIgnore]
    public List<HarvestableItemData> Items => ItemUtil.TryGetHarvestables(items);

    /// <summary>
    /// <see cref="nightItems"/> converted to actual items
    /// </summary>
    [JsonIgnore]
    public List<HarvestableItemData> NightItems => ItemUtil.TryGetHarvestables(nightItems);

    /// <summary>
    /// <see cref="harvestableParticlePrefab"/> converted to an actual particle prefab
    /// </summary>
    [JsonIgnore]
    public GameObject HarvestableParticlePrefab => PoiUtil.GetHarvestableParticlePrefab(harvestableParticlePrefab);
}


