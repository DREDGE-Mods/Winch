using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch]
internal static class AbilityPatcher
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(PlayerAbilityManager), nameof(PlayerAbilityManager.Awake))]
    public static void PlayerAbilityManager_Awake_Prefix(PlayerAbilityManager __instance, out IDictionary<string, AbilityData> __state)
    {
        __state = __instance.abilityDatas.ToDictionary(data => data.name, data => data);
        AbilityUtil.AddModdedAbilitiesToManager(__state);
        DredgeEvent.AddressableEvents.AbilitiesLoaded.Trigger(__instance, __state, true);
        __instance.abilityDatas = __state.Values.ToList();
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(PlayerAbilityManager), nameof(PlayerAbilityManager.Awake))]
    public static void PlayerAbilityManager_Awake_Postfix(PlayerAbilityManager __instance, IDictionary<string, AbilityData> __state)
    {
        DredgeEvent.AddressableEvents.AbilitiesLoaded.Trigger(__instance, __state, false);
        __instance.abilityDatas = __state.Values.ToList();
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(AbilityRadial), nameof(AbilityRadial.Awake))]
    public static void AbilityRadial_Awake_Prefix(AbilityRadial __instance)
    {
        GameObject buttonCenter = __instance.transform.GetChild(0).gameObject;
        Transform abiltiesParent = buttonCenter.transform.Find("Abilities");
        List<AbilityRadialWedge> wedges = __instance.abilityWedges;
        Sprite lockedSprite = __instance.abilityWedges.FirstOrDefault().lockedSprite;
        AbilityUtil.AddModdedAbilitiesToRadial(buttonCenter, abiltiesParent, wedges, lockedSprite);
    }

    [HarmonyTranspiler]
    [HarmonyPatch(typeof(AbilityRadial), nameof(AbilityRadial.Awake))]
    public static IEnumerable<CodeInstruction> AbilityRadial_Awake_Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        foreach (var code in instructions)
        {
            if (code.StoresField(AccessTools.Field(typeof(AbilityRadial), "numAbilitiesEnabled")))
            {
                yield return new CodeInstruction(OpCodes.Call,
                    AccessTools.Method(typeof(AbilityUtil), nameof(AbilityUtil.GetExtraAbilitiesCount)));
                yield return code;
                //before any time its stored, add the number of custom abilities
            }
            else
            {
                yield return code;
            }
        }
    }
}
