using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Winch.Serialization.Item;
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
    public bool usesTimeSpecificStock = true;
    public bool overrideDefaultDaySpecialChance = false;
    [Range(0f, 1f)]
    public float overriddenDaytimeSpecialChance = 0;
    public bool overrideDefaultNightSpecialChance = false;
    [Range(0f, 1f)]
    public float overriddenNighttimeSpecialChance = 0;

    public List<HarvestableItemData> Items => ItemUtil.TryGetHarvestables(items);
    public List<HarvestableItemData> NightItems => ItemUtil.TryGetHarvestables(nightItems);
    public GameObject HarvestableParticlePrefab => PoiUtil.TryGetHarvestableParticlePrefab(harvestableParticlePrefab);
}


