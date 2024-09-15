using HarmonyLib;
using Winch.Data.GridConfig;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(GridConfiguration))]
[HarmonyPatch(nameof(GridConfiguration.MainItemData), MethodType.Getter)]
internal static class GridConfigsDeferPatcher
{
    public static void Prefix(GridConfiguration __instance)
    {
        if (__instance is DeferredGridConfiguration deferredGridConfiguration && !string.IsNullOrWhiteSpace(deferredGridConfiguration.mainItemData))
        {
            ItemUtil.AllItemDataDict.TryGetValue(deferredGridConfiguration.mainItemData, out __instance.mainItemData);
        }
    }
}