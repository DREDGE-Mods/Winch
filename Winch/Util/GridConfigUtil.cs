using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using HarmonyLib;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using Winch.Core;
using Winch.Data;
using Winch.Serialization;
using Winch.Serialization.GridConfig;

namespace Winch.Util;

public static class GridConfigUtil
{
    private static CellGroupConfigConverter CellGroupConfigConverter = new CellGroupConfigConverter();
    private static GridConfigConverter GridConfigConverter = new GridConfigConverter();

    internal static bool PopulateGridConfigFromMetaWithConverter(DeferredGridConfiguration config, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(config, meta, GridConfigConverter);
    }

    internal static bool PopulateCellGroupConfigFromMetaWithConverter(UnstructedCellGroupConfiguration config, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(config, meta, CellGroupConfigConverter);
    }

    internal static List<string> VanillaGridConfigIDList = new();
    static GridConfigUtil()
    {
        Addressables.LoadAssetsAsync<GridConfiguration>(AddressablesUtil.GetLocations<GridConfiguration>("GridConfigData"), gridConfig => VanillaGridConfigIDList.SafeAdd(gridConfig.name));
    }

    internal static Dictionary<string, DeferredGridConfiguration> ModdedGridConfigDict = new();
    internal static Dictionary<string, GridConfiguration> AllGridConfigDict = new();

    public static GridConfiguration GetModdedGridConfiguration(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedGridConfigDict.TryGetValue(id, out DeferredGridConfiguration gridConfig))
            return gridConfig;
        else
            return null;
    }

    internal static void AddModdedGridConfigurations(IList<GridConfiguration> list)
    {
        foreach (var gridConfig in ModdedGridConfigDict.Values)
        {
            list.SafeAdd(gridConfig);
        }
    }

    internal static void PopulateGridConfigurations(IList<GridConfiguration> result)
    {
        foreach (var gridConfig in result)
        {
            AllGridConfigDict.Add(gridConfig.name, gridConfig);
            WinchCore.Log.Debug($"Added grid configuration {gridConfig.name} to AllGridConfigDict");
        }
    }

    internal static void ClearGridConfigurations()
    {
        AllGridConfigDict.Clear();
    }

    internal static void AddGridConfigFromMeta(string metaPath)
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }
        var gridConfig = UtilHelpers.GetScriptableObjectFromMeta<DeferredGridConfiguration>(meta, metaPath);
        if (gridConfig == null)
        {
            WinchCore.Log.Error($"Couldn't create GridConfiguration");
            return;
        }
        var id = (string)meta["id"];
        if (VanillaGridConfigIDList.Contains(id))
        {
            WinchCore.Log.Error($"Grid configuration {id} already exists in vanilla.");
            return;
        }
        if (ModdedGridConfigDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate grid configuration {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateGridConfigFromMetaWithConverter(gridConfig, meta))
        {
            ModdedGridConfigDict.Add(id, gridConfig);
            AddressablesUtil.AddResourceAtLocation("GridConfigData", id, id, gridConfig);
        }
        else
        {
            WinchCore.Log.Error($"No grid configuration converter found");
        }
    }

}
