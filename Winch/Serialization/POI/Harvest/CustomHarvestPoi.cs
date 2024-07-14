using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Winch.Util;

namespace Winch.Serialization.POI.Harvest;

public class CustomHarvestPOI : CustomPOI
{
    public string harvestableParticlePrefab;
    public List<string> items;
    public List<string> nightItems;
    public int startStock = 3;
    public int maxStock = 5;
    public bool doesRestock = true;
    public bool useTimeSpecificStock = false;
    public bool isCurrentlySpecial = false;

    public List<HarvestableItemData> Items => ItemUtil.HarvestableItemDataDict.Where(kvp => items.Contains(kvp.Key)).Select(kvp => kvp.Value).ToList();
    public List<HarvestableItemData> NightItems => ItemUtil.HarvestableItemDataDict.Where(kvp => items.Contains(kvp.Key)).Select(kvp => kvp.Value).ToList();
    public GameObject HarvestableParticlePrefab
    {
        get
        {
            if (PoiUtil.HarvestParticlePrefabs.TryGetValue(harvestableParticlePrefab, out var prefab))
                return prefab;
            return null;
        }
    }
}


