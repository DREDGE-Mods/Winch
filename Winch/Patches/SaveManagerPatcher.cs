using HarmonyLib;
using Winch.Core;

namespace Winch.Patches
{
    [HarmonyPatch(typeof(SaveManager))]
    internal static class SaveManagerPatcher
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(SaveManager.SaveGameFile))]
        public static void SaveGameFile(SaveManager __instance, bool useBackupHistory)
        {
            WinchCore.Log.Debug($"SaveGameFile({useBackupHistory})");
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(SaveManager.Load))]
        public static void Load(SaveManager __instance, int slot, ref bool __result)
        {
            WinchCore.Log.Debug($"Load({slot}) => {__result}");
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(SaveManager.CreateSaveData))]
        public static void CreateSaveData(SaveManager __instance, int slot)
        {
            WinchCore.Log.Debug($"CreateSaveData({slot})");
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(SaveManager.DeleteSaveFile))]
        public static void DeleteSaveFile(SaveManager __instance, int slot)
        {
            WinchCore.Log.Debug($"DeleteSaveFile({slot})");

        }
    }
}
