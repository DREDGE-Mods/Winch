using System.Collections.Generic;
using System.Linq;
using UnityEngine;
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

    internal static void CreateTier1()
    {
        if (!GameManager.Instance.GameConfigData.gridConfigs.ContainsKey(GridKeyExtra.UPGRADE_T1_HULL))
        {
            var tier1 = ScriptableObject.CreateInstance<GridConfiguration>().Rename("Tier1HullInput").DontDestroyOnLoad();
            tier1.mainItemType = ItemType.GENERAL;
            tier1.mainItemSubtype = ItemSubtype.MATERIAL;
            tier1.canAddItemsInQuestMode = true;
            tier1.itemsInThisBelongToPlayer = true;
            GameManager.Instance.GameConfigData.gridConfigs.Add(GridKeyExtra.UPGRADE_T1_HULL, tier1);
        }
    }

    internal static void SpecialVanillaGridHandler(GridKey key, GridConfiguration value)
    {
        switch (key)
        {
            case GridKey.UPGRADE_T2_HULL:
            case GridKey.UPGRADE_T3_HULL:
            case GridKey.UPGRADE_T4_HULL:
            case GridKey.UPGRADE_T5_HULL:
                value.name += "Input";
                break;
        }
    }

    internal static void Initialize()
    {
        Addressables.LoadAssetsAsync<GridConfiguration>(AddressablesUtil.GetLocations<GridConfiguration>("GridConfigData"),
             gridConfig => VanillaGridConfigIDList.SafeAdd(gridConfig.name));

        GameManager.Instance.GameConfigData.hullTierGridConfigs.ForEach(
             gridConfig => VanillaGridConfigIDList.SafeAdd(gridConfig.name));

        CreateTier1();

        GameManager.Instance.GameConfigData.gridConfigs.ForEach(kvp =>
        {
            SpecialVanillaGridHandler(kvp.Key, kvp.Value);
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

    public static bool TryGetGridConfiguration(GridKey gridKey, out GridConfiguration gridConfig)
    {
        gridConfig = null;
        if (gridKey == GridKey.NONE)
            return false;

        if (GameManager.Instance.GameConfigData.gridConfigs.TryGetValue(gridKey, out gridConfig))
            return true;

        return false;
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
            if (gridConfig.cellGroupConfigs != null && gridConfig.cellGroupConfigs.Count > 0)
            {
                var cells = gridConfig.cellGroupConfigs.SelectMany(cgc => cgc.cells).ToList();
                if (cells.Count > 0)
                {
                    var errored = false;

                    var cellColumns = cells.GetWidth();
                    var cellRows = cells.GetHeight();

                    if (cellColumns > gridConfig.columns)
                    {
                        errored = true;
                        WinchCore.Log.Error($"Grid configuration {id} at {metaPath} failed to load!\nHorizontal cell count in one of the cell group configs is greater than the grid config's columns.");
                    }
                    if (cellRows > gridConfig.rows)
                    {
                        errored = true;
                        WinchCore.Log.Error($"Grid configuration {id} at {metaPath} failed to load!\nVertical cell count in one of the cell group configs is greater than the grid config's rows.");
                    }

                    if (errored) return;
                }
            }

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
