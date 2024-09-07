using UnityEngine;

namespace Winch.Data.POI.Dock
{
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
}
