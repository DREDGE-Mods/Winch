using HarmonyLib;
using Winch.Core;

namespace Winch.Patches;

[HarmonyPatch(typeof(EntitlementManager), nameof(EntitlementManager.AddTerminalCommands))]
internal static class EntitlementCommandPatcher
{
    [HarmonyPrefix]
    public static bool Prefix() {
        return false;
    }
}