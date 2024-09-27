using System;
using UnityEngine;

namespace Winch.Data.POI.Dock;

[Serializable]
public class DockCullable
{
    /// <summary>
    /// Culling group type
    /// </summary>
    [SerializeField]
    public CullingGroupType cullingGroupType = CullingGroupType.STATIC_LONG_RANGE;

    /// <summary>
    /// Offset of this cullable
    /// </summary>
    [SerializeField]
    public Vector3 center = Vector3.zero;

    /// <summary>
    /// Radius of the cullable
    /// </summary>
    [SerializeField]
    public float radius = 5f;
}
