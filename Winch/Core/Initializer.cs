using CommandTerminal;
using HarmonyLib;
using System;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;
using Winch.Config;
using Winch.Core.API;
using Winch.Patches;
using Winch.Util;
using static System.Net.WebRequestMethods;

namespace Winch.Core
{
    class Initializer
    {
        internal static void Initialize()
        {
            WinchCore.Log.Debug("Initializer started.");

			try
			{
				WinchCore.Harmony.PatchAll();
				EnumUtil.RegisterAllEnumHolders(Assembly.GetExecutingAssembly());
				WinchCore.Log.Debug("Late Harmony Patching complete.");
			}
			catch (Exception ex)
			{
				WinchCore.Log.Error($"Failed to apply late winch patches: {ex}");
			}

			foreach(ModAssembly modAssembly in ModAssemblyLoader.EnabledModAssemblies.Values)
			{
				try
				{
					if (modAssembly.LoadedAssembly != null)
					{
						EnumUtil.RegisterAllEnumHolders(modAssembly.LoadedAssembly);
					}
				}
				catch (Exception ex)
				{
					WinchCore.Log.Error($"Failed to register enum holders for {modAssembly.BasePath}: {ex}");
				}

				try
				{
					bool hasPatches = modAssembly.Metadata.ContainsKey("ApplyPatches") && (bool)modAssembly.Metadata["ApplyPatches"] == true;
					if (modAssembly.LoadedAssembly != null && hasPatches)
					{
						WinchCore.Log.Debug($"Patching from {modAssembly.LoadedAssembly.GetName().Name}...");
						new Harmony((string)modAssembly.Metadata["ModGUID"]).PatchAll(modAssembly.LoadedAssembly);
					}
				}
				catch(Exception ex)
				{
					WinchCore.Log.Error($"Failed to apply patches for {modAssembly.BasePath}: {ex}");
				}
			}

			try
			{
				InitializeAssetLoader();

				if (WinchConfig.GetProperty("EnableDeveloperConsole", false))
					InitializeDevConsole();

				DredgeEvent.TriggerManagersLoaded();
			}
			catch (Exception e)
			{
				WinchCore.Log.Error($"Failed to initialize mods {e}");
			}
        }

        internal static void InitializePostUnityLoad()
        {
            InitializeVersionLabel();
        }

        private static void InitializeAssetLoader()
        {
            GameObject assetLoader = new GameObject();
            assetLoader.AddComponent<AssetLoaderObject>();
            GameObject.DontDestroyOnLoad(assetLoader);
        }

        internal static void InitializeVersionLabel()
        {
            WinchCore.Log.Debug("Initializing Version Label...");

            string versionString = VersionUtil.GetVersion();
            GameManager.Instance.BuildInfo.BuildNumber += $"\nWinch {versionString}";

            int modsLoaded = ModAssemblyLoader.LoadedMods.Count;
            string modsLoadedString = $"{modsLoaded} Mod{(modsLoaded != 1 ? "s" : "")} loaded";
            GameManager.Instance.BuildInfo.BuildNumber += $"\n{modsLoadedString}";
        }

        private static void InitializeDevConsole()
        {
            WinchCore.Log.Debug("Initializing Developer Console...");
            GameObject term = new GameObject();
            term.AddComponent<Terminal>();
            UnityEngine.Object.DontDestroyOnLoad(term);
        }
    }
}
