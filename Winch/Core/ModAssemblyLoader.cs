using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Winch.Config;
using Winch.Util;

namespace Winch.Core;

public static class ModAssemblyLoader
{
    internal static Dictionary<string, ModAssembly> EnabledModAssemblies = new();
    private static Dictionary<string, ModAssembly> _installedAssemblies = new();
    internal static Dictionary<string, bool> EnabledMods = new();
    internal static List<string> LoadedMods = new();
    internal static List<string> ErrorMods = new();
    private static ModAssembly? forcedContext;

    static ModAssemblyLoader()
    {
        ModConfig.GetRelevantModName = GetCurrentModFolderName;
    }

    internal static void LoadModAssemblies()
    {
        if (!Directory.Exists(Paths.ModsPath))
        {
            Directory.CreateDirectory(Paths.ModsPath);
        }

        string[] modDirs = Directory.GetDirectories(Paths.ModsPath);
        WinchCore.Log.Info($"Loading {modDirs.Length} mod assemblies...");
        foreach (string modDir in modDirs)
        {
            RegisterModAssembly(modDir);
        }

        PopulateEnabledMods();

        EnabledModAssemblies = EnabledMods == null ? _installedAssemblies
            : _installedAssemblies.Where(x => EnabledMods[x.Value.GUID])
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

    internal static bool ExecuteModAssembly(string modName, string? minVersion = null)
    {
        if (ErrorMods.Contains(modName))
            return false;

        if (LoadedMods.Contains(modName))
            return true;

        if (!EnabledModAssemblies.ContainsKey(modName))
        {
            ErrorMods.Add(modName);
            WinchCore.Log.Error($"Mod not loaded: {modName}");
            return false;
        }

        if(minVersion != null)
        {
            if (!VersionUtil.IsSameOrNewer(EnabledModAssemblies[modName].Version, minVersion))
                throw new Exception($"Cannot satisfy minimum version constraint {minVersion} for {modName}");
        }

        var modGUID = EnabledModAssemblies[modName].GUID;
        if (!EnabledMods[modGUID])
        {
            WinchCore.Log.Info($"Mod '{modName}' disabled.");
            return false;
        }

        ModAssemblyLoader.ForceModContext(EnabledModAssemblies[modName]);
        var worked = false;
        try
        {
            EnabledModAssemblies[modName].ExecuteAssembly();
            LoadedMods.Add(modName);
            WinchCore.Log.Info($"Successfully initialized {modName}.");
            worked = true;
        }
        catch(Exception ex)
        {
            ErrorMods.Add(modName);
            WinchCore.Log.Error($"Error initializing {modName}: {ex}");
        }
        ModAssemblyLoader.ClearModContext();
        return worked;
    }

    internal static void PopulateEnabledMods()
    {
        try
        {
            string modListPath = Path.Combine(Paths.WinchRootPath, "mod_list.json");

            if (File.Exists(modListPath))
            {
                string modList = File.ReadAllText(modListPath);
                EnabledMods = JsonConvert.DeserializeObject<Dictionary<string, bool>>(modList)
                              ?? throw new InvalidOperationException("Unable to parse mod_list.json file.");
            }

            foreach (string mod in _installedAssemblies.Keys)
            {
                string modGUID = _installedAssemblies[mod].GUID;
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
            EnabledMods = _installedAssemblies.ToDictionary(kvp => kvp.Key, kvp => true);
        }
    }

    /// <summary>
    /// Get an <see cref="ModAssembly"/> instance from a Mod GUID
    /// </summary>
    /// <param name="id">The ModGUID</param>
    /// <returns>The corresponding <see cref="ModAssembly"/>, or null</returns>
    internal static ModAssembly? GetMod(string id)
    {
        return _installedAssemblies.TryGetValue(id, out var mod) ? mod : null;
    }

    internal static Assembly[] GetAssemblies()
    {
        return _installedAssemblies.Values.Select(x => x.LoadedAssembly).WhereNotNull().ToArray();
    }

    internal static ModAssembly GetModForAssembly(Assembly a)
    {
        return _installedAssemblies.Values.FirstOrDefault((x) => x.LoadedAssembly != null && x.LoadedAssembly == a);
    }

    /// <summary>
    /// Check if a mod is enabled.
    /// </summary>
    /// <param name="modGUID">The GUID of the mod you are checking for.</param>
    /// <returns>Whether any enabled mod matches the given <paramref name="modGUID"/></returns>
    public static bool IsModEnabled(string modGUID)
    {
        return EnabledModAssemblies.ContainsKey(modGUID);
    }

    /// <summary>
    /// Gets the current executing mod as an <see cref="ModAssembly"/> instance
    /// </summary>
    /// <returns>The current executing mod</returns>
    public static ModAssembly GetCurrentMod()
    {
        if (forcedContext != null) return forcedContext;
        return ReflectionUtil.GetRelevantModAssembly();
    }

    internal static string GetCurrentModFolderName()
    {
        return GetCurrentMod()?.BasePathFolderName ?? string.Empty;
    }

    /// <summary>
    /// Forces a certain mod to be returned from <see cref="ModAssemblyLoader.GetCurrentMod"/>
    /// </summary>
    /// <param name="mod">The mod to be forced</param>
    internal static void ForceModContext(ModAssembly mod)
    {
        forcedContext = mod;
    }

    /// <summary>
    /// Clears the current mod context
    /// </summary>
    internal static void ClearModContext()
    {
        forcedContext = null;
    }
}
