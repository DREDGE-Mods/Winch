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
#pragma warning disable IDE0200
        __instance.AddCommandHandler<string>("LogDebug", message => __instance.LogDebug(message));
        __instance.AddCommandHandler<string>("LogInfo", message => __instance.LogInfo(message));
        __instance.AddCommandHandler<string>("LogWarn", message => __instance.LogWarn(message));
        __instance.AddCommandHandler<string>("LogError", message => __instance.LogError(message));
#pragma warning restore IDE0200
        DredgeEvent.TriggerDialogueRunnerLoaded(__instance);
    }

    private static void LogDebug(this DredgeDialogueRunner dialogueRunner, string message)
    {
        WinchCore.Log.Debug(message, dialogueRunner.CurrentNodeName);
    }

    private static void LogInfo(this DredgeDialogueRunner dialogueRunner, string message)
    {
        WinchCore.Log.Info(message, dialogueRunner.CurrentNodeName);
    }

    private static void LogWarn(this DredgeDialogueRunner dialogueRunner, string message)
    {
        WinchCore.Log.Warn(message, dialogueRunner.CurrentNodeName);
    }

    private static void LogError(this DredgeDialogueRunner dialogueRunner, string message)
    {
        WinchCore.Log.Error(message, dialogueRunner.CurrentNodeName);
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
