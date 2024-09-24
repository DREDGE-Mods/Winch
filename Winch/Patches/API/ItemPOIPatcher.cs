using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Winch.Core;
using Winch.Core.API;

namespace Winch.Patches.API;

[HarmonyPatch]
internal static class ItemPOIPatcher
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
    [HarmonyPrefix]
    [HarmonyPatch(typeof(ItemPOIHandler), nameof(ItemPOIHandler.OnPressComplete))]
    public static bool ItemPOIHandler_OnPressComplete_Prefix(ItemPOIHandler __instance)
    {
        WinchCore.Log.Debug("[ItemPOIHandler] OnPressComplete()");

        GameEvents.Instance.TriggerPlayerInteractedWithPOI();

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

        var success = true;
        if (itemInstance is SpatialItemInstance spatialItemInstance)
        {
            if (spatialItemInstance.seen)
            {
                GameEvents.Instance.TriggerItemAddedEvent(spatialItemInstance, true);
                if (spatialItemInstance is FishItemInstance fishItemInstance)
                {
                    if (fishItemInstance.GetItemData<FishItemData>().IsAberration)
                        GameManager.Instance.SaveData.NumAberrationsCaught += 1;

                    GameEvents.Instance.TriggerFishCaught(fishItemInstance);
                }
            }
            else
                success = false;
        }

        if (success)
        {
            itemPOI.OnHarvested(true);
            GameManager.Instance.Input.RemoveActionListener(new DredgePlayerActionPress[] { __instance.collectItemAction }, ActionLayer.BASE);
            DredgeEvent.TriggerPOIItemCollected(itemPOI, itemInstance);
        }
        else
            GameManager.Instance.UI.ShowNotification(NotificationType.ERROR, "notification.quick-move-failed");

        return false;
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(ItemManager), nameof(ItemManager.OnItemDestroyed))]
    public static bool ItemManager_OnItemDestroyed_Prefix(ItemManager __instance, ItemData itemData, bool playerDestroyed)
    {
        if ((itemData is HarvestableItemData harvestableItemData && harvestableItemData.regenHarvestSpotOnDestroy) || itemData is not HarvestableItemData)
            __instance.StartCoroutine(__instance.FindAndRegenHarvestSpot(itemData));
        return false;
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(ItemManager), nameof(ItemManager.FindAndRegenHarvestSpot))]
    public static bool ItemManager_FindAndRegenHarvestSpot_Postfix(ItemManager __instance, ItemData itemData, ref IEnumerator __result)
    {
        __result = __instance.FindAndRegenHarvestAndItemSpots(itemData);
        return false;
    }
}