using HarmonyLib;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.SmartFormat.Core.Formatting;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using UnityEngine.Localization.Tables;
using Winch.Core;

namespace Winch.Patches.API.Localization
{
	[HarmonyPatch]
	public static class LocalizedStringDatabasePatcher
	{
		[HarmonyPrefix]
		[HarmonyPatch(typeof(LocalizedStringDatabase), nameof(LocalizedStringDatabasePatcher.GenerateLocalizedString))]
		public static void GenerateLocalizedString(ref StringTable table, ref StringTableEntry entry, TableReference tableReference, TableEntryReference tableEntryReference, Locale locale)
        {
            GenerateModdedLocalizedString(ref table, ref entry, tableReference, tableEntryReference, locale);
        }

        public static void GenerateModdedLocalizedString(ref StringTable table, ref StringTableEntry entry, TableReference tableReference, TableEntryReference tableEntryReference, Locale locale)
        {
            if (entry == null && table)
            {
                entry = table.GetEntry(tableEntryReference.KeyId, tableEntryReference.Key);
            }
        }
    }
}