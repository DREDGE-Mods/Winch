using System.Collections;
using System.IO;
using System.Linq;
using HarmonyLib;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using Winch.Core;
using Winch.Util;

namespace Winch.Patches.API.Localization
{
    /// <summary>
    /// Add the modded locales to supported locale data for them to show up in settings
    /// </summary>
    [HarmonyPatch]
    public static class LanguageManagerPatcher
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(LanguageManager), nameof(LanguageManager.Init))]
        public static void Init(LanguageManager __instance)
        {
            __instance.StartCoroutine(__instance.AddWhenSupportedLocaleDataLoaded());
        }

        public static IEnumerator AddWhenSupportedLocaleDataLoaded(this LanguageManager languageManager)
        {
            yield return new WaitUntil(() => languageManager.supportedLocaleData != null);
            LocalizationUtil.AddedLocales.ForEach(languageManager.SupportedLocaleData.locales.Add);
        }
    }
}