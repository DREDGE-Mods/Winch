using System;
using UnityEngine;

namespace Winch.Data.POI.Dock;

[Serializable]
public class SpeakerVCam
{
    /// <summary>
    /// Relative root position of this object.
    /// </summary>
    [SerializeField]
    public Vector3 position = Vector3.zero;

    /// <summary>
    /// Relative position of the camera from the root.
    /// </summary>
    [SerializeField]
    public Vector3 vCam = Vector3.one;

    /// <summary>
    /// The relative position of the camera's look at target from the root.
    /// </summary>
    [SerializeField]
    public Vector3 lookAtTarget = Vector3.zero;
}
