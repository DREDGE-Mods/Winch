using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using Winch.Util;

namespace Winch.Serialization.HarvestZone;

public class CustomHarvestZone : SerializedScriptableObject
{
    public Vector3 location = new Vector3(0, 0, -300);
    public ColliderType colliderType = ColliderType.SPHERE;
    public float radius = 200;
    public Vector3 size = new Vector3(3000, 500, 3000);
    public List<string> harvestableItems = new List<string>();
    public bool day = true;
    public bool night = true;

    public List<HarvestableItemData> HarvestableItems => ItemUtil.TryGetHarvestables(harvestableItems);

    public enum ColliderType
    {
        SPHERE,
        BOX
    }
}