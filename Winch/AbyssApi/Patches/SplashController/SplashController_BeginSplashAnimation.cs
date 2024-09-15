using System.Threading.Tasks;
using HarmonyLib;

namespace Winch.AbyssApi.Patches.SplashController;

[HarmonyPatch(typeof(global::SplashController), nameof(global::SplashController.BeginSplashAnimation))]
internal static class SplashController_BeginSplashAnimation
{
    [HarmonyPrefix]
    private static bool Prefix(global::SplashController __instance, ref Task __result)
    {
        __instance.OnSplashComplete();
        __result = Task.CompletedTask;
        return false;
    }
}