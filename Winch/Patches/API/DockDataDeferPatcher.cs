using HarmonyLib;
using Winch.Data.Dock;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(DockData))]
[HarmonyPatch(nameof(DockData.Speakers), MethodType.Getter)]
internal static class DockDataDeferPatcher
{
    public static void Prefix(DockData __instance)
    {
        if (__instance is DeferredDockData deferredDockData)
        {
            __instance.speakers = CharacterUtil.TryGetSpeakers(deferredDockData.speakers);
        }
    }
}
