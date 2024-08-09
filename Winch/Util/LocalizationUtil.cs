using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using Winch.Core;

namespace Winch.Util
{
    public static class LocalizationUtil
    {
        internal static readonly string CharactersTableCollectionName = "Characters";
        internal static readonly string ItemsTableCollectionName = "Items";
        internal static readonly string QuestsTableCollectionName = "Quests";
        internal static readonly string StringsTableCollectionName = "Strings";
        internal static readonly string YarnTableCollectionName = "Yarn";

        internal static readonly IReadOnlyList<string> TableCollectionNames = new List<string>()
        {
            CharactersTableCollectionName,
            ItemsTableCollectionName,
            QuestsTableCollectionName,
            StringsTableCollectionName,
            YarnTableCollectionName
        };

        private static Dictionary<string, Dictionary<string, string>> StringDatabase = new Dictionary<string, Dictionary<string, string>>();
        private static Dictionary<string, Dictionary<string, StringTable>> StringTableDict = new Dictionary<string, Dictionary<string, StringTable>>();
        public static LocalizedString Empty => new LocalizedString(string.Empty, string.Empty);
        public static LocalizedString Unknown => new LocalizedString("Strings", "label.unknown");
        public static LocalizedString CreateReference(string table, string entry) => new LocalizedString(table, entry);

        internal static List<Locale> AddedLocales = new List<Locale>();

        public static void InstallLocale(SystemLanguage language) => InstallLocale(Locale.CreateLocale(language));

        public static void InstallLocale(Locale locale)
        {
            locale.name = $"{locale.Identifier.CultureInfo.EnglishName} ({locale.Identifier.Code})";
            locale.hideFlags |= HideFlags.HideAndDontSave;
            locale.CustomFormatterCode = "";
            locale.SortOrder = 0;
            AddedLocales.Add(locale);
            AddressablesUtil.AddResourceAtLocation("Locale", locale.name, locale.name, locale);
            LocalizationSettings.AvailableLocales.AddLocale(locale);
            foreach (var tableCollectionName in TableCollectionNames)
            {
                GetLocaleTableCollection(locale.Identifier.Code, tableCollectionName);
            }
        }

        public static StringTable GetLocaleTableCollection(string locale, string tableCollectionName)
        {
            if (!TableCollectionNames.Contains(tableCollectionName))
                throw new Exception($"'{tableCollectionName}' is not valid table collection name. Valid names are {{{string.Join(", ", TableCollectionNames)}}}");

            if (!StringTableDict.ContainsKey(locale))
                StringTableDict.Add(locale, new Dictionary<string, StringTable>());

            var tableByName = StringTableDict[locale];
            if (!tableByName.ContainsKey(tableCollectionName))
            {
                var tableNameWithCode = $"{tableCollectionName}_{locale}";
                var table = ScriptableObject.CreateInstance<StringTable>();
                table.name = tableNameWithCode;
                tableByName.Add(tableCollectionName, table);
                AddressablesUtil.AddResourceAtLocation("Locale-" + locale, tableNameWithCode, tableNameWithCode, table);
                if (tableCollectionName == QuestsTableCollectionName) // Quests does not have an addressable to grab the shared data directly from
                    table.SharedData = Addressables.LoadAssetAsync<StringTable>($"{tableCollectionName}_en").WaitForCompletion().SharedData;
                else
                    table.SharedData = Addressables.LoadAssetAsync<SharedTableData>($"{tableCollectionName} Shared Data").WaitForCompletion();
            }

            return tableByName[tableCollectionName];
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

            //var stringTable = GetLocaleTableCollection(locale, StringsTableCollectionName);

            foreach (string key in dict.Keys)
            {
                AddLocalizedString(locale, key, dict[key]);
                //stringTable.AddEntry(key, dict[key]);
            }

            WinchCore.Log.Debug($"Loaded {dict.Keys.Count.ToString()} localized string(s) from {path}");
        }

        internal static void LoadLocaleFolder(string folder)
        {
            string locale = Path.GetFileNameWithoutExtension(folder);
            string[] tableCollectionFiles = Directory.GetFiles(folder, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string tableCollection in tableCollectionFiles)
            {
                string tableCollectionName = Path.GetFileNameWithoutExtension(tableCollection);
                try
                {
                    WinchCore.Log.Debug(folder);
                    WinchCore.Log.Info(locale);
                    WinchCore.Log.Warn(tableCollectionName);
                    WinchCore.Log.Error(tableCollection);
                    LoadTableCollectionFolder(locale, tableCollection);
                }
                catch (Exception ex)
                {
                    WinchCore.Log.Error($"Failed to load table collection {tableCollectionName}: {ex}");
                }
            }
        }

        internal static void LoadTableCollectionFolder(string locale, string path)
        {
            string tableCollectionName = Path.GetFileNameWithoutExtension(path);
            string fileText = File.ReadAllText(path);
            Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(fileText) ??
                                              throw new InvalidDataException($"'{path}' is not a valid table collection file.");

            var stringTable = GetLocaleTableCollection(locale, tableCollectionName);

            foreach (string key in dict.Keys)
            {
                AddLocalizedString(locale, key, dict[key]);
                stringTable.AddEntry(key, dict[key]);
            }

            WinchCore.Log.Debug($"Loaded {dict.Keys.Count.ToString()} localized string(s) from {path}");
        }
    }
}
