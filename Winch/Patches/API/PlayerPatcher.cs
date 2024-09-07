using System;
using HarmonyLib;
using Winch.Core;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPriority(Priority.First)]
[HarmonyPatch(typeof(Player), nameof(Player.Awake))]
internal static class PlayerPatch
{
    public static void Postfix(Player __instance)
    {
        try
        {
            AbilityUtil.AddModdedAbilitiesToPlayer(__instance.transform.Find("Abilities"));
        }
        catch (Exception ex)
        {
            WinchCore.Log.Error($"Error in {nameof(PlayerPatch)}: exception {ex}");
        }
    }
}
