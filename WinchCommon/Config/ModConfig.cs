using System.Reflection;

namespace Winch.Config
{
    public class ModConfig : JSONConfig
    {
        private static Dictionary<string, string> DefaultConfigs = new Dictionary<string, string>();
        private static Dictionary<string, ModConfig> Instances = new Dictionary<string, ModConfig>();

        private ModConfig(string modName) : base(GetConfigPath(modName), GetDefaultConfig(modName))
        {
        }

        internal static string GetDefaultConfig(string modName)
        {
            if(!DefaultConfigs.ContainsKey(modName))
            {
                var path = GetDefaultConfigPath(modName);
                if (File.Exists(path))
                    return path;
                else
                {
                    //WinchCore.Log.Error($"No 'DefaultConfig' attribute found in mod_meta.json for {modName}!");
                    throw new KeyNotFoundException($"No 'DefaultConfig' attribute found in mod_meta.json for {modName}!");
                }
            }
            return DefaultConfigs[modName];
        }

        private static string GetDefaultConfigPath(string modName)
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Mods", modName, "DefaultConfig.json");
        }

        private static string GetConfigPath(string modName)
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Mods", modName, "Config.json");
        }

        internal static ModConfig GetConfig(string modName)
        {
            if (!Instances.ContainsKey(modName))
                Instances.Add(modName, new ModConfig(modName));
            return Instances[modName];
        }

        internal static bool TryGetConfig(string modName, out ModConfig config)
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

        internal static Dictionary<string, object> GetProperties(string modName)
        {
            return GetConfig(modName).GetProperties();
        }

        public static T? GetProperty<T>(string modName, string key)
        {
            return GetConfig(modName).GetProperty<T>(key);
        }

        [Obsolete]
        public static T? GetProperty<T>(string modName, string key, T? defaultValue)
        {
            return GetConfig(modName).GetProperty(key, defaultValue);
        }

        internal static Dictionary<string, object> GetDefaultProperties(string modName)
        {
            return GetConfig(modName).GetDefaultProperties();
        }

        public static T? GetDefaultProperty<T>(string modName, string key)
        {
            return GetConfig(modName).GetDefaultProperty<T>(key);
        }

        public static void RegisterDefaultConfig(string modName, string config)
        {
            DefaultConfigs.Add(modName, config);
        }
    }
}
