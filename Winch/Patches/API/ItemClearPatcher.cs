using HarmonyLib;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(ItemManager))]
[HarmonyPatch(nameof(ItemManager.OnGameEnded))]
internal static class ItemClearPatcher
{
    public static void Postfix(ItemManager __instance)
    {
        ItemUtil.ClearItemData();
    }
}
