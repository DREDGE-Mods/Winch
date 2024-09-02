using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using Winch.Components;
using Winch.Core;
using Winch.Data.WorldEvent;
using Winch.Serialization.WorldEvent;
using Winch.Serialization.WorldEvent.Condition;

namespace Winch.Util;

public static class WorldEventUtil
{
    private static WorldEventDataConverter Converter = new WorldEventDataConverter();
    private static StaticWorldEventDataConverter StaticConverter = new StaticWorldEventDataConverter();

    internal static bool PopulateWorldEventDataFromMetaWithConverter(ModdedWorldEventData worldEventData, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(worldEventData, meta, Converter);
    }

    internal static bool PopulateStaticWorldEventDataFromMetaWithConverter(StaticWorldEventData worldEventData, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(worldEventData, meta, StaticConverter);
    }

    internal static List<string> VanillaWorldEventIDList = new();

    internal static void Initialize()
    {
        Addressables.LoadAssetsAsync<WorldEventData>(AddressablesUtil.GetLocations<WorldEventData>("WorldEventData"), worldEventData => VanillaWorldEventIDList.SafeAdd(worldEventData.name));
    }

    internal static Dictionary<string, WorldEventData> AllWorldEventDataDict = new();
    internal static Dictionary<string, ModdedWorldEventData> ModdedWorldEventDataDict = new();
    internal static Dictionary<string, StaticWorldEventData> ModdedStaticWorldEventDataDict = new();
    internal static Dictionary<string, ModdedWorldEvent> ModdedWorldEventDict = new();
    internal static Dictionary<string, StaticWorldEvent> ModdedStaticWorldEventDict = new();

    public static ModdedWorldEventData GetModdedWorldEventData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedWorldEventDataDict.TryGetValue(id, out ModdedWorldEventData worldEventData))
            return worldEventData;
        else
            return null;
    }

    public static StaticWorldEventData GetModdedStaticWorldEventData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedStaticWorldEventDataDict.TryGetValue(id, out StaticWorldEventData worldEventData))
            return worldEventData;
        else
            return null;
    }

    public static ModdedWorldEvent GetModdedWorldEvent(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedWorldEventDict.TryGetValue(id, out ModdedWorldEvent worldEvent))
            return worldEvent;
        else
            return null;
    }

    public static StaticWorldEvent GetModdedStaticWorldEvent(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedStaticWorldEventDict.TryGetValue(id, out StaticWorldEvent worldEvent))
            return worldEvent;
        else
            return null;
    }

    public static T RegisterModdedWorldEventType<T>(string id) where T : ModdedWorldEvent
    {
        T worldEvent = new GameObject(id).Prefabitize().AddComponent<T>();
        RegisterModdedWorldEvent<T>(id, worldEvent);
        return worldEvent;
    }

    public static void RegisterModdedWorldEvent<T>(string id, T worldEvent) where T : ModdedWorldEvent
    {
        WinchCore.Log.Debug($"Registering dynamic world event of type {typeof(T).FullName} for {id}");
        worldEvent.id = id;
        worldEvent.gameObject.Prefabitize();
        ModdedWorldEventDict.SafeAdd(id, worldEvent);

        var data = GetModdedWorldEventData(id);
        if (data != null)
        {
            worldEvent.worldEventData = data;
            data.prefab = worldEvent.gameObject;
        }
        else
            WinchCore.Log.Error($"Couldn't find data for dynamic world event \"{id}\"");
    }

    public static T RegisterModdedStaticWorldEventType<T>(string id) where T : StaticWorldEvent
    {
        T worldEvent = new GameObject(id).Prefabitize().AddComponent<T>();
        RegisterModdedStaticWorldEvent<T>(id, worldEvent);
        return worldEvent;
    }

    public static void RegisterModdedStaticWorldEvent<T>(string id, T worldEvent) where T : StaticWorldEvent
    {
        WinchCore.Log.Debug($"Registering static world event of type {typeof(T).FullName} for {id}");
        worldEvent.id = id;
        worldEvent.gameObject.Prefabitize();
        ModdedStaticWorldEventDict.SafeAdd(id, worldEvent);

        var data = GetModdedStaticWorldEventData(id);
        if (data != null)
        {
            data.prefab = worldEvent.gameObject;
        }
        else
            WinchCore.Log.Error($"Couldn't find data for static world event \"{id}\"");
    }

    internal static void AddCustomWorldEventDataFromMeta(string metaPath)
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }
        var worldEventData = UtilHelpers.GetScriptableObjectFromMeta<ModdedWorldEventData>(meta, metaPath);
        if (worldEventData == null)
        {
            WinchCore.Log.Error($"Couldn't create dynamic world event data");
            return;
        }
        var id = (string)meta["id"];
        if (VanillaWorldEventIDList.Contains(id))
        {
            WinchCore.Log.Error($"Dynamic world event data {id} already exists in vanilla.");
            return;
        }
        if (ModdedWorldEventDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate dynamic world event data {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateWorldEventDataFromMetaWithConverter(worldEventData, meta))
        {
            ModdedWorldEventDataDict.Add(id, worldEventData);
            AddressablesUtil.AddResourceAtLocation("WorldEventData", id, id, worldEventData);
        }
        else
        {
            WinchCore.Log.Error($"No dynamic world event data converter found");
        }
    }

    internal static void AddCustomStaticWorldEventDataFromMeta(string metaPath)
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }
        var worldEventData = UtilHelpers.GetScriptableObjectFromMeta<StaticWorldEventData>(meta, metaPath);
        if (worldEventData == null)
        {
            WinchCore.Log.Error($"Couldn't create static world event data");
            return;
        }
        var id = (string)meta["id"];
        if (ModdedStaticWorldEventDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate static world event data {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateStaticWorldEventDataFromMetaWithConverter(worldEventData, meta))
        {
            ModdedStaticWorldEventDataDict.Add(id, worldEventData);
        }
        else
        {
            WinchCore.Log.Error($"No static world event data converter found");
        }
    }

    internal static void AddModdedWorldEvents(IList<WorldEventData> list)
    {
        foreach (var worldEventData in ModdedWorldEventDataDict.Values)
        {
            list.SafeAdd(worldEventData);
        }
    }

    internal static void CreateModdedStaticWorldEvents()
    {
        var staticWorldEvents = new GameObject("StaticWorldEvents").transform;
        foreach (var worldEventData in ModdedStaticWorldEventDataDict.Values)
        {
            worldEventData.prefab.Instantiate(worldEventData.location, Quaternion.identity, staticWorldEvents);
        }
    }

    internal static void PopulateWorldEvents(IList<WorldEventData> result)
    {
        foreach (var worldEvent in result)
        {
            AllWorldEventDataDict.SafeAdd(worldEvent.name, worldEvent);
            WinchCore.Log.Debug($"Added world event {worldEvent.name} to AllWorldEventDataDict");
        }
    }

    internal static void ClearWorldEventData()
    {
        AllWorldEventDataDict.Clear();
    }

    public static WorldEventData[] GetAllWorldEventData()
    {
        return AllWorldEventDataDict.Values.ToArray();
    }
}