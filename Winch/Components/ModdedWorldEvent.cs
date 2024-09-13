using UnityEngine;
using Winch.Data.WorldEvent;
using Winch.Util;

namespace Winch.Components;

/// <summary>
/// A wrapper for <see cref="WorldEvent"/> that allows for modded world events
/// </summary>
public abstract class ModdedWorldEvent : WorldEvent
{
    [SerializeField]
    /// <inheritdoc cref="ID"/>
    internal string id = string.Empty;

    /// <summary>
    /// ID of the world data
    /// </summary>
    public string ID => id;

    public ModdedWorldEventData ModdedWorldEventData
    {
        get
        {
            var moddedWorldEventData = WorldEventUtil.GetModdedWorldEventData(id);
            worldEventData = moddedWorldEventData;
            return moddedWorldEventData;
        }
    }

    public virtual void Awake()
    {
        worldEventData = WorldEventUtil.GetModdedWorldEventData(id);
    }
}