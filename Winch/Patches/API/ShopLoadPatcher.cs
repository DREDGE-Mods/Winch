using System.Linq;
using HarmonyLib;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(ShopRestocker))]
[HarmonyPatch(nameof(ShopRestocker.Awake))]
internal static class ShopLoadPatcher
{
    public static void Postfix(ShopRestocker __instance)
    {
        ShopUtil.AddModdedShopData(__instance);
        var dict = __instance.shopDataGridConfigs.ToDictionary(kvp => kvp.shopData.name, kvp => kvp.shopData);
        DredgeEvent.AddressableEvents.ShopsLoaded.Trigger(__instance, dict, true);
        ShopUtil.Populate(__instance);
        DredgeEvent.AddressableEvents.ShopsLoaded.Trigger(__instance, dict, false);
    }
}
