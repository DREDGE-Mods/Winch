using System.Reflection;

namespace Winch.Config;

public class ModConfig : JSONConfig
{
    private static Dictionary<string, string> DefaultConfigs = new Dictionary<string, string>();
    private static Dictionary<string, ModConfig> Instances = new Dictionary<string, ModConfig>();

    private ModConfig(string path, string defaultPath) : base(path, defaultPath)
    {
    }

    private ModConfig(string modName) : this(GetConfigPath(modName), GetDefaultConfig(modName))
    {
        Instances.Add(modName, this);
    }

    internal static bool HasDefaultConfig(string modName) => DefaultConfigs.ContainsKey(modName) || File.Exists(GetDefaultConfigPath(modName));

    internal static string GetDefaultConfig(string modName)
    {
        if (string.IsNullOrWhiteSpace(modName)) throw new ArgumentNullException("modName");

        if (DefaultConfigs.ContainsKey(modName))
            return DefaultConfigs[modName];

        var path = GetDefaultConfigPath(modName);
        if (File.Exists(path))
            return path;
        else
        {
            //WinchCore.Log.Error($"No 'DefaultConfig' attribute found in mod_meta.json for {modName}!");
            throw new KeyNotFoundException($"No '{Constants.ModDefaultConfigFileName}' file found in folder for {modName}!");
        }
    }

    private static string GetBasePath(string modName)
    {
        if (string.IsNullOrWhiteSpace(modName)) throw new ArgumentNullException("modName");

        return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Mods", modName);
    }

    private static string GetDefaultConfigPath(string modName)
    {
        if (string.IsNullOrWhiteSpace(modName)) throw new ArgumentNullException("modName");

        var basePath = GetBasePath(modName);

        if (File.Exists(Path.Combine(basePath, Constants.OldModDefaultConfigFileName)))
            return Path.Combine(basePath, Constants.OldModDefaultConfigFileName);

        return Path.Combine(basePath, Constants.ModDefaultConfigFileName);
    }

    private static string GetConfigPath(string modName)
    {
        if (string.IsNullOrWhiteSpace(modName)) throw new ArgumentNullException("modName");

        var basePath = GetBasePath(modName);

        if (File.Exists(Path.Combine(basePath, Constants.OldModConfigFileName)))
            return Path.Combine(basePath, Constants.OldModConfigFileName);

        return Path.Combine(basePath, Constants.ModConfigFileName);
    }

    public static ModConfig GetConfig(string modName)
    {
        if (string.IsNullOrWhiteSpace(modName)) throw new ArgumentNullException("modName");

        if (!Instances.ContainsKey(modName))
        {
            try
            {
                return new ModConfig(modName);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Cannot create config for mod '{modName}'!", ex);
            }
        }

        return Instances[modName];
    }

    public static bool TryGetConfig(string modName, out ModConfig config)
    {
        try
        {
            config = GetConfig(modName);
            return true;
        }
        catch
        {
            config = null;
            return false;
        }
    }

    internal static Func<string>? GetRelevantModName;
    public static ModConfig GetConfig() => GetConfig(GetRelevantModName != null ? GetRelevantModName.Invoke() : string.Empty);

    public static bool TryGetConfig(out ModConfig config)
    {
        try
        {
            if (GetRelevantModName != null)
            {
                config = GetConfig(GetRelevantModName.Invoke());
                return true;
            }
        }
        catch
        {
        }

        config = null;
        return false;
    }

    internal static Dictionary<string, object?> GetProperties(string modName)
    {
        return GetConfig(modName).GetProperties();
    }

    public static T? GetProperty<T>(string modName, string key)
    {
        if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException("key");
        return GetConfig(modName).GetProperty<T>(key);
    }

    [Obsolete]
    public static T? GetProperty<T>(string modName, string key, T? defaultValue)
    {
        if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException("key");
        return GetConfig(modName).GetProperty(key, defaultValue);
    }

    internal static Dictionary<string, object?> GetDefaultProperties(string modName)
    {
        return GetConfig(modName).GetDefaultProperties();
    }

    public static T? GetDefaultProperty<T>(string modName, string key)
    {
        if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException("key");
        return GetConfig(modName).GetDefaultProperty<T>(key);
    }

    public static void RegisterDefaultConfig(string modName, string config)
    {
        if (string.IsNullOrWhiteSpace(config)) throw new ArgumentNullException("config");
        DefaultConfigs.Add(modName, config);
    }
}