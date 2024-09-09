using HarmonyLib;
using Winch.Core;

namespace IntroSkipper;

[HarmonyPatch(typeof(SplashController))]
[HarmonyPatch(nameof(SplashController.OnEnable))]
internal static class SplashControllerPatcher
{
    public static bool Prefix()
    {
        WinchCore.Log.Info("Skipping Splash Screen...");
        GameManager.Instance.Loader.LoadStartupFromSplash();
        return false;
    }
}