using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API;

[HarmonyPatch(typeof(GridManager))]
[HarmonyPatch(nameof(GridManager.TryPlaceObject))]
internal static class GridManagerTryPlaceObjectPatcher
{
    /// <summary>
    /// Fix nets ignoring slots that only accept certain types.
    /// </summary>
    public static bool Prefix(GridManager __instance)
    {
        if (!__instance.currentlyHeldObject)
            return false;

        GridCell currentRootCell = __instance.currentlyHeldObject.GetCurrentRootCell();
        if (currentRootCell && currentRootCell.ParentGrid && __instance.currentlyHeldObject.GetCurrentRootPositionWithRotation(out Vector3Int currentRootPosition))
        {
            SpatialItemData currentItemData = __instance.currentlyHeldObject.ItemData;
            if (currentRootCell.ParentGrid.linkedGrid.GetCellsAffectedByObjectAtPosition(currentItemData.dimensions, currentRootPosition)
                .All(gcd => gcd.DoesCellAcceptItem(currentItemData)))
            {
                currentRootCell.ParentGrid.TryPlaceObject(__instance.currentlyHeldObject);
                return false;
            }
        }

        __instance.NotifyOfPlacementAttempt(__instance.currentlyHeldObject, false);
        return false;
    }
}