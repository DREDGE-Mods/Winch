using HarmonyLib;
using InControl.UnityDeviceProfiles;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using UnityEngine;
using Winch.Core;

namespace Winch.Patches.API;

[HarmonyPatch]
internal static class CrabPotPatcher
{
    [HarmonyTranspiler]
    [HarmonyPatch(typeof(GameSceneInitializer), nameof(GameSceneInitializer.CreatePlacedHarvestPOI))]
    public static IEnumerable<CodeInstruction> GameSceneInitializer_CreatePlacedHarvestPOI_Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var matcher = new CodeMatcher(instructions, generator);
            
        matcher.Start().MatchStartForward(
            new CodeMatch(OpCodes.Ldarg_0),
            new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(GameSceneInitializer), nameof(GameSceneInitializer.placedMaterialHHarvesterData))),
            new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(ItemData), nameof(ItemData.id)))
        );
        var start = matcher.Pos;
        var label = matcher.Start().MatchStartForward(
            new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(GameSceneInitializer), nameof(GameSceneInitializer.placedMaterialPOIPrefab))),
            new CodeMatch(OpCodes.Ldloc_1),
            new CodeMatch(OpCodes.Call, AccessTools.PropertyGetter(typeof(Quaternion), nameof(Quaternion.identity)))
        );
        var end = label.Pos;
        matcher.Start().RemoveInstructionsWithOffsets(start, end);
        matcher.Advance(start).Insert(
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldarg_1),
            new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(SerializedCrabPotPOIData), nameof(SerializedCrabPotPOIData.deployableItemId))),
            new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(WinchExtensions), nameof(WinchExtensions.GetPlacedHarvestPOIPrefabFromPotItemData), new System.Type[2] { typeof(GameSceneInitializer), typeof(string) }))
        );
        return matcher.InstructionEnumeration();
    }
}