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

        /// <summary>
        /// Fix item poi handler to not decrease stock when item cannot fit
        /// 
        /// I made a transpiler for this but it ended up never working. It was fine when I did the exact thing in dnSpy but for whatever reason Harmony just spat out "Invalid IL Code".
        /// So I gave in and just went for the prefix instead.
        /// </summary>
        public static bool Prefix(ItemPOIHandler __instance)
        {
            WinchCore.Log.Debug("[ItemPOIHandler] OnPressComplete()");

            var itemPOI = __instance.itemPOI;
            var harvestable = itemPOI.Harvestable;
            var item = harvestable.GetFirstItem();
            if (item == null)
            {
                WinchCore.Log.Error($"[ItemPOIHandler] {harvestable.GetId()} does not have any item you can pick up.");
                GameManager.Instance.Input.RemoveActionListener(new DredgePlayerActionPress[] { __instance.collectItemAction }, ActionLayer.BASE);
                return false;
            }

            var itemInstance = GameManager.Instance.ItemManager.AddItemById(item.id, GameManager.Instance.SaveData.Inventory, true);

            if (itemInstance == null)
                return false;

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

            itemPOI.OnHarvested(deduct);

            if (deduct)
                GameManager.Instance.Input.RemoveActionListener(new DredgePlayerActionPress[] { __instance.collectItemAction }, ActionLayer.BASE);

            return false;
        }
    }
}
