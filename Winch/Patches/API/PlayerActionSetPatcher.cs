using HarmonyLib;
using InControl;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch]
internal static class PlayerActionSetPatcher
{
    [HarmonyTranspiler]
    [HarmonyPatch(typeof(PlayerActionSet), nameof(PlayerActionSet.SaveData))]
    public static IEnumerable<CodeInstruction> PlayerActionSet_SaveData_Transpiler(
        IEnumerable<CodeInstruction> instructions,
        ILGenerator generator)
    {
        var actionsField =
            AccessTools.Field(typeof(PlayerActionSet), "actions");

        var vanillaActionsLocal =
            generator.DeclareLocal(typeof(List<PlayerAction>));

        var matcher = new CodeMatcher(instructions, generator);

        // var vanillaActions = GetVanillaActions(this.actions);
        matcher.Start().Insert(
            new CodeInstruction(OpCodes.Ldarg_0),
            new CodeInstruction(OpCodes.Ldfld, actionsField),
            new CodeInstruction(
                OpCodes.Call,
                AccessTools.Method(
                    typeof(PlayerActionSetPatcher),
                    nameof(GetVanillaActions)
                )
            ),
            new CodeInstruction(OpCodes.Stloc, vanillaActionsLocal)
        );

        // Skip our newly inserted `this.actions`.
        matcher.Start().Advance(4);

        while (matcher.MatchStartForward(
                   new CodeMatch(OpCodes.Ldarg_0),
                   new CodeMatch(OpCodes.Ldfld, actionsField)
               ).IsValid)
        {
            // Preserve labels/blocks by modifying the existing instructions
            // rather than removing/replacing them.

            matcher.Instruction.opcode = OpCodes.Nop;
            matcher.Instruction.operand = null;

            matcher.Advance(1);

            matcher.Instruction.opcode = OpCodes.Ldloc;
            matcher.Instruction.operand = vanillaActionsLocal;

            matcher.Advance(1);
        }

        return matcher.InstructionEnumeration();
    }

    private static List<PlayerAction> GetVanillaActions(
        List<PlayerAction> actions) =>
        actions
            .Where(ControlUtil.IsVanillaAction)
            .ToList();
}