using HarmonyLib;
using Winch.Data.Item;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(DeployableItemData))]
[HarmonyPatch(nameof(DeployableItemData.GridConfig), MethodType.Getter)]
internal static class DeployableItemDataGridConfigPatcher
{
    public static void Prefix(DeployableItemData __instance)
    {
        if (__instance is GridConfigDeployableItemData deployableItemData && !string.IsNullOrWhiteSpace(deployableItemData.gridConfiguration))
        {
            GridConfigUtil.AllGridConfigDict.TryGetValue(deployableItemData.gridConfiguration, out __instance.gridConfig);
        }
    }
}
