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
                __instance.abilityMode = abilityItemData.AbilityMode;
                if (abilityItemData.QualityIcon != null)
                {
                    __instance.qualityIcon.sprite = abilityItemData.QualityIcon;
                }
                else
                {
                    __instance.qualityIcon.sprite = __instance.GetSpriteForAbilityMode(abilityItemData.AbilityMode);
                }
                __instance.Show();
                __instance.RefreshItemNameField(spatialItemData);
                __instance.UpdateCatchableSpecies();
                return false;
            }
            return true;
        }

    }
}
