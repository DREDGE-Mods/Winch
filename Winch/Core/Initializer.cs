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

namespace Winch.Core;

class Initializer
{
	internal static void Initialize()
	{
		WinchCore.Log.Debug("Initializer started.");

		// Any unity methods like "Awake" and etc. require patching later (here) or else game explodes for whatever reason. Even just touching the method slightly makes the loading screen go black and spam the error below.
		// I assume it is because where we originally patch is before unity native dlls load or something.
		/*
		System.MissingMethodException:  assembly:<unknown assembly> type:<unknown type> member:(null)
		 at (wrapper managed-to-native) UnityEngine.Component.get_gameObject()
		 at UnityEngine.UI.Graphic.CacheCanvas()[0x00006]
		 at UnityEngine.UI.Graphic.get_canvas() [0x0000e]
		 at Coffee.UIExtensions.UIParticleUpdater.Refresh(Coffee.UIExtensions.UIParticle particle) [0x00015]
		 at Coffee.UIExtensions.UIParticleUpdater.Refresh() [0x00027]
		*/
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
			ModAssemblyLoader.ForceModContext(modAssembly);

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
				bool hasPatches = modAssembly.ApplyPatches;
				if (modAssembly.LoadedAssembly != null && hasPatches)
				{
					WinchCore.Log.Debug($"Patching from {modAssembly.LoadedAssembly.GetName().Name}...");
					new Harmony(modAssembly.GUID).PatchAll(modAssembly.LoadedAssembly);
				}
			}
			catch(Exception ex)
			{
				WinchCore.Log.Error($"Failed to apply patches for {modAssembly.BasePath}: {ex}");
			}

			ModAssemblyLoader.ClearModContext();
		}

		try
		{
			InitializeAssetLoader();

			/*if (WinchConfig.GetProperty("EnableDeveloperConsole", false))
				InitializeDevConsole();*/

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
		UnityEngine.Object.DontDestroyOnLoad(new GameObject("AssetLoader", typeof(AssetLoaderObject)));
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
		UnityEngine.Object.DontDestroyOnLoad(new GameObject("DeveloperConsole", typeof(Terminal)));
	}
}