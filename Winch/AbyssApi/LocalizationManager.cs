using System.Collections.Generic;
using UnityEngine.Localization;

namespace Winch.AbyssApi;

/// <summary>
/// Handles localization for mods
/// </summary>
public static class LocalizationManager
{
    internal static void AddModLocalization(LocalizedModContent localizedModContent)
    {
        localizedModContent.RegisterText(LocalizationDatabase);
    }

    internal static readonly Dictionary<string, string> LocalizationDatabase = new();

    /// <summary>
    /// Creates a localized string with the given key, and adds the value and key to the localization database
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static LocalizedString CreateLocalizedString(string key, string value)
    {
        LocalizationDatabase[key] = value;
        return new LocalizedString("Abyss", key);
    }
}