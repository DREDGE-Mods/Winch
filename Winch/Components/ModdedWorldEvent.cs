using UnityEngine;
using Winch.Config;
using Winch.Core;
using Winch.Data.Abilities;
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
    internal string id;

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
        Register();
    }

    /// <summary>
    /// Registers this world event
    /// </summary>
    public void Register()
    {
        if (GameManager.Instance != null && GameManager.Instance.WorldEventManager != null)
        {
            if (ModdedWorldEventData.isStatic)
            {
                GameManager.Instance.WorldEventManager.RegisterStaticWorldEvent(ModdedWorldEventData.eventType, this);
                gameObject.Deactivate();
            }
        }
    }
}