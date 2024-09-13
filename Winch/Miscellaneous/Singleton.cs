/// <summary>
/// Makes a singleton class, said class will only allow a single instance of itself
/// </summary>
/// <typeparam name="T">The type of the class turned into a singleton</typeparam>
public abstract class Singleton<T> where T : Singleton<T>
{
    /// <summary>The instance of this singleton</summary>
    public static T Instance { get; protected set; }

    /// <summary>The constructor that sets the instance value</summary>
    protected Singleton()
    {
        if (Instance != null)
            Winch.Core.WinchCore.Log.Warn(string.Format("Trying to create a new instance of {0} while there can only be one!", GetType()));
        else
            Instance = (T)this;
    }
}