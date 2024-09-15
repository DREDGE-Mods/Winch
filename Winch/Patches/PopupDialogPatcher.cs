using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace Winch.Patches;

[HarmonyPatch]
internal static class PopupDialogPatcher
{
    public static void AddFocuser(List<BasicButtonWrapper> buttons)
    {
        var firstButton = buttons.FirstOrDefault();
        firstButton.SetSelectable(firstButton.gameObject.AddComponent<ControllerFocusGrabber>());
    }

    [HarmonyPatch(typeof(PopupDialog), nameof(PopupDialog.Show))]
    public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var matcher = new CodeMatcher(instructions, generator);
        matcher.End().Insert(
            new CodeInstruction(OpCodes.Ldloc_1),
            new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(PopupDialogPatcher), nameof(AddFocuser)))
        );
        return matcher.InstructionEnumeration();
    }
}