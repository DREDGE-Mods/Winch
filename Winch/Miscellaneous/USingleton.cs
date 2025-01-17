﻿using System;

namespace UnityEngine;

/// <summary>
/// Makes a unity singleton class, said class will only allow a single instance of itself (is child of Mono Behaviour)
/// </summary>
/// <typeparam name="T">The type of the class turned into a singleton</typeparam>
public abstract class USingleton<T> : MonoBehaviour where T : USingleton<T>, new()
{
    /// <summary>The instance of this singleton</summary>
    public static T Instance { get; protected set; }

    /// <summary>
    /// Whether this object should be <see cref="Object.DontDestroyOnLoad"/>
    /// </summary>
    protected abstract bool ShouldNotDestroyOnLoad { get; }

    /// <summary>Awakes the script</summary>
    protected virtual void Awake()
    {
        if (USingleton<T>.Instance != null)
        {
            Winch.Core.WinchCore.Log.Warn(string.Format("Trying to create a new instance of {0} while there can only be one {1}!", GetType(), typeof(T)));
            this.Destroy();
        }
        else
        {
            USingleton<T>.Instance = (T)this;
            if (ShouldNotDestroyOnLoad) this.DontDestroyOnLoad();
        }
    }
}
