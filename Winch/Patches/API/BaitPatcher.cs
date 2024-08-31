﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Winch.Data.Item;
using Winch.Util;

namespace Winch.Patches.API
{
    [HarmonyPatch]
    internal static class BaitPatcher
    {
        public static GameObject? MaterialHarvestPOI = AssetBundleUtil.GetPrefab("materialbaitpoi.bundle", "Assets/DREDGE/Mods/MaterialBaitPOI.prefab");

        [HarmonyPrefix]
        [HarmonyPatch(typeof(BaitAbility), nameof(BaitAbility.Init))]
        public static void BaitAbility_Init_Prefix(BaitAbility __instance)
        {
            __instance.baitItems.AddRange(ItemUtil.ModdedItemDataDict.Values.WhereType<ItemData, BaitItemData>());
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(ItemLogicHandler), nameof(ItemLogicHandler.Awake))]
        public static void ItemLogicHandler_Awake_Postfix(ItemLogicHandler __instance)
        {
            __instance.baitItems.AddRange(ItemUtil.ModdedItemDataDict.Values.WhereType<ItemData, BaitItemData>());
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(PlayerAbilityManager), nameof(PlayerAbilityManager.Awake))]
        public static void PlayerAbilityManager_Awake_Prefix(PlayerAbilityManager __instance)
        {
            var bait = __instance.GetAbilityDataByName("bait");
            bait.linkedItems = bait.linkedItems.Concat(ItemUtil.ModdedItemDataDict.Values.WhereType<ItemData, BaitItemData>()).ToArray();
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(BaitAbility), nameof(BaitAbility.DeployBait))]
        public static bool BaitAbility_DeployBait_Prefix(BaitAbility __instance, SpatialItemInstance baitInstance)
        {
            Debug.Log("[BaitAbility] DeployBait()");
            __instance.DeployBaitModified(baitInstance);
            return false;
        }
    }
}