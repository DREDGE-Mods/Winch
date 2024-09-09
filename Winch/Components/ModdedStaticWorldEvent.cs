using UnityEngine;
using Winch.Data.WorldEvent;
using Winch.Util;

namespace Winch.Components;

/// <summary>
/// A wrapper for <see cref="WorldEvent"/> that allows for modded world events
/// </summary>
public abstract class StaticWorldEvent : WorldEvent
{
    [SerializeField]
    /// <inheritdoc cref="ID"/>
    internal string id;

    /// <summary>
    /// ID of the static world data
    /// </summary>
    public string ID => id;

    public StaticWorldEventData StaticWorldEventData => WorldEventUtil.GetModdedStaticWorldEventData(id);

    public virtual void Start()
    {
        Register();
    }

    public override void Activate()
    {
        base.gameObject.SetActive(true);
        base.Activate();
    }

    /// <summary>
    /// Registers this world event
    /// </summary>
    public void Register()
    {
        if (GameManager.Instance != null && GameManager.Instance.WorldEventManager != null)
        {
            GameManager.Instance.WorldEventManager.RegisterStaticWorldEvent(StaticWorldEventData.eventType, this);
            gameObject.Deactivate();
        }
    }
}