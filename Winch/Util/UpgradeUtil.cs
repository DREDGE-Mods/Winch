using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.AddressableAssets;
using Winch.Core;
using Winch.Data.Upgrade;
using Winch.Serialization;
using Winch.Serialization.Upgrade;

namespace Winch.Util;

public static class UpgradeUtil
{
    private static Dictionary<Type, IDredgeTypeConverter> Converters = new()
    {
        { typeof(DeferredHullUpgradeData), new HullUpgradeDataConverter() },
        { typeof(DeferredSlotUpgradeData), new SlotUpgradeDataConverter() },
        { typeof(DeferredUpgradeData), new UpgradeDataConverter() }
    };

    internal static bool PopulateObjectFromMetaWithConverters<T>(T item, Dictionary<string, object> meta) where T : UpgradeData, IDeferredUpgradeData
    {
        return UtilHelpers.PopulateObjectFromMeta<T>(item, meta, Converters);
    }

    internal static List<string> VanillaUpgradeIDList = new();

    internal static void Initialize()
    {
        Addressables.LoadAssetsAsync<UpgradeData>(AddressablesUtil.GetLocations<UpgradeData>("UpgradeData"),
            upgradeData =>
            {
                VanillaUpgradeIDList.SafeAdd(upgradeData.id);
                if (upgradeData.gridConfig != null) QuestUtil.VanillaQuestGridConfigIDList.SafeAdd(upgradeData.gridConfig.name);
            });
    }

    internal static Dictionary<string, UpgradeData> ModdedUpgradeDataDict = new();
    internal static Dictionary<string, UpgradeData> AllUpgradeDataDict = new();

    public static UpgradeData GetModdedUpgradeData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedUpgradeDataDict.TryGetValue(id, out UpgradeData upgradeData))
            return upgradeData;
        else
            return null;
    }

    public static UpgradeData GetUpgradeData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (AllUpgradeDataDict.TryGetValue(id, out var upgrade))
            return upgrade;

        if (ModdedUpgradeDataDict.TryGetValue(id, out var moddedUpgrade))
            return moddedUpgrade;

        return null;
    }

    internal static List<UpgradeData> TryGetUpgrades(List<string> ids)
    {
        List<UpgradeData> upgrades = new List<UpgradeData>();

        if (ids == null)
            return upgrades;

        foreach (var upgrade in ids)
        {
            if (!string.IsNullOrWhiteSpace(upgrade) && AllUpgradeDataDict.TryGetValue(upgrade, out var upgradeData))
            {
                upgrades.Add(upgradeData);
            }
        }

        return upgrades;
    }

    internal static void AddModdedUpgradeData(IList<UpgradeData> list)
    {
        foreach (var upgradeData in ModdedUpgradeDataDict.Values)
        {
            list.SafeAdd(upgradeData);
        }
    }

    internal static void PopulateUpgradeData(IList<UpgradeData> result)
    {
        foreach (var upgradeData in result)
        {
            AllUpgradeDataDict.SafeAdd(upgradeData.id, upgradeData);
            WinchCore.Log.Debug($"Added upgrade data {upgradeData.id} to AllUpgradeDataDict");
        }
        foreach (var upgradeData in ModdedUpgradeDataDict.Values.OfType<IDeferredUpgradeData>())
        {
            upgradeData.Populate();
        }
    }

    internal static void ClearUpgradeData()
    {
        AllUpgradeDataDict.Clear();
    }

    internal static void AddUpgradeDataFromMeta<T>(string metaPath) where T : UpgradeData, IDeferredUpgradeData
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }
        var upgradeData = UtilHelpers.GetScriptableObjectFromMeta<T>(meta, metaPath);
        if (upgradeData == null)
        {
            WinchCore.Log.Error($"Couldn't create UpgradeData");
            return;
        }
        var id = (string)meta["id"];
        if (VanillaUpgradeIDList.Contains(id))
        {
            WinchCore.Log.Error($"Upgrade {id} already exists in vanilla.");
            return;
        }
        if (ModdedUpgradeDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate upgrade data {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateObjectFromMetaWithConverters<T>(upgradeData, meta))
        {
            ModdedUpgradeDataDict.Add(id, upgradeData);
            AddressablesUtil.AddResourceAtLocation("UpgradeData", id, id, upgradeData);
        }
        else
        {
            WinchCore.Log.Error($"No upgrade data converter found");
        }
    }

    public static UpgradeData[] GetAllUpgradeData()
    {
        return AllUpgradeDataDict.Values.ToArray();
    }
}
