using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HarmonyLib;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using Winch.Core;
using Winch.Data;
using Winch.Util;

namespace Winch.Patches.API.Localization
{
    [HarmonyPatch]
    public static class LanguageManagerPatcher
    {
        /// <summary>
        /// Add the modded locales to supported locale data for them to show up in settings
        /// </summary>
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
}