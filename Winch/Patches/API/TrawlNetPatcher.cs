using HarmonyLib;
using static TrawlNetAbility;
using Winch.Data.Item;
using static ActiveAbilityInfoPanel;

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
    }
}
