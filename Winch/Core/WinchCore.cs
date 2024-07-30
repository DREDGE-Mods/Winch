using HarmonyLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Winch.Logging;
using Winch.Patches;
using Winch.Util;

namespace Winch.Core
{
    public class WinchCore
    {
        internal static Harmony Harmony;

        public static Logger Log = new Logger();

        public static Dictionary<string, object> WinchModConfig = new();

        public static string WinchInstallLocation => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static void Main()
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
			}
			catch (Exception e)
			{
				Log.Error(e);
			}

            string version = VersionUtil.GetVersion();
            Log.Info($"Winch {version} booting up...");

            ModAssemblyLoader.LoadModAssemblies();

            Harmony = new Harmony("com.dredge.winch");
            Log.Debug("Created Harmony Instance 'com.dredge.winch'. Patching...");
            try
            {
                EarlyPatcher.Initialize(WinchCore.Harmony);
                WinchCore.Log.Debug("Early Harmony Patching complete.");
            }
            catch (Exception ex)
            {
                WinchCore.Log.Error($"Failed to apply early winch patches: {ex}");
            }
        }
    }
}
