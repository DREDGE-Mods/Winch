using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core.API;
using Winch.Util;
using static ShopRestocker;

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
