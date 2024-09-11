using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(DataLoader))]
[HarmonyPatch("OnQuestDataAddressablesLoaded")]
internal static class QuestLoadPatcher
{
    public static bool Prefix(DataLoader __instance, AsyncOperationHandle<IList<QuestData>> handle)
    {
        if (handle.Result == null || handle.Status != AsyncOperationStatus.Succeeded) return false;

        var stepDatas = QuestUtil.GetQuestStepDatas(handle.Result);
        QuestUtil.PopulateQuestStepData(stepDatas);
        QuestUtil.AddModdedQuestStepData(stepDatas);
        __instance.allQuestSteps = stepDatas;
        DredgeEvent.AddressableEvents.QuestStepsLoaded.Trigger(__instance, stepDatas, true);
        QuestUtil.AddModdedQuestData(handle.Result);
        DredgeEvent.AddressableEvents.QuestsLoaded.Trigger(__instance, handle, true);
        __instance.allQuests = handle.Result.ToDictionary(q => q.name, q => q);
        __instance._hasLoadedQuestData = true;
        QuestUtil.PopulateQuestData(handle.Result);
        DredgeEvent.AddressableEvents.QuestStepsLoaded.Trigger(__instance, stepDatas, false);
        DredgeEvent.AddressableEvents.QuestsLoaded.Trigger(__instance, handle, false);
        return false;
    }
}
