using HarmonyLib;
using Winch.Patches.API;
using Winch.Patches.API.Localization;

namespace Winch.Patches
{
    internal static class LatePatcher
    {
        /// <summary>
        /// Any unity methods like "Awake" and etc. require patching later or else game explodes for whatever reason. Even just touching the method slightly makes the loading screen go black and spam the error below.
        /// I assume it is because where we originally patch is before unity native dlls load or something.
        /// </summary>
        /*
        System.MissingMethodException:  assembly:<unknown assembly> type:<unknown type> member:(null)
         at (wrapper managed-to-native) UnityEngine.Component.get_gameObject()
         at UnityEngine.UI.Graphic.CacheCanvas()[0x00006]
         at UnityEngine.UI.Graphic.get_canvas() [0x0000e]
         at Coffee.UIExtensions.UIParticleUpdater.Refresh(Coffee.UIExtensions.UIParticle particle) [0x00015]
         at Coffee.UIExtensions.UIParticleUpdater.Refresh() [0x00027]
        */
        public static void Initialize(Harmony harmony)
        {
            harmony.Patch(AccessTools.Method(typeof(LanguageSelectorDropdown), nameof(LanguageSelectorDropdown.Awake)),
                postfix: new HarmonyMethod(AccessTools.Method(typeof(LanguageSelectorDropdownPatcher), nameof(LanguageSelectorDropdownPatcher.Awake))));
        }
    }
}
