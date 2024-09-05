using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API
{
    //[HarmonyPatch(typeof(ItemManager))]
    //[HarmonyPatch(nameof(ItemManager.OnItemDataAddressablesLoaded))]
    class ItemLoadPatcher
    {
        public static void Prefix(ItemManager __instance, AsyncOperationHandle<IList<ItemData>> handle)
        {
            ItemUtil.AddModdedItemData(handle.Result);
            DredgeEvent.AddressableEvents.ItemsLoaded.Trigger(__instance, handle, true);
        }

        public static void Postfix(ItemManager __instance, AsyncOperationHandle<IList<ItemData>> handle)
        {
            ItemUtil.PopulateItemData();
            DredgeEvent.AddressableEvents.ItemsLoaded.Trigger(__instance, handle, false);
        }
    }
}
