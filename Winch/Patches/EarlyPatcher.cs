using CommandTerminal;
using HarmonyLib;
using Winch.Patches;
using Winch.Util;

namespace Winch.Patches
{
    internal static class EarlyPatcher
    {
        public static void Initialize(Harmony harmony)
        {
            harmony.Patch(AccessTools.Method(typeof(DredgeInputManager), nameof(DredgeInputManager.Awake)),
                postfix: new HarmonyMethod(AccessTools.Method(typeof(GameLoadPatcher), nameof(GameLoadPatcher.Postfix))));

            harmony.Patch(AccessTools.Method(typeof(GameManager), nameof(GameManager.AddTerminalCommands)),
                prefix: new HarmonyMethod(AccessTools.Method(typeof(BuildInfoFeaturePatcher), nameof(BuildInfoFeaturePatcher.Prefix))));

            //harmony.Patch(AccessTools.Method(typeof(GameManager), nameof(GameManager.Start)),
            //    postfix: new HarmonyMethod(AccessTools.Method(typeof(GameLoadPatcher), nameof(GameLoadPatcher.Postfix))));

            EnumUtil.Initialize(harmony);

            harmony.Patch(AccessTools.Method(typeof(Terminal), nameof(Terminal.OnEnable)),
                prefix: new HarmonyMethod(AccessTools.Method(typeof(TerminalPatcher), nameof(TerminalPatcher.Terminal_OnEnable_Prefix))));

            harmony.Patch(AccessTools.Method(typeof(Terminal), nameof(Terminal.OnDisable)),
                prefix: new HarmonyMethod(AccessTools.Method(typeof(TerminalPatcher), nameof(TerminalPatcher.Terminal_OnDisable_Prefix))));
        }
    }
}
