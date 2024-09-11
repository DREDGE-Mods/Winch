using HarmonyLib;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(DataLoader))]
[HarmonyPatch(nameof(DataLoader.OnGameEnded))]
internal static class QuestGridClearPatcher
{
    public static void Postfix(DataLoader __instance)
    {
        QuestUtil.ClearQuestStepData();
        QuestUtil.ClearQuestData();
    }
}
