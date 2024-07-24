using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityAsyncAwaitUtil;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using Winch.Core;
using static UnityEngine.Networking.UnityWebRequest;

namespace Winch.Util
{
    public static class LocalizationUtil
    {
        private static readonly IReadOnlyList<string> TableCollectionNames = new List<string>()
        {
            "Characters",
            "Items",
            "Quests",
            "Strings",
            "Yarn"
        };

        private static Dictionary<string, Dictionary<string, string>> StringDatabase = new Dictionary<string, Dictionary<string, string>>();
        private static Dictionary<string, Dictionary<string, StringTable>> StringTableDict = new Dictionary<string, Dictionary<string, StringTable>>();
        public static LocalizedString Empty => new LocalizedString(string.Empty, string.Empty);

        internal static List<Locale> AddedLocales = new List<Locale>();

        public static void InstallLocale(SystemLanguage language) => InstallLocale(Locale.CreateLocale(language));

        public static void InstallLocale(Locale locale)
        {
            locale.name = $"{locale.Identifier.CultureInfo.EnglishName} ({locale.Identifier.Code})";
            locale.hideFlags |= HideFlags.HideAndDontSave;
            locale.CustomFormatterCode = "";
            locale.SortOrder = 0;
            AddedLocales.Add(locale);
            var localeWithCode = "Locale-" + locale.Identifier.Code;
            AddressablesUtil.AddResourceAtLocation("Locale", locale.name, locale.name, locale);
            var tableByName = new Dictionary<string, StringTable>();
            StringTableDict.Add(locale.Identifier.Code, tableByName);
            foreach (var tableCollectionName in TableCollectionNames)
            {
                var tableNameWithCode = $"{tableCollectionName}_{locale.Identifier.Code}";
                var table = ScriptableObject.CreateInstance<StringTable>();
                table.name = tableNameWithCode;
                table.SharedData = Addressables.LoadAssetAsync<SharedTableData>($"{tableCollectionName} Shared Data").WaitForCompletion();
                tableByName.Add(tableCollectionName, table);
                AddressablesUtil.AddResourceAtLocation(localeWithCode, tableNameWithCode, tableNameWithCode, table);
            }
            LocalizationSettings.AvailableLocales.AddLocale(locale);
        }

        public static void AddLocalizedString(string locale, string key, string value)
        {
            if(!StringDatabase.ContainsKey(locale))
                StringDatabase[locale] = new Dictionary<string, string>();
            StringDatabase[locale][key] = value;
        }

        public static string? GetLocalizedString(string locale, string key)
        {
            if (string.IsNullOrEmpty(locale) || string.IsNullOrEmpty(key)) return null;
            if (!StringDatabase.ContainsKey(locale)) return null;
            if (!StringDatabase[locale].ContainsKey(key)) return null;
            return StringDatabase[locale][key];
        }

        internal static void LoadLocalizationFile(string path)
        {
            string locale = Path.GetFileNameWithoutExtension(path);
            string fileText = File.ReadAllText(path);
            Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(fileText) ??
                                              throw new InvalidDataException($"'{path}' is not a valid localization file.");

            foreach(string key in dict.Keys)
                AddLocalizedString(locale, key, dict[key]);

            WinchCore.Log.Debug($"Loaded {dict.Keys.Count.ToString()} localized string(s) from {path}");
        }
    }
}
