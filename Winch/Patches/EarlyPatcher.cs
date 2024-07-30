using HarmonyLib;
using Winch.Patches.API.Localization;
using Winch.Util;

namespace Winch.Patches
{
    internal static class EarlyPatcher
    {
        public static void Initialize(Harmony harmony)
        {
            harmony.Patch(AccessTools.Method(typeof(GameManager), nameof(GameManager.AddTerminalCommands)),
                prefix: new HarmonyMethod(AccessTools.Method(typeof(BuildInfoFeaturePatcher), nameof(BuildInfoFeaturePatcher.Prefix))));

            harmony.Patch(AccessTools.Method(typeof(GameManager), nameof(GameManager.Start)),
                postfix: new HarmonyMethod(AccessTools.Method(typeof(GameLoadPatcher), nameof(GameLoadPatcher.Postfix))));

            EnumUtil.Initialize(harmony);
        }
    }
}
