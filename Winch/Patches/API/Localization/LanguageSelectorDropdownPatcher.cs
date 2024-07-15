using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace Winch.Patches.API.Localization
{
    [HarmonyPatch(typeof(LanguageSelectorDropdown))]
    public static class LanguageSelectorDropdownPatcher
    {
        [HarmonyPatch(nameof(LanguageSelectorDropdown.Awake))]
        [HarmonyPostfix]
        public static void Awake(LanguageSelectorDropdown __instance)
        {
            // Size it to 8 so it doesn't go off screen.
            __instance.mainBoxRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 8 * __instance.heightPerLocale);

            // Enable scrollbar
            var scrollRect = __instance.mainBoxRect.GetComponent<ScrollRect>();
            var scrollbar = __instance.mainBoxRect.GetComponentInChildren<Scrollbar>(true);
            scrollbar.gameObject.SetActive(true);
            scrollRect.verticalScrollbar = scrollbar;
            scrollbar.handleRect = scrollbar.transform.GetChild(0).GetComponentInChildren<Image>().rectTransform;
        }
    }
}
