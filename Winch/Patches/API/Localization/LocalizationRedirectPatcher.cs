using System;
using HarmonyLib;
using InControl;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using UnityEngine.UIElements;
using Winch.Core;
using Winch.Util;
using Yarn;
using Yarn.Unity;

namespace Winch.Patches.API.Localization;

[HarmonyPatch]
internal static class LocalizationRedirectPatcher
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(LocalizedStringDatabase))]
    [HarmonyPatch("ProcessUntranslatedText")]
    public static bool LocalizedStringDatabase_ProcessUntranslatedText_Prefix(ref string __result, string key, long keyId, TableReference tableReference, StringTable table, Locale locale)
    {
        string localeCode = locale.Identifier.Code;
        string? localized = LocalizationUtil.GetLocalizedString(localeCode, key);
        if (localized == null)
        {
            if (localeCode != "en")
            {
                localized = LocalizationUtil.GetLocalizedString("en", key); // Default to english
                if (localized == null)
                    return true;
            }
            else
                return true;
        }

        __result = localized;
        return false;
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(DredgeLocalizedLineProvider))]
    [HarmonyPatch(nameof(DredgeLocalizedLineProvider.GetLocalizedLine))]
    public static bool DredgeLocalizedLineProvider_GetLocalizedLine_Prefix(DredgeLocalizedLineProvider __instance, ref LocalizedLine __result, Line line)
    {
        string localeCode = LocalizationSettings.SelectedLocale.Identifier.Code;
        string? rawText = LocalizationUtil.GetLocalizedString(localeCode, line.ID);
        if (rawText == null)
        {
            if (localeCode != "en")
            {
                rawText = LocalizationUtil.GetLocalizedString("en", line.ID); // Default to english
                if (rawText == null)
                    return true;
            }
            else
                return true;
        }

        __result = new LocalizedLine
        {
            TextID = line.ID,
            RawText = rawText,
            Substitutions = line.Substitutions,
            Metadata = __instance.YarnProject.lineMetadata.GetMetadata(line.ID)
        };
        return false;
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(TextOptionButton))]
    [HarmonyPatch(nameof(TextOptionButton.Init))]
    public static void TextOptionButton_Init_Postfix(TextOptionButton __instance, DialogueOption opt)
    {
        string localizedString = opt.Line.RawText;
        localizedString = localizedString.Replace("\\", "");
        localizedString = localizedString.TrimStart(TextOptionButton.trimChars);
        __instance.textField.text = localizedString;
    }
}