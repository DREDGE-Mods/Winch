using System;
using HarmonyLib;
using Winch.Core;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPriority(Priority.First)]
[HarmonyPatch(typeof(GameSceneInitializer), nameof(GameSceneInitializer.Start))]
internal static class GameSceneInitializerPatch
{
    public static void Prefix(GameSceneInitializer __instance)
    {
        try
        {
            VibrationUtil.PopulateVibrationDatas();
            DockUtil.Populate();
            PoiUtil.Populate();
            PoiUtil.CreateModdedPois();
            HarvestZoneUtil.CreateModdedHarvestZones();
            WorldEventUtil.CreateModdedStaticWorldEvents();
            ItemUtil.Encyclopedia();
            DockUtil.Fix();
            DredgeEvent.TriggerGameLoading(__instance);
        }
        catch (Exception ex)
        {
            WinchCore.Log.Error($"Error in {nameof(GameSceneInitializerPatch)}: exception {ex}");
        }
    }
}
