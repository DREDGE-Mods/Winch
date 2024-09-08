using System;
using UnityEngine;

namespace Winch.Data.POI.Dock;

[Serializable]
public class SpeakerVCam
{
    /// <summary>
    /// Relative position of the camera from this speaker.
    /// </summary>
    [SerializeField]
    public Vector3 vCam = new Vector3(13, 2.5f, 9);

    /// <summary>
    /// The relative position for the camera look at target
    /// </summary>
    [SerializeField]
    public Vector3 lookAtTarget = new Vector3(-0.7f, -2f, -0.25f);
}
