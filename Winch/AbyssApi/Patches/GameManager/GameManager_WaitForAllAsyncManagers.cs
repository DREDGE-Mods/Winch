using HarmonyLib;

namespace Winch.AbyssApi.Patches.GameManager;

[HarmonyPatch(typeof(global::GameManager), nameof(global::GameManager.WaitForAllAsyncManagers))]
internal static class GameManager_WaitForAllAsyncManagers
{
    [HarmonyPostfix]
    private static void Postfix()
    {
        AbyssEvents.InvokeGameManagersLoaded();
    }
}