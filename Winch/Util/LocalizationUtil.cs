using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Localization;
using Winch.Core;

namespace Winch.Util;

public static class LocalizationUtil
{
    private static Dictionary<string, Dictionary<string, string>> StringDatabase = new Dictionary<string, Dictionary<string, string>>();

    public static LocalizedString CreateReference(string table, string entry) => new LocalizedString(table, entry);
    public static LocalizedString Empty => LocalizationUtil.CreateReference(string.Empty, string.Empty);
    public static LocalizedString Unknown => LocalizationUtil.CreateReference("Strings", "label.unknown");

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

        foreach (string key in dict.Keys)
        {
            AddLocalizedString(locale, key, dict[key]);
        }

        WinchCore.Log.Debug($"Loaded {dict.Keys.Count.ToString()} localized string(s) from {path}");
    }
}
