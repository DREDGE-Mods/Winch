using HarmonyLib;
using Winch.Data.Item;
using System.Reflection.Emit;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Winch.Patches.API
{
    [HarmonyPatch]
    internal static class TrawlNetPatcher
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(TrawlNetAbility), nameof(TrawlNetAbility.RefreshNetMode))]
        public static bool TrawlNetAbility_RefreshNetMode_Prefix(TrawlNetAbility __instance, SpatialItemData netData)
        {
            if (netData != null && netData is TrawlNetItemData trawlNetData)
            {
                __instance.trawlMode = trawlNetData.trawlMode;
                __instance.RefreshTrawlNetListeners();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Fix net relying on trawl mode. They would only check for the specific subtypes instead of everything.
        /// </summary>
        [HarmonyPrefix]
        [HarmonyPatch(typeof(TrawlNetAbility), nameof(TrawlNetAbility.RefreshNetFullness))]
        public static bool TrawlNetAbility_RefreshNetFullness_Prefix(TrawlNetAbility __instance)
        {
            Animator trawlNetAnimator = __instance.playerRef.BoatModelProxy.GetTrawlNetAnimator();
            trawlNetAnimator?.SetFloat("fullness", __instance.trawlNet.GetFillProportional());
            return false;
        }

        /// <summary>
        /// Fix net relying on trawl mode. lead to some weird image problems because it would make any net item with the <see cref="TrawlNetAbility.TrawlMode.TRAWL"/> into <see cref="FishItemInstance"/> even if they weren't fish.
        /// </summary>
        [HarmonyTranspiler]
        [HarmonyPatch(typeof(TrawlNetAbility), nameof(TrawlNetAbility.AddTrawlItem), new Type[0])]
        public static IEnumerable<CodeInstruction> TrawlNetAbility_AddTrawlItem_Prefix(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            var matcher = new CodeMatcher(instructions, generator).MatchStartForward(
                new CodeMatch(OpCodes.Ldarg_0),
                new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(TrawlNetAbility), nameof(TrawlNetAbility.trawlMode))),
                new CodeMatch(OpCodes.Ldc_I4_1),
                new CodeMatch(OpCodes.Bne_Un)
            );
            var start = matcher.Pos;
            var label = matcher.Start().MatchStartForward(
                new CodeMatch(OpCodes.Ldsfld, AccessTools.Field(typeof(GameManager), nameof(GameManager.Instance))),
                new CodeMatch(OpCodes.Callvirt, AccessTools.PropertyGetter(typeof(GameManager), nameof(GameManager.AudioPlayer)))
            );
            var end = label.Pos - 1;
            matcher.Start().RemoveInstructionsWithOffsets(start, end);
            matcher.Advance(start).Insert(
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Ldloc_S, 5),
                new CodeInstruction(OpCodes.Ldloc_S, 6),
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(WinchExtensions), nameof(WinchExtensions.PlaceTrawlItemAtGridPos)))
            );
            matcher.Start().MatchStartForward(
                new CodeMatch(OpCodes.Ldstr, "[TrawlNetAbility] AddTrawlItem() chosen item data could not be found")
            ).Advance(1).Insert(
                new CodeInstruction(OpCodes.Ldloc_S, 5),
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(TrawlNetPatcher), nameof(TrawlNetPatcher.AppendItemDataID)))
            );
            matcher.Start().MatchStartForward(
                new CodeMatch(OpCodes.Ldstr, "[TrawlNetAbility] AddTrawlItem() failed to find space for item")
            ).Advance(1).Insert(
                new CodeInstruction(OpCodes.Ldloc_S, 5),
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(TrawlNetPatcher), nameof(TrawlNetPatcher.AppendItemDataID)))
            );
            return matcher.InstructionEnumeration();
        }

        public static string AppendItemDataID(string original, HarvestableItemData harvestableItemData)
        {
            return original + " \"" + harvestableItemData.id + "\"";
        }
    }
}
