using HarmonyLib;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API
{
    [HarmonyPatch(typeof(DataLoader))]
    [HarmonyPatch(nameof(DataLoader.OnWorldEventDataAddressablesLoaded))]
    internal static class WorldEventLoadPatcher
    {
        public static void Prefix(DataLoader __instance, AsyncOperationHandle<IList<WorldEventData>> handle)
        {
            if (handle.Result == null || handle.Status != AsyncOperationStatus.Succeeded) return;

            WorldEventUtil.AddModdedWorldEvents(handle.Result);
            DredgeEvent.AddressableEvents.WorldEventsLoaded.Trigger(__instance, handle, true);
        }

        public static void Postfix(DataLoader __instance, AsyncOperationHandle<IList<WorldEventData>> handle)
        {
            if (handle.Result == null || handle.Status != AsyncOperationStatus.Succeeded) return;

            WorldEventUtil.PopulateWorldEvents(handle.Result);
            DredgeEvent.AddressableEvents.WorldEventsLoaded.Trigger(__instance, handle, false);
        }
    }
}
