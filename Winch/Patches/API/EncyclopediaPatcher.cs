using HarmonyLib;
using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core;
using Winch.Core.API;
using Winch.Serialization.Item;
using Winch.Util;

namespace Winch.Patches.API
{
    [HarmonyPatch(typeof(Encyclopedia))]
    internal static class EncyclopediaPatcher
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(Encyclopedia.OnZoneButtonClicked))]
        public static bool GetZoneButtonIndexByFishData_Postfix(Encyclopedia __instance, int i)
        {
            if (i == (__instance.aberrationTabIndex + 1))
            {
                WinchCore.Log.Debug(string.Format("[Encyclopedia] OnZoneButtonClicked({0}) finding modded fish.", i));
                __instance.currentIndex = __instance.currentFishList.FindIndex(ItemUtil.ModdedItemDataDict.ContainsValue);
                __instance.RefreshUI();
                return false;
            }
            return true;
        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(Encyclopedia.GetZoneButtonIndexByFishData))]
        public static bool GetZoneButtonIndexByFishData_Prefix(Encyclopedia __instance, ref int __result, FishItemData currentFishData)
        {
            if (ItemUtil.ModdedItemDataDict.ContainsValue(currentFishData))
            {
                __result = __instance.aberrationTabIndex + 1;
                return false;
            }
            return true;
        }
    }
}
