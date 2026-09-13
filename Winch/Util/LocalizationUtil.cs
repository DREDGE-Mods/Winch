using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using Winch.Core;

namespace Winch.Util;

public static class LocalizationUtil
{
    private static Dictionary<string, Dictionary<string, string>> TranslationDatabase = new Dictionary<string, Dictionary<string, string>>();

    public static LocalizedString CreateReference(string table, string entry)
        => new LocalizedString(table, entry);

    public static LocalizedString CreateReference(string value)
        => CreateReferenceWithDefaultTable(value, LanguageManager.STRING_TABLE);

    public static LocalizedString CreateReferenceWithDefaultTable(string value, string defaultTable)
    {
        var split = value.Split(new[] { ':' }, 2);

        return split.Length == 2
            ? CreateReference(split[0], split[1])
            : CreateReference(defaultTable, value);
    }

    public static LocalizedString CreateStringsReference(string entry)
        => CreateReference(LanguageManager.STRING_TABLE, entry);

    public static LocalizedString CreateItemsReference(string entry)
        => CreateReference(LanguageManager.ITEM_TABLE, entry);

    public static LocalizedString CreateCharactersReference(string entry)
        => CreateReference(LanguageManager.CHARACTER_TABLE, entry);

    public static LocalizedString CreateYarnReference(string entry)
        => CreateReference(LanguageManager.YARN_TABLE, entry);

    public static LocalizedString Empty
        => CreateReference(string.Empty, string.Empty);

    public static LocalizedString Unknown
        => CreateReference(LanguageManager.STRING_TABLE, "label.unknown");

    public static void AddModString(string locale, string key, string value)
    {
        if (!TranslationDatabase.TryGetValue(locale, out var translations))
        {
            translations = new Dictionary<string, string>();
            TranslationDatabase[locale] = translations;
        }

        translations[key] = value;
    }

    public const string EnglishLocaleCode = "en";

    public static void AddEnglishModString(string key, string value)
        => AddModString(EnglishLocaleCode, key, value);

    public static string? GetModString(string locale, string key)
    {
        if (string.IsNullOrEmpty(locale) || string.IsNullOrEmpty(key))
            return null;

        return TranslationDatabase.TryGetValue(locale, out var translations) &&
               translations.TryGetValue(key, out var value)
            ? value
            : null;
    }

    public static string? GetEnglishModString(string key)
        => GetModString(EnglishLocaleCode, key);

    [Obsolete]
    private static string? GetLocalizedString(string locale, string key) => ResolveLocale(CreateStringsReference(key), locale);

    internal static void LoadLocalizationFile(string path)
    {
        string locale = Path.GetFileNameWithoutExtension(path);
        string fileText = File.ReadAllText(path);
        Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(fileText) ??
                                          throw new InvalidDataException($"'{path}' is not a valid localization file.");

        foreach (string key in dict.Keys)
        {
            AddModString(locale, key, dict[key]);
        }

        WinchCore.Log.Debug($"Loaded {dict.Keys.Count.ToString()} localized string(s) from {path}");
    }

    public static LocalizedString Prefer(
        LocalizedString preferred,
        LocalizedString fallback)
    {
        return preferred != null && !preferred.IsEmpty
            ? preferred
            : fallback;
    }

    public static string SerializeReference(LocalizedString localizedString)
    {
        var table = LocalizationSettings.StringDatabase
            .GetTableAsync(localizedString.TableReference)
            .WaitForCompletion();

        var key = localizedString.TableEntryReference
            .ResolveKeyName(table.SharedData);

        return $"{table.TableCollectionName}:{key}";
    }

    public static Locale? GetLocale(string code) =>
        LocalizationSettings.AvailableLocales.Locales.Find(
            locale => locale.Identifier.Code == code
        );

    public static Locale? EnglishLocale =>
        GetLocale(EnglishLocaleCode);

    public static Locale? FrenchLocale =>
        GetLocale("fr");

    public static Locale? ItalianLocale =>
        GetLocale("it");

    public static Locale? GermanLocale =>
        GetLocale("de");

    public static Locale? SpanishLocale =>
        GetLocale("es");

    public static Locale? PortugueseBrazilLocale =>
        GetLocale("pt-BR");

    public static Locale? RussianLocale =>
        GetLocale("ru");

    public static Locale? ChineseSimplifiedLocale =>
        GetLocale("zh-Hans");

    public static Locale? ChineseTraditionalLocale =>
        GetLocale("zh-Hant");

    public static Locale? JapaneseLocale =>
        GetLocale("ja-JP");

    public static Locale? KoreanLocale =>
        GetLocale("ko-KR");

    public static Locale? PolishLocale =>
        GetLocale("pl");

    public static string Resolve(
        LocalizedString reference,
        params object[] arguments)
        => ResolveLocale(reference, LocalizationSettings.SelectedLocale, arguments);

    public static string ResolveEnglish(
        LocalizedString reference,
        params object[] arguments)
        => ResolveLocale(reference, EnglishLocale, arguments);

    public static string ResolveFrench(
        LocalizedString reference,
        params object[] arguments)
        => ResolveLocale(reference, FrenchLocale, arguments);

    public static string ResolveItalian(
        LocalizedString reference,
        params object[] arguments)
        => ResolveLocale(reference, ItalianLocale, arguments);

    public static string ResolveGerman(
        LocalizedString reference,
        params object[] arguments)
        => ResolveLocale(reference, GermanLocale, arguments);

    public static string ResolveSpanish(
        LocalizedString reference,
        params object[] arguments)
        => ResolveLocale(reference, SpanishLocale, arguments);

    public static string ResolvePortugueseBrazil(
        LocalizedString reference,
        params object[] arguments)
        => ResolveLocale(reference, PortugueseBrazilLocale, arguments);

    public static string ResolveRussian(
        LocalizedString reference,
        params object[] arguments)
        => ResolveLocale(reference, RussianLocale, arguments);

    public static string ResolveChineseSimplified(
        LocalizedString reference,
        params object[] arguments)
        => ResolveLocale(reference, ChineseSimplifiedLocale, arguments);

    public static string ResolveChineseTraditional(
        LocalizedString reference,
        params object[] arguments)
        => ResolveLocale(reference, ChineseTraditionalLocale, arguments);

    public static string ResolveJapanese(
        LocalizedString reference,
        params object[] arguments)
        => ResolveLocale(reference, JapaneseLocale, arguments);

    public static string ResolveKorean(
        LocalizedString reference,
        params object[] arguments)
        => ResolveLocale(reference, KoreanLocale, arguments);

    public static string ResolvePolish(
        LocalizedString reference,
        params object[] arguments)
        => ResolveLocale(reference, PolishLocale, arguments);

    public static string ResolveLocale(
        LocalizedString reference,
        string code,
        params object[] arguments)
        => ResolveLocale(reference, GetLocale(code), arguments);

    public static string ResolveLocale(
        LocalizedString reference,
        Locale? locale,
        params object[] arguments)
    {
        return LocalizationSettings.StringDatabase
            .GetLocalizedString(
                reference.TableReference,
                reference.TableEntryReference,
                locale,
                FallbackBehavior.UseProjectSettings,
                arguments
            );
    }
}
