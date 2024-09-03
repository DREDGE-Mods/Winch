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
using Winch.Serialization.Vibration;

namespace Winch.Util;

public static class VibrationUtil
{
    private static VibrationDataConverter VibrationDataConverter = new VibrationDataConverter();

    internal static bool PopulateVibrationDataFromMetaWithConverter(VibrationData data, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(data, meta, VibrationDataConverter);
    }

    internal static Dictionary<string, VibrationData> ModdedVibrationDataDict = new();
    internal static Dictionary<string, VibrationData> AllVibrationDataDict = new();

    public static VibrationData GetModdedVibrationData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedVibrationDataDict.TryGetValue(id, out VibrationData vibrationData))
            return vibrationData;
        else
            return null;
    }

    public static VibrationData GetVibrationData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (AllVibrationDataDict.TryGetValue(id, out var vibration))
            return vibration;

        if (ModdedVibrationDataDict.TryGetValue(id, out var moddedVibration))
            return moddedVibration;

        return null;
    }

    internal static void PopulateVibrationDatas()
    {
        foreach (var vibrationData in Resources.FindObjectsOfTypeAll<VibrationData>())
        {
            AllVibrationDataDict.SafeAdd(vibrationData.name, vibrationData);
            WinchCore.Log.Debug($"Added vibration data {vibrationData.name} to AllVibrationDataDict");
        }
    }

    internal static void ClearVibrationDatas()
    {
        AllVibrationDataDict.Clear();
    }

    internal static void AddVibrationDataFromMeta(string metaPath)
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }
        var vibrationData = UtilHelpers.GetScriptableObjectFromMeta<VibrationData>(meta, metaPath);
        if (vibrationData == null)
        {
            WinchCore.Log.Error($"Couldn't create VibrationData");
            return;
        }
        var id = (string)meta["id"];
        if (ModdedVibrationDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate vibration data {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateVibrationDataFromMetaWithConverter(vibrationData, meta))
        {
            ModdedVibrationDataDict.Add(id, vibrationData);
        }
        else
        {
            WinchCore.Log.Error($"No vibration data converter found");
        }
    }

    public static VibrationData[] GetAllVibrationData()
    {
        return AllVibrationDataDict.Values.ToArray();
    }
}
