using System;
using UnityEngine;

namespace Winch.Data.POI.Dock.Destinations;

[Serializable]
public class CustomStorageDestination
{
    /// <summary>
    /// Whether to make this storage destination
    /// </summary>
    public bool enabled = true;

    /// <summary>
    /// Relative position of this storage box
    /// </summary>
    public Vector3 position = new Vector3(1.65f, 0.55f, -0.45f);

    /// <summary>
    /// Y rotation of the storage box
    /// </summary>
    public float yRotation = 0f;

    /// <summary>
    /// Relative position of the destination's camera from the box.
    /// </summary>
    public Vector3 vCam = new Vector3(4.5f, 3.45f, 6.75f);

    /// <summary>
    /// Whether this storage has an overflow.
    /// </summary>
    public bool hasOverflow = false;

    /// <summary>
    /// Relative Y position of the overflow button
    /// </summary>
    public float overflowHeight = 0.6f;

    /// <summary>
    /// Whether to enable the boxes next to the chest
    /// </summary>
    public bool hasBoxes = true;
}
