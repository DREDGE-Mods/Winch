using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winch.Data.Item;

namespace Winch.Patches.API
{
    [HarmonyPatch(typeof(ActiveAbilityInfoPanel))]
    internal static class ActiveAbilityInfoPanelPatcher
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(ActiveAbilityInfoPanel.RefreshUI))]
        public static bool ActiveAbilityInfoPanel_RefreshUI_Prefix(ActiveAbilityInfoPanel __instance, SpatialItemData spatialItemData, AbilityData abilityData)
        {
            if (abilityData.name == __instance.potAbility.name)
            {
                if (spatialItemData != null && spatialItemData is CrabPotItemData potData)
                {
                    __instance.abilityMode = potData.abilityMode;
                    if (potData.qualityIcon != null)
                    {
                        __instance.qualityIcon.sprite = potData.qualityIcon;
                    }
                    else
                    {
                        __instance.qualityIcon.sprite = __instance.GetSpriteForAbilityMode(potData.abilityMode);
                    }
                    __instance.Show();
                    __instance.RefreshItemNameField(potData);
                    __instance.UpdateCatchableSpecies();
                    return false;
                }
            }
            else if (abilityData.name == __instance.trawlAbility.name)
            {
                if (spatialItemData != null && spatialItemData is TrawlNetItemData trawlNetData)
                {
                    __instance.abilityMode = trawlNetData.abilityMode;
                    if (trawlNetData.qualityIcon != null)
                    {
                        __instance.qualityIcon.sprite = trawlNetData.qualityIcon;
                    }
                    else
                    {
                        __instance.qualityIcon.sprite = __instance.GetSpriteForAbilityMode(trawlNetData.abilityMode);
                    }
                    __instance.Show();
                    __instance.RefreshItemNameField(trawlNetData);
                    __instance.UpdateCatchableSpecies();
                    return false;
                }
            }
            return true;
        }

    }
}
