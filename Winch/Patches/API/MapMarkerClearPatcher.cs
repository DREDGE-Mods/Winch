using HarmonyLib;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(DataLoader))]
[HarmonyPatch(nameof(DataLoader.OnGameEnded))]
internal static class MapMarkerClearPatcher
{
    public static void Postfix(DataLoader __instance)
    {
        MapMarkerUtil.ClearMapMarkerData();
    }
}
