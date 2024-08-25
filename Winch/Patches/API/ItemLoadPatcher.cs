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

        public static void ChangeHarvestables(IList<ItemData> items)
        {
            var harvestables = items.WhereType<ItemData, HarvestableItemData>();
            foreach (var harvestable in harvestables)
            {
                if (harvestable.zonesFoundIn == ZoneEnum.NONE)
                {
                    switch (harvestable.id)
                    {
                        case "flag-3":
                        case "relic1":
                        case "quest-belt-buckle":
                        case "ring-7":
                            harvestable.zonesFoundIn = ZoneEnum.THE_MARROWS;
                            break;
                        case "flag-4":
                        case "relic2":
                        case "quest-crest":
                            harvestable.zonesFoundIn = ZoneEnum.GALE_CLIFFS;
                            break;
                        case "flag-2":
                        case "relic3":
                            harvestable.zonesFoundIn = ZoneEnum.STELLAR_BASIN;
                            break;
                        case "relic4":
                        case "quest-dog-tag":
                        case "quest-mortar-1":
                        case "quest-mortar-2":
                            harvestable.zonesFoundIn = ZoneEnum.TWISTED_STRAND;
                            break;
                        case "flag-5":
                        case "relic5":
                        case "quest-tablet-1":
                        case "quest-tablet-2":
                        case "quest-tablet-3":
                        case "quest-tablet-4":
                            harvestable.zonesFoundIn = ZoneEnum.DEVILS_SPINE;
                            break;
                        case "flag-1":
                        case "flag-6":
                        case "flag-7":
                        case "quest-camera-case":
                            harvestable.zonesFoundIn = ZoneEnum.OPEN_OCEAN;
                            break;
                        case "quest-ice-axe":
                        case "quest-icebreaker-1":
                        case "quest-icebreaker-2":
                        case "quest-icebreaker-3":
                        case "quest-ice-shaper":
                        case "teleport-anchor":
                            harvestable.zonesFoundIn = ZoneEnum.PALE_REACH;
                            break;
                        case "cloth":
                        case "crate":
                        case "lumber":
                        case "metal":
                        case "research-item":
                        case "scrap":
                        case "doubloon":
                        case "bag-doubloon":
                        case "big-bag-doubloon":
                        case "broken-monocle":
                        case "broken-spectacles":
                        case "earring-1":
                        case "earring-2":
                        case "earring-3":
                        case "earring-4":
                        case "earring-5":
                        case "fancy-boot":
                        case "goblet":
                        case "iron-chain":
                        case "ring-1":
                        case "ring-2":
                        case "ring-3":
                        case "ring-4":
                        case "ring-5":
                        case "ring-6":
                        case "sextant":
                        case "silver-plate":
                        case "silver-trinket":
                            harvestable.zonesFoundIn = ZoneEnum.ALL;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public static void Prefix(ItemManager __instance, AsyncOperationHandle<IList<ItemData>> handle)
        {
            if (handle.Result == null || handle.Status != AsyncOperationStatus.Succeeded) return;

            ChangeDredgeCrane(handle.Result);
            ChangeHarvestables(handle.Result);
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
