using System.IO;
using System.Reflection;

namespace Winch.Config;

public class WinchConfig : JSONConfig
{
    private static readonly string WinchConfigPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Constants.WinchConfigFileName);

    private WinchConfig() : base(WinchConfigPath, Winch.Properties.Resources.DefaultConfig) { }

    private static WinchConfig? _instance;
    public static WinchConfig Instance
    {
        get
        {
            if(_instance == null)
                _instance = new WinchConfig();
            return _instance;
        }
    }

    internal static new void ResetToDefaultConfig()
    {
        ((JSONConfig)Instance).ResetToDefaultConfig();
    }

    public static new T? GetDefaultProperty<T>(string key)
    {
        return ((JSONConfig)Instance).GetDefaultProperty<T>(key);
    }

    internal static new Dictionary<string, object> GetProperties()
    {
        return ((JSONConfig)Instance).GetProperties();
    }

    public static new T? GetProperty<T>(string key)
    {
        return ((JSONConfig)Instance).GetProperty<T>(key);
    }

    public static new T GetProperty<T>(string key, T defaultValue)
    {
        try
        {
            return GetProperty<T>(key) ?? defaultValue;
        }
        catch
        {
            return defaultValue;
        }
    }

    public static new void SetProperty<T>(string key, T value)
    {
        ((JSONConfig)Instance).SetProperty(key, value);
    }

    internal static new void ResetPropertyToDefault(string key)
    {
        ((JSONConfig)Instance).ResetPropertyToDefault(key);
    }
}