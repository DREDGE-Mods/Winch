using HarmonyLib;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(ShopRestocker))]
[HarmonyPatch(nameof(ShopRestocker.Awake))]
internal static class ShopLoadPatcher
{
    public static void Postfix(ShopRestocker __instance)
    {
        ShopUtil.AddModdedShopData(__instance);
        ShopUtil.PopulateShopData(__instance.shopDataGridConfigs);
    }
}
