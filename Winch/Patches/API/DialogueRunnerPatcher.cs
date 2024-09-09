using System;
using HarmonyLib;
using UnityEngine;
using Winch.Core;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPriority(Priority.First)]
[HarmonyPatch(typeof(DredgeDialogueRunner), nameof(DredgeDialogueRunner.Awake))]
internal static class DialogueRunnerPatcher
{
    public static void Postfix(DredgeDialogueRunner __instance)
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
}
