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
using Winch.Data.Dock;
using Winch.Serialization;
using Winch.Serialization.Dock;

namespace Winch.Util;

public static class DockUtil
{
    private static DockDataConverter DockDataConverter = new DockDataConverter();

    internal static bool PopulateDockDataFromMetaWithConverter(DeferredDockData data, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(data, meta, DockDataConverter);
    }

    internal static Dictionary<string, DeferredDockData> ModdedDockDataDict = new();
    internal static Dictionary<string, DockData> AllDockDataDict = new();

    public static DeferredDockData GetModdedDockData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedDockDataDict.TryGetValue(id, out DeferredDockData dockData))
            return dockData;
        else
            return null;
    }

    public static DockData GetDockData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (AllDockDataDict.TryGetValue(id, out var dock))
            return dock;

        if (ModdedDockDataDict.TryGetValue(id, out var moddedDock))
            return moddedDock;

        return null;
    }

    internal static void PopulateDockDatas()
    {
        foreach (var dockData in Resources.FindObjectsOfTypeAll<DockData>())
        {
            AllDockDataDict.Add(dockData.id, dockData);
            WinchCore.Log.Debug($"Added dock data \"{dockData.id}\" to AllDockDataDict");
        }
    }

    internal static void ClearDockDatas()
    {
        AllDockDataDict.Clear();
    }

    internal static void AddDockDataFromMeta(string metaPath)
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }
        var dockData = UtilHelpers.GetScriptableObjectFromMeta<DeferredDockData>(meta, metaPath);
        if (dockData == null)
        {
            WinchCore.Log.Error($"Couldn't create DockData");
            return;
        }
        var id = (string)meta["id"];
        if (ModdedDockDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate dock data {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateDockDataFromMetaWithConverter(dockData, meta))
        {
            ModdedDockDataDict.Add(id, dockData);
        }
        else
        {
            WinchCore.Log.Error($"No dock data converter found");
        }
    }

    public static DockData[] GetAllDockData()
    {
        return AllDockDataDict.Values.ToArray();
    }
}
