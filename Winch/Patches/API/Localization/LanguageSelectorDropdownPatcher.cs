using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace Winch.Patches.API.Localization
{
    [HarmonyPatch]
    internal static class LanguageSelectorDropdownPatcher
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(LanguageSelectorDropdown), nameof(LanguageSelectorDropdown.Awake))]
        public static void Awake(LanguageSelectorDropdown __instance)
        {
            // Size it to 8 so it doesn't go off screen.
            __instance.mainBoxRect.SetHeight(8 * __instance.heightPerLocale);

            // Enable scrollbar
            var scrollRect = __instance.mainBoxRect.GetComponent<ScrollRect>();
            var scrollbar = __instance.mainBoxRect.GetComponentInChildren<Scrollbar>(true);
            scrollbar.gameObject.SetActive(true);
            scrollRect.verticalScrollbar = scrollbar;
            scrollbar.handleRect = scrollbar.transform.GetChild(0).GetComponentInChildren<Image>().rectTransform;
        }
    }
}
