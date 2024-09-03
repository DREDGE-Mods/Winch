using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Winch.Components;
using Winch.Core;
using Winch.Data.Abilities;
using Winch.Serialization.Ability;

namespace Winch.Util;

public static class AbilityUtil
{
    private static AbilityDataConverter Converter = new AbilityDataConverter();

    internal static bool PopulateAbilityDataFromMetaWithConverter(ModdedAbilityData abilityData, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(abilityData, meta, Converter);
    }

    internal static Dictionary<string, AbilityData> AllAbilityDataDict = new();
    internal static Dictionary<string, ModdedAbilityData> ModdedAbilityDataDict = new();
    internal static Dictionary<string, ModdedAbility> ModdedAbilityDict = new();

    public static AbilityData GetAbilityData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (AllAbilityDataDict.TryGetValue(id, out AbilityData abilityData))
            return abilityData;

        if (ModdedAbilityDataDict.TryGetValue(id, out ModdedAbilityData moddedAbilityData))
            return moddedAbilityData;

        return null;
    }

    public static ModdedAbilityData GetModdedAbilityData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedAbilityDataDict.TryGetValue(id, out ModdedAbilityData abilityData))
            return abilityData;
        else
            return null;
    }

    public static ModdedAbility GetModdedAbility(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedAbilityDict.TryGetValue(id, out ModdedAbility ability))
            return ability;
        else
            return null;
    }

    public static T RegisterModdedAbilityType<T>(string id) where T : ModdedAbility
    {
        T ability = new GameObject(id).Prefabitize().AddComponent<T>();
        RegisterModdedAbility<T>(id, ability);
        return ability;
    }

    public static void RegisterModdedAbility<T>(string id, T ability) where T : ModdedAbility
    {
        WinchCore.Log.Debug($"Registering ability of type {typeof(T).FullName} for {id}");
        ability.id = id;
        ability.gameObject.Prefabitize();
        ModdedAbilityDict.SafeAdd(id, ability);

        var data = GetModdedAbilityData(id);
        if (data != null)
        {
            ability.abilityData = data;
        }
        else
            WinchCore.Log.Error($"Couldn't find data for ability \"{id}\"");
    }

    internal static void AddCustomAbilityDataFromMeta(string metaPath)
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }
        var abilityData = UtilHelpers.GetScriptableObjectFromMeta<ModdedAbilityData>(meta, metaPath);
        if (abilityData == null)
        {
            WinchCore.Log.Error($"Couldn't create ability data");
            return;
        }
        var id = (string)meta["id"];
        if (ModdedAbilityDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate ability data {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateAbilityDataFromMetaWithConverter(abilityData, meta))
        {
            ModdedAbilityDataDict.Add(id, abilityData);
        }
        else
        {
            WinchCore.Log.Error($"No ability data converter found");
        }
    }

    internal static void AddModdedAbilitiesToPlayer(Transform parent)
    {
        foreach (var ability in ModdedAbilityDict.Values)
        {
            WinchCore.Log.Debug($"Instantiating ability {ability.GetType().FullName} for {ability.ID}");
            var abilityObj = ability.gameObject.Instantiate(parent, false);
            var newAbility = abilityObj.GetComponent<ModdedAbility>();
            newAbility.Register();
            abilityObj.SetActive(true);
        }
    }

    internal static int GetExtraAbilitiesCount(int existing)
    {
        return existing + ModdedAbilityDataDict.Count;
    }

    internal static void AddModdedAbilitiesToManager(IDictionary<string, AbilityData> abilityDatas)
    {
        foreach (var modAbilityData in ModdedAbilityDataDict.Values)
        {
            WinchCore.Log.Debug($"Adding ability {modAbilityData.id} to manager");
            modAbilityData.Populate();
            abilityDatas.Add(modAbilityData.id, modAbilityData);
        }
        foreach (var abilityDataByKey in abilityDatas)
        {
            AllAbilityDataDict.Add(abilityDataByKey.Key, abilityDataByKey.Value);
            WinchCore.Log.Debug($"Added ability {abilityDataByKey.Key} to AllAbilityDataDict");
        }
    }

    internal static void Clear()
    {
        AllAbilityDataDict.Clear();
    }

    internal static void AddModdedAbilitiesToRadial(GameObject buttonCenter, Transform abiltiesParent, List<AbilityRadialWedge> wedges, Sprite lockedSprite)
    {
        var attentionCalloutPrefab = wedges.FirstOrDefault().attentionCallout;
        foreach (var modAbilityData in ModdedAbilityDataDict.Values)
        {
            WinchCore.Log.Debug($"Adding ability {modAbilityData.id} to radial");
            var abilityRadialWedgeObj = new GameObject(modAbilityData.id, typeof(RectTransform), typeof(Image));
            abilityRadialWedgeObj.transform.SetParent(abiltiesParent, false);
            var abilityRadialWedge = abilityRadialWedgeObj.AddComponent<AbilityRadialWedge>();
            abilityRadialWedge.abilityData = modAbilityData;
            var image = abilityRadialWedge.gameObject.GetComponent<Image>();
            image.sprite = modAbilityData.icon;
            abilityRadialWedge.image = image;
            abilityRadialWedge.index = wedges.Count;
            wedges.Add(abilityRadialWedge);
            abilityRadialWedge.radius = 200;
            abilityRadialWedge.lockedSprite = lockedSprite;
            abilityRadialWedge.buttonCenter = buttonCenter;
            abilityRadialWedge.attentionCallout = attentionCalloutPrefab.Instantiate(abilityRadialWedgeObj.transform, false);
        }
    }

    public static AbilityData[] GetAllAbilityData()
    {
        return AllAbilityDataDict.Values.ToArray();
    }
}