using System.Collections.Generic;
using System.Linq;
using CommandTerminal;
using HarmonyLib;
using UnityEngine;
using Winch.Core;
using Winch.Patches;

namespace Winch.Patches
{
    internal static class TerminalPatcher
    {
        public static bool Terminal_OnEnable_Prefix(Terminal __instance)
        {
            if (Terminal.Buffer == null) Terminal.Buffer = new CommandLog(__instance.BufferSize);
            if (Terminal.Shell == null) Terminal.Shell = new CommandShell();
            if (Terminal.History == null) Terminal.History = new CommandHistory();
            if (Terminal.Autocomplete == null) Terminal.Autocomplete = new CommandAutocomplete();
            Application.logMessageReceived += __instance.CustomHandleUnityLog;
            return false;
        }

        public static bool Terminal_OnDisable_Prefix(Terminal __instance)
        {
            Application.logMessageReceived -= __instance.CustomHandleUnityLog;
            return false;
        }

        public static List<string> startsWith = new List<string>
        {
            "Failed to find expected binary shader data",
            "Failed to create agent because there is no valid NavMesh"
        };
        public static List<string> previouslyLogged = new List<string>();

        public static void CustomHandleUnityLog(this Terminal terminal, string message, string stack_trace, LogType type)
        {
            if (startsWith.Any(message.StartsWith))
            {
                if (!previouslyLogged.Contains(message))
                {
                    previouslyLogged.Add(message);
                    switch (type)
                    {
                        case LogType.Log:
                            WinchCore.Log.Info(message, "Unity");
                            break;
                        case LogType.Warning:
                            WinchCore.Log.Warn(message, "Unity");
                            break;
                        case LogType.Assert:
                        case LogType.Error:
                        case LogType.Exception:
                            WinchCore.Log.Error(message, "Unity");
                            break;
                    }
                }
            }
            else
                terminal.HandleUnityLog(message, stack_trace, type);
        }
    }
}
