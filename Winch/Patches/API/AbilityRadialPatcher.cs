using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using Winch.Util;

namespace Winch.Patches.API
{
    /// <summary>
    /// See <see cref="LatePatcher.Initialize"/> for details on why this doesn't have attributes
    /// </summary>
    internal static class AbilityRadialPatcher
    {
        public static void Prefix(AbilityRadial __instance)
        {
            GameObject buttonCenter = __instance.transform.GetChild(0).gameObject;
            Transform abiltiesParent = buttonCenter.transform.Find("Abilities");
            List<AbilityRadialWedge> wedges = __instance.abilityWedges;
            Sprite lockedSprite = __instance.abilityWedges.FirstOrDefault().lockedSprite;
            AbilityUtil.AddModdedAbilitiesToRadial(buttonCenter, abiltiesParent, wedges, lockedSprite);
        }

        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
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
}