using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Winch.Serialization.POI;

/// <summary>
/// An object used by Winch to create a real <see cref="POI"/>
/// </summary>
public class CustomPOI : SerializedScriptableObject
{
    /// <summary>
    /// The unique id of this POI
    /// </summary>
    [SerializeField]
    public string id = string.Empty;

    /// <summary>
    /// World position of this point of interest
    /// </summary>
    [SerializeField]
    public Vector3 location = Vector3.zero;

    /// <summary>
    /// Can the ghost wind world event target this point of interest?
    /// </summary>
    [SerializeField]
    public bool canBeGhostWindTarget;

    /// <summary>
    /// Ghost wind target relative position
    /// </summary>
    [SerializeField]
    public Vector3 ghostWindTarget = Vector3.zero;

    /// <summary>
    /// Interact point UI relative position
    /// </summary>
    [SerializeField]
    public Vector3 interactPointTarget = Vector3.zero;
}


