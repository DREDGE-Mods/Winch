using System.Collections.Generic;
using UnityEngine;
using Winch.Data.POI.Dock.Destinations;

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
    public CustomStorageDestination? storage;

    /// <summary>
    /// Character destinations for docks
    /// </summary>
    [SerializeField]
    public List<CustomCharacterDestination> characters = new List<CustomCharacterDestination>();

    /// <summary>
    /// Market destinations for docks
    /// </summary>
    [SerializeField]
    public List<CustomMarketDestination> markets = new List<CustomMarketDestination>();

    /// <summary>
    /// Shipyard destinations for docks
    /// </summary>
    [SerializeField]
    public List<CustomShipyardDestination> shipyards = new List<CustomShipyardDestination>();

    /// <summary>
    /// Upgrader (dry docks and fleet services) destinations for docks
    /// </summary>
    [SerializeField]
    public List<CustomUpgradeDestination> upgraders = new List<CustomUpgradeDestination>();

    /// <summary>
    /// Constructable destinations for docks
    /// </summary>
    [SerializeField]
    public List<CustomConstructableDestination> constructables = new List<CustomConstructableDestination>();

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

    /// <summary>
    /// Cameras for any speakers in the dock data
    /// </summary>
    public Dictionary<string, SpeakerVCam> speakerVCams = new Dictionary<string, SpeakerVCam>();
}
