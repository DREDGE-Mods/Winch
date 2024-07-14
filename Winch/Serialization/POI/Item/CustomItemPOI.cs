using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Winch.Util;

namespace Winch.Serialization.POI.Item;

public class CustomItemPOI : CustomPOI
{
    public string harvestableParticlePrefab;
    public List<string> items;

    public List<ItemData> Items => ItemUtil.AllItemDataDict.Where(kvp => items.Contains(kvp.Key)).Select(kvp => kvp.Value).ToList();
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


