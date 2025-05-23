﻿using HarmonyLib;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(UpgradeManager))]
[HarmonyPatch(nameof(UpgradeManager.OnUpgradeDataAddressablesLoaded))]
internal static class UpgradeLoadPatcher
{
    public static void Prefix(UpgradeManager __instance, AsyncOperationHandle<IList<UpgradeData>> handle)
    {
        if (handle.Result == null || handle.Status != AsyncOperationStatus.Succeeded) return;

        UpgradeUtil.AddModdedUpgradeData(handle.Result);
        DredgeEvent.AddressableEvents.UpgradesLoaded.Trigger(__instance, handle, true);
    }

    public static void Postfix(UpgradeManager __instance, AsyncOperationHandle<IList<UpgradeData>> handle)
    {
        if (handle.Result == null || handle.Status != AsyncOperationStatus.Succeeded) return;

        UpgradeUtil.PopulateUpgradeData(handle.Result);
        DredgeEvent.AddressableEvents.UpgradesLoaded.Trigger(__instance, handle, false);
    }
}
