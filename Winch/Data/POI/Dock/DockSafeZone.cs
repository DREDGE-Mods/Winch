using System;
using UnityEngine;

namespace Winch.Data.POI.Dock;

[Serializable]
public class DockSafeZone
{
    /// <summary>
    /// Relative position
    /// </summary>
    public Vector3 position = Vector3.zero;

    /// <summary>
    /// Radius of the safe zone
    /// </summary>
    public float radius = 15f;
}