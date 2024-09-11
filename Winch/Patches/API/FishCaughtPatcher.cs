using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using Winch.Core.API;

namespace Winch.Patches.API;

[HarmonyPatch]
internal static class FishCaughtPatcher
{
    [HarmonyTranspiler]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(typeof(DredgeDialogueRunner), nameof(DredgeDialogueRunner.DebugCatch))]
    public static IEnumerable<CodeInstruction> DredgeDialogueRunner_DebugCatch_Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var matcher = new CodeMatcher(instructions, generator);

        matcher.MatchEndForward(
            new CodeMatch(OpCodes.Ldsfld, AccessTools.Field(typeof(GameEvents), nameof(GameEvents.Instance))),
            new CodeMatch(OpCodes.Callvirt, AccessTools.Method(typeof(GameEvents), nameof(GameEvents.TriggerFishCaught)))
        ).RemoveInstruction().Insert(new CodeInstruction(OpCodes.Ldloc_S, 5), new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(WinchExtensions), nameof(WinchExtensions.TriggerFishCaught))));

        return matcher.InstructionEnumeration();
    }

    [HarmonyTranspiler]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(typeof(HarvestMinigameView), nameof(HarvestMinigameView.SpawnItem))]
    public static IEnumerable<CodeInstruction> HarvestMinigameView_SpawnItem_Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var matcher = new CodeMatcher(instructions, generator);

        matcher.MatchEndForward(
            new CodeMatch(OpCodes.Ldsfld, AccessTools.Field(typeof(GameEvents), nameof(GameEvents.Instance))),
            new CodeMatch(OpCodes.Callvirt, AccessTools.Method(typeof(GameEvents), nameof(GameEvents.TriggerFishCaught)))
        ).RemoveInstruction().Insert(
            new CodeInstruction(OpCodes.Ldloc_1),
            new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(WinchExtensions), nameof(WinchExtensions.TriggerFishCaught))),

            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(HarvestMinigameView), nameof(HarvestMinigameView.currentPOI))),
            new CodeInstruction(OpCodes.Ldloc_1),
            new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(DredgeEvent), nameof(DredgeEvent.TriggerPOIHarvested)))
        );

        return matcher.InstructionEnumeration();
    }

    public static void OnGridFishesCaught(SerializableGrid grid)
    {
        GameEvents.Instance.TriggerFishCaught();
        grid.spatialItems.ForEach(itemInstance =>
        {
            if (!itemInstance.seen && itemInstance is FishItemInstance fishItemInstance)
            {
                DredgeEvent.TriggerFishCaught(fishItemInstance);
            }
        });
    }

    public static void OnCrabPotCaught(SerializedCrabPotPOIData placedPOIData)
        => OnGridFishesCaught(placedPOIData.grid);

    [HarmonyTranspiler]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(typeof(OccasionalGridPanel), nameof(OccasionalGridPanel.Show))]
    public static IEnumerable<CodeInstruction> OccasionalGridPanel_Show_Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var matcher = new CodeMatcher(instructions, generator);

        matcher.MatchStartForward(
            new CodeMatch(OpCodes.Ldsfld, AccessTools.Field(typeof(GameEvents), nameof(GameEvents.Instance))),
            new CodeMatch(OpCodes.Callvirt, AccessTools.Method(typeof(GameEvents), nameof(GameEvents.TriggerFishCaught)))
        ).RemoveInstructions(2).Start().MatchStartForward(
            new CodeMatch(OpCodes.Ldarg_0),
            new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(OccasionalGridPanel), nameof(OccasionalGridPanel.slidePanel)))
        ).Insert(
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(OccasionalGridPanel), nameof(OccasionalGridPanel.placedPOIData))),
            new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(FishCaughtPatcher), nameof(OnCrabPotCaught))));

        return matcher.InstructionEnumeration();
    }

    [HarmonyTranspiler]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(typeof(QuickHarvestGridPanel), nameof(QuickHarvestGridPanel.Show))]
    public static IEnumerable<CodeInstruction> QuickHarvestGridPanel_Show_Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var matcher = new CodeMatcher(instructions, generator);

        matcher.MatchStartForward(
            new CodeMatch(OpCodes.Ldsfld, AccessTools.Field(typeof(GameEvents), nameof(GameEvents.Instance))),
            new CodeMatch(OpCodes.Callvirt, AccessTools.Method(typeof(GameEvents), nameof(GameEvents.TriggerFishCaught)))
        ).RemoveInstructions(2).Start().MatchStartForward(
            new CodeMatch(OpCodes.Ldarg_0),
            new CodeMatch(OpCodes.Ldfld, AccessTools.Field(typeof(QuickHarvestGridPanel), nameof(QuickHarvestGridPanel.slidePanel)))
        ).Insert(
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldfld, AccessTools.Field(typeof(QuickHarvestGridPanel), nameof(QuickHarvestGridPanel.gridContents))),
            new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(FishCaughtPatcher), nameof(OnGridFishesCaught))));

        return matcher.InstructionEnumeration();
    }

    [HarmonyTranspiler]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(typeof(WaterspoutWorldEvent), nameof(WaterspoutWorldEvent.OnPlayerHit))]
    public static IEnumerable<CodeInstruction> WaterspoutWorldEvent_OnPlayerHit_Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var matcher = new CodeMatcher(instructions, generator);

        matcher.MatchEndForward(
            new CodeMatch(OpCodes.Ldsfld, AccessTools.Field(typeof(GameEvents), nameof(GameEvents.Instance))),
            new CodeMatch(OpCodes.Callvirt, AccessTools.Method(typeof(GameEvents), nameof(GameEvents.TriggerFishCaught)))
        ).RemoveInstruction().Insert(new CodeInstruction(OpCodes.Ldloc_2), new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(WinchExtensions), nameof(WinchExtensions.TriggerFishCaught))));

        return matcher.InstructionEnumeration();
    }

}
