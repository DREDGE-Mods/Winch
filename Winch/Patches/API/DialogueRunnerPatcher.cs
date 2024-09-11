using HarmonyLib;
using Winch.Core;
using Winch.Core.API;
using Winch.Util;
using Yarn.Unity;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(DredgeDialogueRunner))]
internal static class DialogueRunnerPatcher
{
    [HarmonyPostfix]
    [HarmonyPriority(Priority.First)]
    [HarmonyPatch(nameof(DredgeDialogueRunner.Awake))]
    public static void Awake_Postfix(DredgeDialogueRunner __instance)
    {
        __instance.AddCommandHandler<string>("LogDebug", __instance.LogDebug);
        __instance.AddCommandHandler<string>("LogInfo", __instance.LogInfo);
        __instance.AddCommandHandler<string>("LogWarn", __instance.LogWarn);
        __instance.AddCommandHandler<string>("LogError", __instance.LogError);
        DredgeEvent.TriggerDialogueRunnerLoaded(__instance);
    }

    private static void LogDebug(this DredgeDialogueRunner dialogueRunner, string message)
    {
        WinchCore.Log.Debug(message, dialogueRunner.CurrentNodeName);
    }

    private static void LogInfo(this DredgeDialogueRunner dialogueRunner, string message)
    {
        WinchCore.Log.Debug(message, dialogueRunner.CurrentNodeName);
    }

    private static void LogWarn(this DredgeDialogueRunner dialogueRunner, string message)
    {
        WinchCore.Log.Debug(message, dialogueRunner.CurrentNodeName);
    }

    private static void LogError(this DredgeDialogueRunner dialogueRunner, string message)
    {
        WinchCore.Log.Debug(message, dialogueRunner.CurrentNodeName);
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
