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
using Winch.Serialization;
using Winch.Serialization.GridConfig;

namespace Winch.Util;

internal static class GridConfigUtil
{
    private static CellGroupConfigConverter CellGroupConfigConverter = new CellGroupConfigConverter();
    private static GridConfigConverter GridConfigConverter = new GridConfigConverter();

    public static bool PopulateGridConfigFromMetaWithConverter(GridConfiguration config, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(config, meta, GridConfigConverter);
    }

    public static bool PopulateCellGroupConfigFromMetaWithConverter(UnstructedCellGroupConfiguration config, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(config, meta, CellGroupConfigConverter);
    }

    public static Dictionary<string, GridConfiguration> ModdedGridConfigDict = new();
    public static Dictionary<string, GridConfiguration> AllGridConfigDict = new();

    public static void AddModdedGridConfigurations()
    {
        foreach (var gridConfig in ModdedGridConfigDict)
        {
            GameManager.Instance.DataLoader.allGridConfigs.Add(gridConfig.Key, gridConfig.Value);
        }
    }

    public static void AddModdedGridConfigurations(IList<GridConfiguration> list)
    {
        foreach (var gridConfig in ModdedGridConfigDict.Values)
        {
            list.Add(gridConfig);
        }
    }

    public static void PopulateGridConfigurations()
    {
        foreach (var gridConfig in GameManager.Instance.DataLoader.allGridConfigs)
        {
            AllGridConfigDict.Add(gridConfig.Key, gridConfig.Value);
            WinchCore.Log.Debug($"Added grid configuration {gridConfig.Key} to AllGridConfigDict");
        }
    }

    public static void ClearGridConfigurations()
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
        var gridConfig = UtilHelpers.GetScriptableObjectFromMeta<GridConfiguration>(meta, metaPath);
        if (gridConfig == null)
        {
            WinchCore.Log.Error($"Couldn't create GridConfiguration");
            return;
        }
        var id = (string)meta["id"];
        if (ModdedGridConfigDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate poi {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateGridConfigFromMetaWithConverter(gridConfig, meta))
        {
            ModdedGridConfigDict.Add(id, gridConfig);
        }
        else
        {
            WinchCore.Log.Error($"No grid configuration converter found");
        }
    }

}
