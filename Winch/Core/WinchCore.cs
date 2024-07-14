using HarmonyLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Winch.Logging;
using Winch.Util;

namespace Winch.Core
{
	public class WinchCore
    {
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

            var harmony = new Harmony("com.dredge.winch");
            Log.Debug("Created Harmony Instance 'com.dredge.winch'. Patching...");
            harmony.PatchAll();

            foreach(ModAssembly modAssembly in ModAssemblyLoader.EnabledModAssemblies.Values)
            {
                try
                {
                    bool hasPatches = modAssembly.Metadata.ContainsKey("ApplyPatches") && (bool)modAssembly.Metadata["ApplyPatches"] == true;
                    if (modAssembly.LoadedAssembly != null && hasPatches)
                    {
                        Log.Debug($"Patching from {modAssembly.LoadedAssembly.GetName().Name}...");
                        new Harmony((string)modAssembly.Metadata["ModGUID"]).PatchAll(modAssembly.LoadedAssembly);
                    }
                }
                catch(Exception ex)
                {
                    Log.Error($"Failed to apply patches for {modAssembly.BasePath}: {ex}");
                }
            }

            Log.Debug("Harmony Patching complete.");
        }
    }
}
