using HarmonyLib;
using System.Linq;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(GameConfigData))]
[HarmonyPatch(nameof(GameConfigData.GetGridConfigForHullTier))]
internal static class GridConfigForHullTierPatcher
{
    public static bool Prefix(GameConfigData __instance, int tier, ref GridConfiguration __result)
    {
        if (tier > 5)
        {
            var hullUpgradeData = UpgradeUtil.GetAllHullUpgradeData().FirstOrDefault(hullUpgrade => hullUpgrade.tier == tier);
            if (hullUpgradeData != null && hullUpgradeData.hullGridConfiguration != null)
            {
                __result = hullUpgradeData.hullGridConfiguration;
                return false;
            }
        }
        return true;
    }
}
