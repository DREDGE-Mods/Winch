using HarmonyLib;
using UnityEngine.Rendering.Universal;
using Winch.Core;
using Winch.Core.API;
using Winch.Util;
using Yarn.Unity;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(DredgeDialogueRunner))]
internal static class DialogueRunnerPatcher
{
    public static void Placeholder()
    {

    }

    [HarmonyPostfix]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(nameof(DredgeDialogueRunner.Awake))]
    public static void Awake_Postfix(DredgeDialogueRunner __instance)
    {
        __instance.AddCommandHandler("Placeholder", Placeholder);
        new DialogueLogger(__instance);
        DredgeEvent.TriggerDialogueRunnerLoaded(__instance);
    }

    private class DialogueLogger
    {
        private readonly DredgeDialogueRunner dialogueRunner;

        public DialogueLogger(DredgeDialogueRunner dialogueRunner)
        {
            this.dialogueRunner = dialogueRunner;
            dialogueRunner.AddCommandHandler<string>("LogDebug", LogDebug);
            dialogueRunner.AddCommandHandler<string>("LogInfo", LogInfo);
            dialogueRunner.AddCommandHandler<string>("LogWarn", LogWarn);
            dialogueRunner.AddCommandHandler<string>("LogError", LogError);
        }

        private void LogDebug(string message)
        {
            WinchCore.Log.Debug(message, dialogueRunner.CurrentNodeName);
        }

        private void LogInfo(string message)
        {
            WinchCore.Log.Info(message, dialogueRunner.CurrentNodeName);
        }

        private void LogWarn(string message)
        {
            WinchCore.Log.Warn(message, dialogueRunner.CurrentNodeName);
        }

        private void LogError(string message)
        {
            WinchCore.Log.Error(message, dialogueRunner.CurrentNodeName);
        }
    }

    [HarmonyPrefix]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(typeof(DialogueRunner), "Start")]
    public static void Start_Prefix(DredgeDialogueRunner __instance)
    {
        __instance.FireOnNextUpdate(DialogueUtil.Inject);
    }

    [HarmonyPrefix]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(nameof(DredgeDialogueRunner.StartDialogue))]
    public static bool StartDialogue_Prefix(DredgeDialogueRunner __instance, string nodeName)
    {
        if (!__instance.Dialogue.IsActive && !__instance.NodeExists(nodeName))
        {
            WinchCore.Log.Error("No node named " + nodeName + " has been loaded.", "DredgeDialogueRunner.StartDialogue");
            GameEvents.Instance.TriggerDialogueStarted();
            __instance.FireOnNextUpdate(__instance.onDialogueComplete.Invoke);
            return false;
        }
        else
            return true;
    }

}
