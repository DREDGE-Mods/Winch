using System.Collections.Generic;
using System.Linq;
using UnityEngine.AddressableAssets;
using Winch.Core;
using Winch.Data.GridConfig;
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
    internal static Dictionary<GridKey, string> VanillaGridKeyDict = new();

    internal static void Initialize()
    {
        Addressables.LoadAssetsAsync<GridConfiguration>(AddressablesUtil.GetLocations<GridConfiguration>("GridConfigData"),
             gridConfig => VanillaGridConfigIDList.SafeAdd(gridConfig.name));
        GameManager.Instance.GameConfigData.gridConfigs.AddOrChange(GridKeyExtra.UPGRADE_T1_HULL, GameManager.Instance.GameConfigData.hullTierGridConfigs[0]);
        GameManager.Instance.GameConfigData.gridConfigs.ForEach(kvp =>
        {
            VanillaGridConfigIDList.Add(kvp.Value.name);
            VanillaGridKeyDict.Add(kvp.Key, kvp.Value.name);
        });
    }

    internal static Dictionary<string, DeferredGridConfiguration> ModdedGridConfigDict = new();
    internal static Dictionary<string, GridConfiguration> AllGridConfigDict = new();

    public static GridConfiguration GetGridConfiguration(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (AllGridConfigDict.TryGetValue(id, out GridConfiguration gridConfig))
            return gridConfig;

        if (ModdedGridConfigDict.TryGetValue(id, out DeferredGridConfiguration deferredGridConfig))
            return deferredGridConfig;

        return null;
    }

    public static GridConfiguration GetGridConfiguration(GridKey gridKey)
    {
        if (gridKey == GridKey.NONE)
            return null;

        if (GameManager.Instance.GameConfigData.gridConfigs.TryGetValue(gridKey, out GridConfiguration gridConfig))
            return gridConfig;

        return null;
    }

    public static DeferredGridConfiguration GetModdedGridConfiguration(string id)
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

    internal static void PopulateGridConfiguration(GridConfiguration gridConfig)
    {
        AllGridConfigDict.SafeAdd(gridConfig.name, gridConfig);
        WinchCore.Log.Debug($"Added grid configuration {gridConfig.name} to AllGridConfigDict");
    }

    internal static void PopulateGridConfigurations(IList<GridConfiguration> result)
    {
        foreach (var gridConfig in result)
        {
            PopulateGridConfiguration(gridConfig);
        }
        foreach (var gridConfig in GameManager.Instance.GameConfigData.gridConfigs.Values.Where(gridConfig => gridConfig != null && !AllGridConfigDict.ContainsKey(gridConfig.name)))
        {
            PopulateGridConfiguration(gridConfig);
        }
        FixGridConfigurations();
    }

    internal static void FixGridConfigurations()
    {
        // Change grid configurations to the addressable ones
        foreach (var kvp in GameManager.Instance.GameConfigData.gridConfigs.Where(kvp => VanillaGridKeyDict.ContainsKey(kvp.Key) && (kvp.Value == null || (kvp.Value != null && AllGridConfigDict.ContainsKey(kvp.Value.name)))).ToArray())
            GameManager.Instance.GameConfigData.gridConfigs.AddOrChange(kvp.Key, AllGridConfigDict[VanillaGridKeyDict[kvp.Key]]);
        GameManager.Instance.GameConfigData.hullTierGridConfigs[0] = GameManager.Instance.GameConfigData.gridConfigs[GridKeyExtra.UPGRADE_T1_HULL];
        GameManager.Instance.GameConfigData.hullTierGridConfigs[1] = GameManager.Instance.GameConfigData.gridConfigs[GridKey.UPGRADE_T2_HULL];
        GameManager.Instance.GameConfigData.hullTierGridConfigs[2] = GameManager.Instance.GameConfigData.gridConfigs[GridKey.UPGRADE_T3_HULL];
        GameManager.Instance.GameConfigData.hullTierGridConfigs[3] = GameManager.Instance.GameConfigData.gridConfigs[GridKey.UPGRADE_T4_HULL];
        GameManager.Instance.GameConfigData.hullTierGridConfigs[4] = GameManager.Instance.GameConfigData.gridConfigs[GridKey.UPGRADE_T5_HULL];
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
            if (gridConfig.gridKey != GridKey.NONE) GameManager.Instance.GameConfigData.gridConfigs.SafeAdd(gridConfig.gridKey, gridConfig);
        }
        else
        {
            WinchCore.Log.Error($"No grid configuration converter found");
        }
    }

    public static GridConfiguration[] GetAllGridConfigs()
    {
        return AllGridConfigDict.Values.ToArray();
    }
}
