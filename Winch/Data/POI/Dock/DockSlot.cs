using System;
using UnityEngine;

namespace Winch.Data.POI.Dock;

[Serializable]
public class DockSlot
{
    /// <summary>
    /// Relative position
    /// </summary>
    [SerializeField]
    public Vector3 position;

    /// <summary>
    /// Relative rotation in euler angles
    /// </summary>
    [SerializeField]
    public Vector3 rotation;
}