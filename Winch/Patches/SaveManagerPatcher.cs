using HarmonyLib;
using Winch.Core;
using Winch.Data;
using Winch.Util;

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
            try
            {
                SaveUtil.Initialize(__instance);
            }
            catch (System.Exception ex)
            {
                WinchCore.Log.Error(ex);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(SaveManager.LoadAllIntoMemory))]
        public static void LoadAllIntoMemory(SaveManager __instance)
        {
            WinchCore.Log.Debug($"LoadAllIntoMemory()");
            for (int slot = 0; slot < __instance.numSlots; slot++)
            {
                try
                {
                    SaveUtil.GetInMemorySaveDataForSlot(slot).LoadIntoMemory();
                }
                catch (System.Exception ex)
                {
                    WinchCore.Log.Error(ex);
                }
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(SaveManager.SaveGameFile))]
        public static void SaveGameFile(SaveManager __instance, bool useBackupHistory)
        {
            WinchCore.Log.Debug($"SaveGameFile({useBackupHistory})");
            try
            {
                SaveUtil.ActiveSaveData.Save();
            }
            catch (System.Exception ex)
            {
                WinchCore.Log.Error(ex);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(SaveManager.SaveGameFile))]
        public static void SaveGameFilePost(SaveManager __instance, bool useBackupHistory)
        {
            WinchCore.Log.Debug($"SaveGameFilePost({useBackupHistory})");
            try
            {
                SaveUtil.ActiveSaveData.InsertModdedData();
            }
            catch (System.Exception ex)
            {
                WinchCore.Log.Error(ex);
            }
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
            if (__result)
            {
                try
                {
                    SaveUtil.ActiveSaveData.Load();
                }
                catch (System.Exception ex)
                {
                    WinchCore.Log.Error(ex);
                }
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(SaveManager.CreateSaveData))]
        public static void CreateSaveData(SaveManager __instance, int slot)
        {
            WinchCore.Log.Debug($"CreateSaveData({slot})");
            try
            {
                SaveUtil.ActiveSaveData.Create();
            }
            catch (System.Exception ex)
            {
                WinchCore.Log.Error(ex);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(SaveManager.DeleteSaveFile))]
        public static void DeleteSaveFile(SaveManager __instance, int slot)
        {
            WinchCore.Log.Debug($"DeleteSaveFile({slot})");
            try
            {
                SaveUtil.GetInMemorySaveDataForSlot(slot).Delete();
            }
            catch (System.Exception ex)
            {
                WinchCore.Log.Error(ex);
            }
        }
    }
}
