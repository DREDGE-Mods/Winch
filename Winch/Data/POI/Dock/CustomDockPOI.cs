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

    public class PrebuiltStorageDestination
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

    public class DockSanityModifier
    {
        /// <summary>
        /// Relative position
        /// </summary>
        public Vector3 position = Vector3.zero;

        [SerializeField]
        public float fullValueDay = 0;

        [SerializeField]
        public float fullValueNight = 1;

        [SerializeField]
        public float fullValueRadius = 3;

        [SerializeField]
        public float partialValueMinDay = 0;

        [SerializeField]
        public float partialValueMinNight = 0;

        [SerializeField]
        public float partialValueRadius = 6;

        [SerializeField]
        public bool ignoreTimescale = false;
    }

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
}
