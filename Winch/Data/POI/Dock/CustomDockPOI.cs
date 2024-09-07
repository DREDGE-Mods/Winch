using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Winch.Data.POI;

namespace Winch.Data.POI.Dock;

// TODO: actually implement this
public class CustomDockPOI : CustomPOI
{
    /// <summary>
    /// The world rotation (in euler angles) for the dock poi
    /// </summary>
    public Vector3 rotation = Vector3.zero;

    /// <summary>
    /// ID of the data for this dock
    /// </summary>
    public string dockData = string.Empty;

    /// <summary>
    /// Prefab to use for this dock
    /// </summary>
    public DockPrefab prefab;

    /// <summary>
    /// The relative position for the dock poi
    /// </summary>
    public Vector3? poiOffset;

    /// <summary>
    /// Collider settings for the dock poi
    /// </summary>
    public DockPOICollider? collider;

    /// <summary>
    /// Relative position of the dock's default camera.
    /// </summary>
    public Vector3? vCam;

    /// <summary>
    /// The relative position for the camera look at target
    /// </summary>
    public Vector3? lookAtTarget;

    /// <summary>
    /// The relative position for the boat actions
    /// </summary>
    public Vector3? boatActions;

    /// <summary>
    /// The settings for the storage destination
    /// </summary>
    public PrebuiltStorageDestination? storage;

    /// <summary>
    /// Extra destinations for docks
    /// </summary>
    // TODO: implement this
    [SerializeField]
    public List<CustomBaseDestination> destinations = new List<CustomBaseDestination>();

    /// <summary>
    /// Relative locations for dock slots
    /// </summary>
    [SerializeField]
    public List<DockSlot> dockSlots = null;

    /// <summary>
    /// The dock's sanity modifier settings
    /// </summary>
    public DockSanityModifier sanityModifier = new DockSanityModifier();

    /// <summary>
    /// The dock's safe zone settings
    /// </summary>
    public DockSafeZone safeZone = new DockSafeZone();
}
