using HarmonyLib;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(DataLoader))]
[HarmonyPatch(nameof(DataLoader.OnGameEnded))]
internal static class GridConfigsClearPatcher
{
    public static void Postfix(DataLoader __instance)
    {
        GridConfigUtil.ClearGridConfigurations();
    }
}
