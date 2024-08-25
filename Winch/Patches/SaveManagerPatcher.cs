using HarmonyLib;
using Winch.Core;

namespace Winch.Patches
{
    [HarmonyPatch(typeof(SaveManager))]
    internal static class SaveManagerPatcher
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(SaveManager.Init))]
        public static void Init(SaveManager __instance)
        {
            WinchCore.Log.Debug($"Init()");
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(SaveManager.LoadAllIntoMemory))]
        public static void LoadAllIntoMemory(SaveManager __instance)
        {
            WinchCore.Log.Debug($"LoadAllIntoMemory()");
        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(SaveManager.SaveGameFile))]
        public static void SaveGameFile(SaveManager __instance, bool useBackupHistory)
        {
            WinchCore.Log.Debug($"SaveGameFile({useBackupHistory})");
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(SaveManager.LoadIntoMemory))]
        public static void LoadIntoMemory(SaveManager __instance, int slot, ref SaveData __result)
        {
            WinchCore.Log.Debug($"LoadIntoMemory({slot}) => {__result}");
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
