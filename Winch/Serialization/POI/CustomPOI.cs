using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Winch.Serialization.POI;

public class CustomPOI : SerializedScriptableObject
{
    public string id;
    public Vector3 location;
    public bool canBeGhostWindTarget;
}


