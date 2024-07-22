using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Winch.Components;
using Winch.Core;
using Winch.Data.WorldEvent;
using Winch.Serialization.WorldEvent;

namespace Winch.Util;

public static class WorldEventUtil
{
    private static WorldEventDataConverter Converter = new WorldEventDataConverter();

    internal static bool PopulateWorldEventDataFromMetaWithConverter(ModdedWorldEventData worldEventData, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(worldEventData, meta, Converter);
    }

    internal static Dictionary<string, ModdedWorldEventData> ModdedWorldEventDataDict = new();
    internal static Dictionary<string, ModdedWorldEvent> ModdedWorldEventDict = new();

    public static ModdedWorldEventData GetModdedWorldEventData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedWorldEventDataDict.TryGetValue(id, out ModdedWorldEventData worldEventData))
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

    public static T RegisterModdedWorldEventType<T>(string id) where T : ModdedWorldEvent
    {
        T worldEvent = new GameObject(id).Prefabitize().AddComponent<T>();
        RegisterModdedWorldEvent<T>(id, worldEvent);
        return worldEvent;
    }

    public static void RegisterModdedWorldEvent<T>(string id, T worldEvent) where T : ModdedWorldEvent
    {
        WinchCore.Log.Debug($"Registering world event of type {typeof(T).FullName} for {id}");
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
            WinchCore.Log.Error($"Couldn't find data for world event \"{id}\"");
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
            WinchCore.Log.Error($"Couldn't create world event data");
            return;
        }
        var id = (string)meta["id"];
        if (ModdedWorldEventDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate world event data {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateWorldEventDataFromMetaWithConverter(worldEventData, meta))
        {
            ModdedWorldEventDataDict.Add(id, worldEventData);
        }
        else
        {
            WinchCore.Log.Error($"No world event data converter found");
        }
    }

    internal static void AddModdedWorldEvents(IList<WorldEventData> list)
    {
        foreach (var worldEventData in ModdedWorldEventDataDict.Values)
        {
            if (!worldEventData.isStatic)
                list.Add(worldEventData);
        }
    }

    internal static void CreateModdedStaticWorldEvents()
    {
        var staticWorldEvents = new GameObject("StaticWorldEvents").transform;
        foreach (var worldEventData in ModdedWorldEventDataDict.Values)
        {
            if (worldEventData.isStatic)
                worldEventData.prefab.Instantiate(worldEventData.location, Quaternion.identity, staticWorldEvents);
        }
    }
}