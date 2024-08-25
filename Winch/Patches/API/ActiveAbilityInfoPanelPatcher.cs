using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winch.Data.Item;
using static ActiveAbilityInfoPanel;

namespace Winch.Patches.API
{
    [HarmonyPatch(typeof(ActiveAbilityInfoPanel))]
    internal static class ActiveAbilityInfoPanelPatcher
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(ActiveAbilityInfoPanel.RefreshUI))]
        public static bool ActiveAbilityInfoPanel_RefreshUI_Prefix(ActiveAbilityInfoPanel __instance, SpatialItemData spatialItemData, AbilityData abilityData)
        {
            if (spatialItemData != null && spatialItemData is IAbilityItemData abilityItemData)
            {
                var abilityMode = abilityItemData.AbilityMode;
                __instance.abilityMode = abilityMode;

                var qualityIcon = abilityItemData.QualityIcon;
                if (qualityIcon != null)
                {
                    __instance.qualityIcon.sprite = qualityIcon;
                }
                else
                {
                    __instance.qualityIcon.sprite = __instance.GetSpriteForAbilityMode(abilityMode);
                }

                __instance.Show();
                __instance.RefreshItemNameField(spatialItemData);
                __instance.UpdateCatchableSpecies();
                return false;
            }
            return true;
        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(ActiveAbilityInfoPanel.UpdateCatchableSpecies))]
        public static bool ActiveAbilityInfoPanel_UpdateCatchableSpecies_Prefix(ActiveAbilityInfoPanel __instance)
        {
            __instance.UpdateCatchableSpecies(__instance.abilityMode);
            return false;
        }
    }
}
