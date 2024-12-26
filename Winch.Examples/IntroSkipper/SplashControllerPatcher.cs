using System;
using HarmonyLib;
using Winch.Core;

namespace IntroSkipper;

[HarmonyPatch]
internal static class SplashControllerPatcher
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(SceneLoader), nameof(SceneLoader.ShouldShowSplashScreen))]
    public static bool SceneLoader_ShouldShowSplashScreen(SceneLoader __instance, ref bool __result)
    {
        // Base game checks for save files here without null checking
        __result = false;
        return false;
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(SplashController), nameof(SplashController.OnEnable))]
    public static bool SplashController_OnEnable()
    {
        WinchCore.Log.Info("Skipping Splash Screen...");
        try
        {
            GameManager.Instance.Loader.LoadStartupFromSplash();
        }
        catch (Exception e)
        {
            // version 1.5.4 made it throw an exception before, let's keep this try-catch just in case (would result in a black screen that bricks the game)
            WinchCore.Log.Error(e);
        }

        return false;
    }
}