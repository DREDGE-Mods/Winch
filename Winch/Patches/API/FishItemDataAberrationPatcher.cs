using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core.API;
using Winch.Data.Item;
using Winch.Util;

namespace Winch.Patches.API
{
    [HarmonyPatch(typeof(FishItemData))]
    internal static class FishItemDataAberrationPatcher
    {
        [HarmonyPrefix]
        [HarmonyPatch(nameof(FishItemData.Aberrations), MethodType.Getter)]
        public static void Aberrations_Prefix(FishItemData __instance)
        {
            if (__instance is AberrationableFishItemData aberrationableFishItemData && aberrationableFishItemData.aberrations != null)
            {
                List<FishItemData> aberrations = new List<FishItemData>();
                foreach (var aberration in aberrationableFishItemData.aberrations)
                {
                    if (!string.IsNullOrWhiteSpace(aberration) && ItemUtil.FishItemDataDict.TryGetValue(aberration, out var itemData))
                    {
                        aberrations.Add(itemData);
                    }
                }
                __instance.aberrations = aberrations;
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch(nameof(FishItemData.NonAberrationParent), MethodType.Getter)]
        public static void NonAberrationParent_Prefix(FishItemData __instance)
        {
            if (__instance is AberrationableFishItemData aberrationableFishItemData && !string.IsNullOrWhiteSpace(aberrationableFishItemData.nonAberrationParent))
            {
                ItemUtil.FishItemDataDict.TryGetValue(aberrationableFishItemData.nonAberrationParent, out __instance.nonAberrationParent);
            }
        }
    }
}
