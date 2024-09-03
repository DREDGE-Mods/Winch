using System.Collections.Generic;
using System.Linq;
using FluffyUnderware.Curvy.ThirdParty.LibTessDotNet;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEngine;
using Winch.Util;

namespace Winch.Data.HarvestZone;

using HarvestZone = global::HarvestZone;

/// <summary>
/// An object used by Winch to create a real <see cref="HarvestZone"/>
/// </summary>
public class CustomHarvestZone : SerializedScriptableObject
{
    /// <summary>
    /// The unique id of this zone
    /// </summary>
    [SerializeField]
    public string id = string.Empty;

    /// <summary>
    /// World position of this zone
    /// </summary>
    [SerializeField]
    public Vector3 location = new Vector3(0, 0, -300);

    /// <summary>
    /// The type of collider to use for this zone.<br/>
    /// <see cref="ColliderType.SPHERE"/> uses <see cref="radius"/><br/>
    /// <see cref="ColliderType.BOX"/> uses <see cref="size"/>
    /// </summary>
    [SerializeField]
    public ColliderType colliderType = ColliderType.SPHERE;

    /// <summary>
    /// Radius of the collider when using <see cref="ColliderType.SPHERE"/>
    /// </summary>
    [SerializeField]
    public float radius = 200;

    /// <summary>
    /// Size of the collider when using <see cref="ColliderType.BOX"/>
    /// </summary>
    [SerializeField]
    public Vector3 size = new Vector3(3000, 500, 3000);

    /// <summary>
    /// The items that can harvested when inside this zone
    /// </summary>
    [SerializeField]
    public List<string> harvestableItems = new List<string>();

    /// <summary>
    /// Whether this zone is available during daytime
    /// </summary>
    [SerializeField]
    public bool day = true;

    /// <summary>
    /// Whether this zone is available during nighttime
    /// </summary>
    [SerializeField]
    public bool night = true;

    /// <summary>
    /// <see cref="harvestableItems"/> converted to actual items
    /// </summary>
    [JsonIgnore]
    public List<HarvestableItemData> HarvestableItems => ItemUtil.TryGetHarvestables(harvestableItems);

    public enum ColliderType
    {
        SPHERE,
        BOX
    }
}