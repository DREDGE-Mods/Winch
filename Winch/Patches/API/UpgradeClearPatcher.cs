using HarmonyLib;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(DataLoader))]
[HarmonyPatch(nameof(DataLoader.OnGameEnded))]
internal static class UpgradeClearPatcher
{
    public static void Postfix(DataLoader __instance)
    {
        UpgradeUtil.ClearUpgradeData();
    }
}
