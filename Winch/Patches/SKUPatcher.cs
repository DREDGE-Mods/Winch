using HarmonyLib;
using Winch.Core;
using Newtonsoft.Json.Utilities;
using Winch.Util;
using CommandTerminal;
using UnityEngine;
using Winch.Config;

namespace Winch.Patches
{
    [HarmonyPatch(typeof(SKUSpecificDisabler), nameof(SKUSpecificDisabler.Awake))]
    internal static class SKUPatcher
    {
        [HarmonyPrefix]
        public static void Prefix(this SKUSpecificDisabler __instance)
        {
            __instance.destroyIfUnavailable = false; // Disable destroying

            // Enable terminal
            if (__instance.TryGetComponent<Terminal>(out Terminal terminal) && WinchConfig.GetProperty("EnableDeveloperConsole", false))
            {
                terminal.ConsoleFont = Font.CreateDynamicFontFromOSFont("Courier New", 16);
                __instance.supportedBuilds = BuildEnvironment.ALL;
                __instance.supportedPlatforms = Platform.ALL;
                __instance.unsupportedOnSteamDeck = false;
                __instance.allowInConventionBuilds = true;
            }
        }
    }
}
