using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine.AddressableAssets;
using Winch.Core;
using Winch.Data.ConstructableBuilding;
using Winch.Serialization.ConstructableBuilding;

namespace Winch.Util;

public static class ConstructableBuildingUtil
{
    private static ConstructableBuildingDependencyDataConverter ConstructableBuildingDependencyDataConverter = new ConstructableBuildingDependencyDataConverter();

    internal static bool PopulateConstructableBuildingDependencyDataFromMetaWithConverter(DeferredConstructableBuildingDependencyData data, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(data, meta, ConstructableBuildingDependencyDataConverter);
    }

    internal static Dictionary<string, DeferredConstructableBuildingDependencyData> ModdedConstructableBuildingDependencyDataIdDict = new();
    internal static Dictionary<BuildingTierId, DeferredConstructableBuildingDependencyData> ModdedConstructableBuildingDependencyDataDict = new();
    internal static Dictionary<BuildingTierId, ConstructableBuildingDependencyData> AllConstructableBuildingDependencyDataDict = new();

    public static DeferredConstructableBuildingDependencyData GetModdedConstructableBuildingDependencyData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedConstructableBuildingDependencyDataIdDict.TryGetValue(id, out DeferredConstructableBuildingDependencyData constructableBuildingData))
            return constructableBuildingData;
        else
            return null;
    }

    public static DeferredConstructableBuildingDependencyData GetModdedConstructableBuildingDependencyData(BuildingTierId id)
    {
        if (id == BuildingTierId.NONE)
            return null;

        if (ModdedConstructableBuildingDependencyDataDict.TryGetValue(id, out DeferredConstructableBuildingDependencyData constructableBuildingData))
            return constructableBuildingData;
        else
            return null;
    }

    public static ConstructableBuildingDependencyData GetConstructableBuildingDependencyData(BuildingTierId id)
    {
        if (id == BuildingTierId.NONE)
            return null;

        if (AllConstructableBuildingDependencyDataDict.TryGetValue(id, out var constructableBuilding))
            return constructableBuilding;

        if (ModdedConstructableBuildingDependencyDataDict.TryGetValue(id, out var moddedConstructableBuilding))
            return moddedConstructableBuilding;

        return null;
    }

    internal static void AddModdedConstructableBuildingDependencyData(ConstructableBuildingDependencyConfig config)
    {
        foreach (var constructableBuildingData in ModdedConstructableBuildingDependencyDataDict.Values)
        {
            config.data.SafeAdd(constructableBuildingData);
            constructableBuildingData.Populate();
        }
    }

    internal static void PopulateConstructableBuildingDependencyData(ConstructableBuildingDependencyConfig config)
    {
        foreach (var constructableBuildingData in config.data)
        {
            AllConstructableBuildingDependencyDataDict.SafeAdd(constructableBuildingData.tierId, constructableBuildingData);
            WinchCore.Log.Debug($"Added constructable building dependency data {constructableBuildingData.tierId} to AllConstructableBuildingDependencyDataDict");
        }
    }

    internal static void Clear()
    {
        AllConstructableBuildingDependencyDataDict.Clear();
    }

    public static bool IsTierImmediate(BuildingTierId tierId)
    {
        var constructableBuildingDependencyData = GetConstructableBuildingDependencyData(tierId);
        if (constructableBuildingDependencyData == null) return true;
        return IsBuildingImmediate(constructableBuildingDependencyData);
    }

    public static bool IsBuildingImmediate(this ConstructableBuildingDependencyData constructableBuildingDependencyData)
    {
        return constructableBuildingDependencyData is ImmediateConstructableBuildingDependencyData immediateBuilding && immediateBuilding.immediate;
    }

    internal static void AddConstructableBuildingDependencyDataFromMeta(string metaPath)
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }
        string id = Path.GetFileNameWithoutExtension(metaPath);
        meta["id"] = id;
        var constructableBuildingData = new DeferredConstructableBuildingDependencyData();
        if (ModdedConstructableBuildingDependencyDataIdDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate constructable building dependency data {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateConstructableBuildingDependencyDataFromMetaWithConverter(constructableBuildingData, meta))
        {
            if (constructableBuildingData.tierId == BuildingTierId.NONE)
            {
                WinchCore.Log.Error("No tierId specified for " + constructableBuildingData.id);
                return;
            }
            ModdedConstructableBuildingDependencyDataIdDict.Add(id, constructableBuildingData);
            ModdedConstructableBuildingDependencyDataDict.Add(constructableBuildingData.tierId, constructableBuildingData);
        }
        else
        {
            WinchCore.Log.Error($"No constructable building dependency data converter found");
        }
    }

    public static ConstructableBuildingDependencyData[] GetAllConstructableBuildingDependencyData()
    {
        return AllConstructableBuildingDependencyDataDict.Values.ToArray();
    }
}
