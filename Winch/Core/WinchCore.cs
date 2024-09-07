using HarmonyLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine.AddressableAssets;
using Winch.Config;
using Winch.Logging;
using Winch.Patches;
using Winch.Serialization;
using Winch.Util;

namespace Winch.Core
{
    public static class WinchCore
    {
        internal static Harmony Harmony;

        public static Logger Log = new Logger();

        public static Dictionary<string, object> WinchModConfig = new();

        public static string WinchInstallLocation => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        internal static Assembly WinchAssembly => Assembly.GetExecutingAssembly();

        internal static string Name => WinchCore.WinchModConfig["Name"].ToString();

        internal static string Author => WinchCore.WinchModConfig["Author"].ToString();

        internal static string GUID => WinchCore.WinchModConfig["ModGUID"].ToString();

        internal static string Version => WinchCore.WinchModConfig["Version"].ToString();

        public static void Initialize()
        {
            try
            {
                string metaPath = Path.Combine(WinchInstallLocation, "mod_meta.json");
                if (!File.Exists(metaPath))
                {
                    throw new FileNotFoundException($"Missing mod_meta.json file for Winch at {metaPath}. Reinstall the mod.");
                }

                string metaText = File.ReadAllText(metaPath);
                WinchModConfig = JsonConvert.DeserializeObject<Dictionary<string, object>>(metaText) 
                    ?? throw new InvalidOperationException($"Unable to parse mod_meta.json file at {metaPath}. Reinstall the mod.");

                JSONConfig.AddDynamicConverter(new SerializedCrabPotPOIConverter());
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

            try
            {
                string version = VersionUtil.GetVersion();
                Log.Info($"Winch {version} booting up...");
                Log.Info($"Running under Unity {UnityInfo.Version}");
                Log.Info($"CLR runtime version: {Environment.Version}");

                Log.Debug($"Game executable path: {Paths.ExecutablePath}");
                Log.Debug($"Unity Managed directory: {Paths.ManagedPath}");
                Log.Debug($"Winch path: {Paths.WinchPath}");
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

            try
            {
                ModAssemblyLoader.LoadModAssemblies();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

            try
            {
                AddressablesUtil.Initialize();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

            try
            {
                Harmony = new Harmony("com.dredge.winch");
                Log.Debug("Created Harmony Instance 'com.dredge.winch'. Patching...");
                EarlyPatcher.Initialize(WinchCore.Harmony);
                Log.Debug("Early Harmony Patching complete.");
            }
            catch (Exception ex)
            {
                Log.Error($"Failed to apply early winch patches: {ex}");
            }
        }
    }
}
