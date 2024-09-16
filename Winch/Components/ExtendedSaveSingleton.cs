using Newtonsoft.Json.Linq;
using UnityEngine;
using Winch.Core;
using Winch.Data;
using Winch.Util;

namespace Winch.Components;

/// <summary>
/// <inheritdoc cref="ExtendedSaveBehaviour"/>
/// <see cref="USingleton{T}"/> version of <see cref="ExtendedSaveBehaviour"/>.
/// </summary>
public abstract class ExtendedSaveSingleton<T> : ExtendedSaveBehaviour where T : ExtendedSaveSingleton<T>, new()
{
    /// <summary>The instance of this singleton</summary>
    public static T Instance { get; protected set; }

    /// <summary>
    /// Whether this object should be <see cref="Object.DontDestroyOnLoad"/>
    /// </summary>
    protected abstract bool ShouldNotDestroyOnLoad { get; }

    /// <summary>Awakes the script</summary>
    public override void Awake()
    {
        if (ExtendedSaveSingleton<T>.Instance != null)
        {
            WinchCore.Log.Warn(string.Format("Trying to create a new instance of {0} while there can only be one!", GetType()));
            this.Destroy();
        }
        else
        {
            ExtendedSaveSingleton<T>.Instance = (T)this;
            if (ShouldNotDestroyOnLoad) this.DontDestroyOnLoad();
            base.Awake();
        }
    }
}
