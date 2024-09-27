using HarmonyLib;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(SerializableGrid))]
[HarmonyPatch(nameof(SerializableGrid.Init))]
internal static class SerializableGridInitPatcher
{
    /// <summary>
    /// Add reset to cell count because for some reason that isn't there, and so vanilla would just increment anytime Init is called.
    /// </summary>
    public static void Prefix(SerializableGrid __instance)
    {
        __instance.cellCount = 0;
    }
}
