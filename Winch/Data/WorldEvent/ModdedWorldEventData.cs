using UnityEngine;

namespace Winch.Data.WorldEvent;

/// <summary>
/// The base class for all custom world events
/// </summary>
public class ModdedWorldEventData : WorldEventData
{
    /// <summary>
    /// ID of this world event
    /// </summary>
    [SerializeField]
    public string id = string.Empty;
}