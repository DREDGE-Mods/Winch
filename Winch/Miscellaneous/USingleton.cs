namespace UnityEngine;

/// <summary>
/// Makes a unity singleton class, said class will only allow a single instance of itself (is child of Mono Behaviour)
/// </summary>
/// <typeparam name="T">The type of the class turned into a singleton</typeparam>
public abstract class USingleton<T> : MonoBehaviour where T : USingleton<T>, new()
{
    /// <summary>The instance of this singleton</summary>
#pragma warning disable CS8618
    public static T Instance { get; protected set; }
#pragma warning restore CS8618

    /// <summary>
    /// Whether this object should be <see cref="Object.DontDestroyOnLoad"/>
    /// </summary>
    protected abstract bool ShouldNotDestroyOnLoad { get; }

    /// <summary>Awakes the script</summary>
    protected virtual void Awake()
    {
        if (USingleton<T>.Instance != null)
        {
            Winch.Core.WinchCore.Log.Warn(string.Format("Trying to create a new instance of {0} while there can only be one!", GetType()));
            this.Destroy();
        }
        else
        {
            USingleton<T>.Instance = (T)this;
            if (ShouldNotDestroyOnLoad) this.DontDestroyOnLoad();
        }
    }
}
