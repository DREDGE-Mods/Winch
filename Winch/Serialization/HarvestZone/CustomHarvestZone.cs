using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Winch.Util;

namespace Winch.Serialization.HarvestZone;

public class CustomHarvestZone : SerializedScriptableObject
{
    public Vector3 location = Vector3.zero;
    public float radius = 200;
    public List<string> harvestableItems = new List<string>();
    public bool day = true;
    public bool night = true;

    public List<HarvestableItemData> HarvestableItems => ItemUtil.TryGetHarvestables(harvestableItems);
}