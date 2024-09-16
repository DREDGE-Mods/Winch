using HarmonyLib;
using Winch.Components;
using Winch.Core;
using Winch.Util;
using static ContinueOrNewButton;

namespace Winch.Patches;

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

    [HarmonyPrefix]
    [HarmonyPatch(typeof(ContinueOrNewButton), nameof(ContinueOrNewButton.OnClick))]
    public static bool OnContinueOrNewButtonClicked(ContinueOrNewButton __instance)
    {
        if (__instance.hasBeenClicked)
        {
            return false;
        }
        __instance.hasBeenClicked = true;
        if (__instance.currentMode == StartButtonMode.CONTINUE)
        {
            __instance.CheckIsSaveAllowedToBeLoaded();
        }
        else if (__instance.currentMode == StartButtonMode.NEW)
        {
            GameManager.Instance.Loader.LoadGameFromTitle();
        }
        return false;
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(SaveSlotUI), nameof(SaveSlotUI.OnClicked))]
    public static bool OnSaveSlotLoadButtonClicked(SaveSlotUI __instance)
    {
        if (__instance.hasBeenClicked || __instance.hasDeleteBeenClicked)
        {
            return false;
        }
        __instance.hasBeenClicked = true;
        __instance.saveData = GameManager.Instance.SaveManager.LoadIntoMemory(__instance.slotNum);
        if (__instance.hasSaveFile)
        {
            __instance.CheckIsSaveAllowedToBeLoaded();
        }
        else
        {
            __instance.DoContinueOrNew(canCreateNew: true);
        }
        return false;
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(SaveData), nameof(SaveData.Init))]
    public static void SaveData_Init_Prefix(SaveData __instance)
    {
        foreach (GridKey gridKey in EnumUtil.GetValues<GridKey>())
        {
            if (gridKey != GridKey.NONE)
            {
                GridConfiguration gridConfiguration = gridKey == GridKey.INVENTORY ? GameManager.Instance.GameConfigData.GetGridConfigForHullTier(__instance.HullTier) : GameManager.Instance.GameConfigData.GetGridConfigForKey(gridKey);
                if (gridConfiguration == null)
                {
                    WinchCore.Log.Error($"Could not find gridConfiguration for gridKey: {gridKey}. Every grid key enum value is REQUIRED to be associated with a grid configuration in the GameConfigData or else the game will not initialize!");
                }
            }
        }
    }
}
