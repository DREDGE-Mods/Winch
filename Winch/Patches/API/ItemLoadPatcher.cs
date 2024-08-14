using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using Winch.Core;
using Winch.Core.API;
using Winch.Util;

namespace Winch.Patches.API
{
    [HarmonyPatch(typeof(ItemManager))]
    [HarmonyPatch(nameof(ItemManager.OnItemDataAddressablesLoaded))]
    class ItemLoadPatcher
    {
        public static void ChangeDredgeCrane(IList<ItemData> items)
        {
            var dredge1 = items.WhereType<ItemData, DredgeItemData>().FirstOrDefault(dredge => dredge.id == "dredge1");
            if (dredge1 != null)
            {
                dredge1.itemTypeIcon = TextureUtil.GetSprite("DredgeIcon");
            }
        }

        public static void Prefix(ItemManager __instance, AsyncOperationHandle<IList<ItemData>> handle)
        {
            if (handle.Result == null || handle.Status != AsyncOperationStatus.Succeeded) return;

            ChangeDredgeCrane(handle.Result);
            ItemUtil.AddModdedItemData(handle.Result);
            DredgeEvent.AddressableEvents.ItemsLoaded.Trigger(__instance, handle, true);
        }

        public static void Postfix(ItemManager __instance, AsyncOperationHandle<IList<ItemData>> handle)
        {
            if (handle.Result == null || handle.Status != AsyncOperationStatus.Succeeded) return;

            ItemUtil.PopulateItemData(handle.Result);
            DredgeEvent.AddressableEvents.ItemsLoaded.Trigger(__instance, handle, false);
        }
    }
}
