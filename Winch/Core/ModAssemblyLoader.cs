using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Winch.Util;

namespace Winch.Core
{
    class ModAssemblyLoader
    {
        public static Dictionary<string, ModAssembly> EnabledModAssemblies = new();
		private static Dictionary<string, ModAssembly> _installedAssemblies = new();
        public static Dictionary<string, bool> EnabledMods = new();
        public static List<string> LoadedMods = new();
        public static List<string> ErrorMods = new();

        internal static void LoadModAssemblies()
        {
            if (!Directory.Exists("Mods"))
			{
				Directory.CreateDirectory("Mods");
			}

            if (!Directory.Exists("Config"))
                Directory.CreateDirectory("Config");

            string[] modDirs = Directory.GetDirectories("Mods");
            WinchCore.Log.Info($"Loading {modDirs.Length} mod assemblies...");
            foreach (string modDir in modDirs)
			{
				RegisterModAssembly(modDir);
			}

			GetEnabledMods();

			EnabledModAssemblies = EnabledMods == null ? _installedAssemblies
				: _installedAssemblies.Where(x => EnabledMods[(string)x.Value.Metadata["ModGUID"]])
				.ToDictionary(x => x.Key, x => x.Value);
		}

        private static void RegisterModAssembly(string path)
        {
            string modName = Path.GetFileName(path);
            WinchCore.Log.Debug($"Loading '{modName}'...");
            try
            {
                ModAssembly mod = ModAssembly.FromPath(path);
                mod.LoadAssembly();
				_installedAssemblies.Add(modName, mod);
            }
            catch(Exception ex)
            {
                ErrorMods.Add(modName);
                WinchCore.Log.Error($"Error loading {modName}: {ex}");
            }
        }

        internal static void ExecuteModAssemblies()
        {
            foreach (string modName in EnabledModAssemblies.Keys)
                ExecuteModAssembly(modName);
        }

        internal static void ExecuteModAssembly(string modName, string? minVersion = null)
        {
            if (LoadedMods.Contains(modName) || ErrorMods.Contains(modName))
                return;

            if (!EnabledModAssemblies.ContainsKey(modName))
            {
                ErrorMods.Add(modName);
                WinchCore.Log.Error($"Mod not loaded: {modName}");
                return;
            }

            if(minVersion != null)
            {
                if (!VersionUtil.IsSameOrNewer(EnabledModAssemblies[modName].Metadata["Version"].ToString(), minVersion))
                    throw new Exception($"Cannot satisfy minimum version constraint {minVersion} for {modName}");
            }

            var modGUID = (string)EnabledModAssemblies[modName].Metadata["ModGUID"];
            if (!EnabledMods[modGUID])
            {
                WinchCore.Log.Info($"Mod '{modName}' disabled.");
                return;
            }

            try
            {
                EnabledModAssemblies[modName].ExecuteAssembly();
                LoadedMods.Add(modName);
                WinchCore.Log.Info($"Successfully initialized {modName}.");
            }
            catch(Exception ex)
            {
                ErrorMods.Add(modName);
                WinchCore.Log.Error($"Error initializing {modName}: {ex}");
            }
        }

        internal static void GetEnabledMods()
        {
			try
			{
				string modListPath = Path.Combine(Directory.GetCurrentDirectory(), "mod_list.json");

				if (File.Exists(modListPath))
				{
					string modList = File.ReadAllText(modListPath);
					EnabledMods = JsonConvert.DeserializeObject<Dictionary<string, bool>>(modList)
						?? throw new InvalidOperationException("Unable to parse mod_list.json file.");
				}

				foreach (string mod in _installedAssemblies.Keys)
				{
					string modGUID = (string)_installedAssemblies[mod].Metadata["ModGUID"];
					if (!EnabledMods.ContainsKey(modGUID))
					{
						EnabledMods.Add(modGUID, true);
					}
				}

				string serializedEnabledMods = JsonConvert.SerializeObject(EnabledMods, Formatting.Indented);
				File.WriteAllText(modListPath, serializedEnabledMods);
			}
			catch (Exception ex)
			{
				WinchCore.Log.Error($"Unable to parse mod_list.json file: {ex}");
				EnabledMods = null;
			}
        }
    }
}
