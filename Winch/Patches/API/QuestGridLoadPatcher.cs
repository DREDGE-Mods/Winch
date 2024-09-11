using HarmonyLib;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(DataLoader))]
[HarmonyPatch(nameof(DataLoader.OnQuestGridDataAddressablesLoaded))]
internal static class QuestGridLoadPatcher
{
    public static void Prefix(DataLoader __instance, AsyncOperationHandle<IList<QuestGridConfig>> handle)
    {
        if (handle.Result == null || handle.Status != AsyncOperationStatus.Succeeded) return;

        QuestUtil.AddModdedQuestGridConfigs(handle.Result);
        DredgeEvent.AddressableEvents.QuestGridConfigsLoaded.Trigger(__instance, handle, true);
    }

    public static void Postfix(DataLoader __instance, AsyncOperationHandle<IList<QuestGridConfig>> handle)
    {
        if (handle.Result == null || handle.Status != AsyncOperationStatus.Succeeded) return;

        QuestUtil.PopulateQuestGridConfigs(handle.Result);
        DredgeEvent.AddressableEvents.QuestGridConfigsLoaded.Trigger(__instance, handle, false);
    }
}
