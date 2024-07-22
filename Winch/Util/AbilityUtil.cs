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

    internal static Dictionary<string, ModdedAbilityData> ModdedAbilityDataDict = new();
    internal static Dictionary<string, Type> ModdedAbilityTypeDict = new();

    public static ModdedAbilityData GetModdedAbilityData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedAbilityDataDict.TryGetValue(id, out ModdedAbilityData abilityData))
            return abilityData;
        else
            return null;
    }

    public static Type GetModdedAbilityType(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedAbilityTypeDict.TryGetValue(id, out Type ability))
            return ability;
        else
            return null;
    }

    public static void RegisterModdedAbilityType<T>(string id) where T : ModdedAbility
    {
        ModdedAbilityTypeDict.SafeAdd(id, typeof(T));
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
        foreach (var kvp in ModdedAbilityTypeDict)
        {
            var id = kvp.Key;
            var abilityType = kvp.Value;
            var abilityObj = new GameObject(id);
            abilityObj.SetActive(false);
            abilityObj.transform.SetParent(parent, false);
            ModdedAbility ability = (ModdedAbility)abilityObj.AddComponent(abilityType);
            ability.id = id;
            ability.Register();
            abilityObj.SetActive(true);
        }
    }

    internal static int GetExtraAbilitiesCount(int existing)
    {
        return existing + ModdedAbilityDataDict.Count;
    }

    internal static void AddModdedAbilitiesToRadial(GameObject buttonCenter, Transform abiltiesParent, List<AbilityRadialWedge> wedges, Sprite lockedSprite)
    {
        foreach (var modAbilityData in ModdedAbilityDataDict.Values)
        {
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
        }
    }
}