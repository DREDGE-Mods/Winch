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

    public List<ItemData> Items => ItemUtil.TryGetItems(items);
    public GameObject HarvestableParticlePrefab => PoiUtil.GetHarvestableParticlePrefab(harvestableParticlePrefab);
}


