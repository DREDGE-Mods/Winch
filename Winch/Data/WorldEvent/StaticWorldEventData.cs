using Sirenix.OdinInspector;
using UnityEngine;

namespace Winch.Data.WorldEvent
{
    /// <summary>
    /// Static world event. This means it'll stay in one place and can only be activated by a dynamic event
    /// Currently only fog ghosts actually interact with these.
    /// </summary>
    public class StaticWorldEventData : SerializedScriptableObject
    {
        /// <summary>
        /// ID of this static world event
        /// </summary>
        [SerializeField]
        public string id = string.Empty;

        /// <summary>
        /// The location to put this world event
        /// </summary>
        [SerializeField]
        public Vector3 location = Vector3.zero;

        /// <summary>
        /// The event type that will activate this static world event.
        /// Currently only fog ghosts actually work.
        /// </summary>
        [SerializeField]
        public WorldEventType eventType = WorldEventType.FOG_GHOST;

        /// <summary>
        /// The prefab to make when the game is loaded
        /// </summary>
        [SerializeField]
        public GameObject prefab;
    }
}
