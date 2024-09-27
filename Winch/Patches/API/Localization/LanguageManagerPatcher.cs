using HarmonyLib;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core;
using Winch.Core.API;

namespace Winch.Patches.API.Localization;

[HarmonyPatch]
public static class LanguageManagerPatcher
{
    /// <summary>
    /// Add the modded locales to supported locale data for them to show up in settings
    /// </summary>
    [HarmonyPrefix]
    [HarmonyPriority(Priority.Last)]
    [HarmonyPatch(typeof(LanguageManager), nameof(LanguageManager.Init))]
    public static bool Init(LanguageManager __instance)
    {
        WinchCore.Log.Debug("[LanguageManager] Init()");
        ApplicationEvents.Instance.OnSaveManagerInitialized -= __instance.Init;
        if (!string.IsNullOrEmpty(GameManager.Instance.SettingsSaveData.localeId))
        {
            WinchCore.Log.Debug("[LanguageManager] Init() overriding system language.");
            __instance.SetLocale(GameManager.Instance.SettingsSaveData.localeId);
        }
        Addressables.LoadAssetAsync<SupportedLocaleData>(__instance.supportedLocaleDataRef).Completed += __instance.OnSupportedLocaleDataAddressableLoaded;
        __instance.RefreshColors();
        __instance.IsInit = true;
        __instance.OnInit?.Invoke();
        return false;
    }

    public static void OnSupportedLocaleDataAddressableLoaded(this LanguageManager languageManager, AsyncOperationHandle<SupportedLocaleData> handle)
    {
        if (handle.Result == null || handle.Status != AsyncOperationStatus.Succeeded) return;

        DredgeEvent.AddressableEvents.SupportedLocalesLoaded.Trigger(languageManager, handle, true);

        WinchCore.Log.Debug("[LanguageManager] OnSupportedLocaleDataAddressableLoaded()");
        languageManager.supportedLocaleData = handle.Result;

        DredgeEvent.AddressableEvents.SupportedLocalesLoaded.Trigger(languageManager, handle, false);
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(LanguageManager), nameof(LanguageManager.RefreshColors))]
    public static void RefreshColors(LanguageManager __instance)
    {
        __instance.AddColorType(DredgeColorTypesExtra.ATTENTION);
        __instance.AddColorType(DredgeColorTypesExtra.INFO);
        __instance.AddColorType(DredgeColorTypesExtra.PRIORITY);
        __instance.AddColorType(DredgeColorTypesExtra.ALERT);
    }
}
