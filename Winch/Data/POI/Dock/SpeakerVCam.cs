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
    public Vector3 position = new Vector3(-1.825f, 3, 0.125f);

    /// <summary>
    /// Relative position of the camera from the root.
    /// </summary>
    [SerializeField]
    public Vector3 vCam = new Vector3(13, 2.5f, 9);

    /// <summary>
    /// The relative position of the camera's look at target from the root.
    /// </summary>
    [SerializeField]
    public Vector3 lookAtTarget = new Vector3(-0.7f, -2f, -0.25f);
}
