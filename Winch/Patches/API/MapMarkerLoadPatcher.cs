using HarmonyLib;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(DataLoader))]
[HarmonyPatch(nameof(DataLoader.OnMapMarkerDataAddressablesLoaded))]
internal static class MapMarkerLoadPatcher
{
    public static void Prefix(DataLoader __instance, AsyncOperationHandle<IList<MapMarkerData>> handle)
    {
        if (handle.Result == null || handle.Status != AsyncOperationStatus.Succeeded) return;

        MapMarkerUtil.AddModdedMapMarkerData(handle.Result);
        DredgeEvent.AddressableEvents.MapMarkersLoaded.Trigger(__instance, handle, true);
    }

    public static void Postfix(DataLoader __instance, AsyncOperationHandle<IList<MapMarkerData>> handle)
    {
        if (handle.Result == null || handle.Status != AsyncOperationStatus.Succeeded) return;

        MapMarkerUtil.PopulateMapMarkerData(handle.Result);
        DredgeEvent.AddressableEvents.MapMarkersLoaded.Trigger(__instance, handle, false);
    }
}
