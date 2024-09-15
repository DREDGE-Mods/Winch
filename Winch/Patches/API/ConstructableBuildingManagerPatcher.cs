using HarmonyLib;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(ConstructableBuildingManager), nameof(ConstructableBuildingManager.OnEnable))]
internal static class ConstructableBuildingManagerPatcher
{
    public static void Prefix(ConstructableBuildingManager __instance)
    {
        ConstructableBuildingUtil.AddModdedConstructableBuildingDependencyData(__instance.config);
    }

    public static void Postfix(ConstructableBuildingManager __instance)
    {
        ConstructableBuildingUtil.PopulateConstructableBuildingDependencyData(__instance.config);
    }
}
