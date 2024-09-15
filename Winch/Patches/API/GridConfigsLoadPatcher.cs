using HarmonyLib;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(DataLoader))]
[HarmonyPatch(nameof(DataLoader.OnGridConfigDataAddressablesLoaded))]
internal static class GridConfigsLoadPatcher
{
    public static void Prefix(DataLoader __instance, AsyncOperationHandle<IList<GridConfiguration>> handle)
    {
        if (handle.Result == null || handle.Status != AsyncOperationStatus.Succeeded) return;

        GridConfigUtil.AddModdedGridConfigurations(handle.Result);
        DredgeEvent.AddressableEvents.GridConfigsLoaded.Trigger(__instance, handle, true);
    }

    public static void Postfix(DataLoader __instance, AsyncOperationHandle<IList<GridConfiguration>> handle)
    {
        if (handle.Result == null || handle.Status != AsyncOperationStatus.Succeeded) return;

        GridConfigUtil.PopulateGridConfigurations(handle.Result);
        DredgeEvent.AddressableEvents.GridConfigsLoaded.Trigger(__instance, handle, false);
    }
}