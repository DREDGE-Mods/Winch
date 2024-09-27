using HarmonyLib;
using UnityEngine;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch]
internal static class DredgeSlotPatcher
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(GridCell), nameof(GridCell.OnItemHoveredChanged))]
    public static void GridCell_OnItemHoveredChanged_Postfix(GridCell __instance, GridObject gridObject)
    {
        if (!GameManager.Instance.GridManager.IsCurrentlyHoldingObject())
        {
            if (gridObject && gridObject.state != GridObjectState.IN_INVENTORY && gridObject.ItemData.itemSubtype == ItemSubtype.DREDGE && __instance.acceptedItemSubtype.HasFlag(gridObject.ItemData.itemSubtype))
            {
                __instance.ToggleHighlightAcceptedItemTypeImage(true);
            }
        }
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(GridCell), nameof(GridCell.OnItemPickedUp))]
    public static void GridCell_OnItemPickedUp_Postfix(GridCell __instance, GridObject gridObject)
    {
        if (gridObject.ItemData.itemSubtype == ItemSubtype.DREDGE && __instance.acceptedItemSubtype.HasFlag(gridObject.ItemData.itemSubtype))
        {
            __instance.ToggleHighlightAcceptedItemTypeImage(true);
        }
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(GridCell), nameof(GridCell.GetSpriteForItemType))]
    public static bool GridCell_GetSpriteForItemType_Prefix(ref Sprite __result, ItemSubtype subtype)
    {
        if (subtype.HasFlag(ItemSubtype.DREDGE))
        {
            __result = TextureUtil.GetSprite("DredgeEquipmentIcon");
            return false;
        }
        return true;
    }
}
