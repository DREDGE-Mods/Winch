using Newtonsoft.Json.Linq;
using UnityEngine;
using Winch.Core;
using Winch.Data;
using Winch.Util;

namespace Winch.Components;

/// <summary>
/// Persistent <see cref="MonoBehaviour"/> singleton that participates in the
/// <see cref="ExtendedSettingsData"/> system.
/// </summary>
public abstract class ExtendedSettingsSingleton<T> :
    MonoBehaviour,
    ExtendedSettingsData.Participant
    where T : ExtendedSettingsSingleton<T>
{
    /// <summary>
    /// The instance of this singleton.
    /// </summary>
    public static T Instance { get; protected set; }

    /// <inheritdoc cref="ExtendedSettingsData.Participant.Key"/>
    public abstract string Key { get; }

    /// <inheritdoc cref="ExtendedSettingsData.Participant.Load"/>
    public abstract void Load(JToken token);

    /// <inheritdoc cref="ExtendedSettingsData.Participant.Save"/>
    public abstract object Save();

    /// <inheritdoc cref="ExtendedSettingsData.Participant.Create"/>
    public abstract object Create();

    /// <summary>
    /// Initializes the singleton and registers it with the extended settings system.
    /// </summary>
    public virtual void Awake()
    {
        if (Instance != null)
        {
            WinchCore.Log.Warn(
                $"Trying to create a new instance of {GetType()} while there can only be one {typeof(T)}!"
            );

            this.Destroy();
            return;
        }

        Instance = (T)this;

        this.DontDestroyOnLoad();

        SettingsUtil.RegisterDataParticipant(this);
    }

    /// <summary>
    /// Unregisters this participant when the singleton is destroyed.
    /// </summary>
    public virtual void OnDestroy()
    {
        if (Instance != this)
            return;

        SettingsUtil.UnregisterDataParticipant(this);
        Instance = null;
    }
}