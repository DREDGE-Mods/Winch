using UnityEngine;

namespace Winch.Data.POI.Dock;

public class DockPOICollider
{
    /// <summary>
    /// The type of collider to use for this zone.<br/>
    /// <see cref="ColliderType.SPHERE"/> uses <see cref="radius"/><br/>
    /// <see cref="ColliderType.BOX"/> uses <see cref="size"/>
    /// </summary>
    [SerializeField]
    public ColliderType colliderType = ColliderType.SPHERE;

    /// <summary>
    /// Offset of this collider
    /// </summary>
    [SerializeField]
    public Vector3 center = Vector3.zero;

    /// <summary>
    /// Radius of the collider when using <see cref="ColliderType.SPHERE"/>
    /// </summary>
    [SerializeField]
    public float radius = 3.54f;

    /// <summary>
    /// Size of the collider when using <see cref="ColliderType.BOX"/>
    /// </summary>
    [SerializeField]
    public Vector3 size = new Vector3(5, 2, 5);
}
