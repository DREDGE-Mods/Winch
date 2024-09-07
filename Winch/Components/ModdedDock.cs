using Cinemachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Winch.Components
{
    public class ModdedDock : Dock
    {
        /// <summary>
        /// Unique identifier of the dock
        /// </summary>
        [SerializeField]
        public string id = string.Empty;

        /// <summary>
        /// Whether this dock has a storage.
        /// </summary>
        [SerializeField]
        public bool storageEnabled = true;

        /// <summary>
        /// Whether this storage has an overflow.
        /// </summary>
        [SerializeField]
        public bool overflowStorageEnabled = false;

        [SerializeField]
        public StorageDestination storageDestination;

        [SerializeField]
        public OverflowStorageDestination overflowStorageDestination;

        [SerializeField]
        public DockPOI dockPOI;

        [SerializeField]
        public SanityModifier sanityModifier;

        [SerializeField]
        public SphereCollider safeZone;

        public override List<BaseDestination> GetDestinations()
        {
            var destinations = new List<BaseDestination>(base.GetDestinations());
            if (storageEnabled) destinations.Add(storageDestination);
            if (overflowStorageEnabled) destinations.Add(overflowStorageDestination);
            return destinations;
        }

        public void OnValidate()
        {
            storageDestination = GetComponentInChildren<StorageDestination>(true);
            overflowStorageDestination = GetComponentInChildren<OverflowStorageDestination>(true);
            dockPOI = GetComponentInChildren<DockPOI>(true);
            dockPOI.dock = this;
            sanityModifier = GetComponentInChildren<SanityModifier>(true);
            safeZone = transform.Find("SafeZone").GetComponent<SphereCollider>();
        }
    }
}
