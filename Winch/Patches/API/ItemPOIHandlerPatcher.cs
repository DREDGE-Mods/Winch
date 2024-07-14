using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API
{
    [HarmonyPatch(typeof(ItemPOIHandler))]
    [HarmonyPatch(nameof(ItemPOIHandler.OnPressComplete))]
    public static class ItemPOIHandlerPatcher
    {
        public static bool SpatialItemFixer(ItemInstance itemInstance)
        {
            if (itemInstance is SpatialItemInstance spatialItemInstance)
                return spatialItemInstance.seen;
            else
                return true;
        }

        public static bool Prefix(ItemPOIHandler __instance)
        {
            Debug.Log("[ItemPOIHandler] OnPressComplete()");

            var item = __instance.itemPOI.Harvestable.GetFirstItem();

            var itemInstance = GameManager.Instance.ItemManager.AddItemById(item.id, GameManager.Instance.SaveData.Inventory, true);
            var deduct = true;

            if (itemInstance is SpatialItemInstance spatialItemInstance)
            {
                if (spatialItemInstance.seen)
                {
                    GameEvents.Instance.TriggerItemAddedEvent(spatialItemInstance, true);

                    if (spatialItemInstance is FishItemInstance fishItemInstance && fishItemInstance.GetItemData<FishItemData>().IsAberration)
                    {
                        SaveData saveData = GameManager.Instance.SaveData;
                        int numAberrationsCaught = saveData.NumAberrationsCaught;
                        saveData.NumAberrationsCaught = numAberrationsCaught + 1;
                    }
                }
                else
                    deduct = false;
            }

            if (deduct)
                GameEvents.Instance.TriggerPlayerInteractedWithPOI();
            else
                GameManager.Instance.UI.ShowNotification(NotificationType.ERROR, "notification.quick-move-failed");

            __instance.itemPOI.OnHarvested(deduct);

            if (deduct)
                GameManager.Instance.Input.RemoveActionListener(new DredgePlayerActionPress[] { __instance.collectItemAction }, ActionLayer.BASE);

            return false;
        }
    }
}
