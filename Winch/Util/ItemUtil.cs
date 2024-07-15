using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using DG.Tweening;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Localization;
using Winch.Core;
using Winch.Serialization;
using Winch.Serialization.Item;
using System.Text.RegularExpressions;
using UnityEngine.UI;

namespace Winch.Util;

internal static class ItemUtil
{
    private static readonly Dictionary<Type, IDredgeTypeConverter> Converters = new()
    {
        { typeof(NonSpatialItemData), new NonSpatialItemDataConverter() },
        { typeof(MessageItemData), new MessageItemDataConverter() },
        { typeof(ResearchableItemData), new ResearchableItemDataConverter() },
        { typeof(SpatialItemData), new SpatialItemDataConverter() },
        { typeof(EngineItemData), new EngineItemDataConverter() },
        { typeof(HarvestableItemData), new HarvestableItemDataConverter() },
        { typeof(AberrationableFishItemData), new FishItemDataConverter() },
        { typeof(RelicItemData), new RelicItemDataConverter() },
        { typeof(GridConfigDeployableItemData), new DeployableItemDataConverter() },
        { typeof(CrabPotItemData), new CrabPotItemDataConverter() },
        { typeof(TrawlNetItemData), new TrawlNetItemDataConverter() },
        { typeof(DredgeItemData), new DredgeItemDataConverter() },
        { typeof(RodItemData), new RodItemDataConverter() },
        { typeof(LightItemData), new LightItemDataConverter() },
        { typeof(DamageItemData), new DamageItemDataConverter() },
        { typeof(DurableItemData), new DurableItemDataConverter() },
    };

    public static bool PopulateObjectFromMetaWithConverters<T>(T item, Dictionary<string, object> meta) where T : ItemData
    {
        return UtilHelpers.PopulateObjectFromMeta<T>(item, meta, Converters);
    }

    public static Dictionary<string, HarvestableItemData> HarvestableItemDataDict = new();
    public static Dictionary<string, FishItemData> FishItemDataDict = new();
    public static Dictionary<string, ItemData> AllItemDataDict = new();
    public static Dictionary<string, ItemData> ModdedItemDataDict = new();

    public static void AddModdedItemData()
    {
        foreach (var item in ModdedItemDataDict.Values)
        {
            GameManager.Instance.ItemManager.allItems.Add(item);
        }
    }

    /// <summary>
    /// Encyclopedia doesn't run <see cref="Encyclopedia.Awake"/> until it is opened so we just search for it with Resources and add the fish
    /// </summary>
    public static void Encyclopedia()
    {
        WinchCore.Log.Info("[Encyclopedia] AddModdedFishItemData");
        var encyclopedia = Resources.FindObjectsOfTypeAll<Encyclopedia>().FirstOrDefault();
        AddModdedFishItemData(encyclopedia.allFish);
        AddModdedEncyclopediaButton(encyclopedia);
    }

    public static void AddModdedEncyclopediaButton(Encyclopedia encyclopedia)
    {
        var container = encyclopedia.transform.parent.gameObject;
        container.SetActive(true);
        container.SetActive(false);
        var zones = encyclopedia.dlc1ZoneButton.transform.parent as RectTransform;
        zones.sizeDelta = new Vector2(zones.sizeDelta.x, zones.sizeDelta.y + 50);
        var moddedButton = encyclopedia.dlc1ZoneButton.gameObject.InstantiateInactive();
        moddedButton.transform.SetParent(zones, false);
        var moddedButtonWrapper = moddedButton.GetComponent<BasicButtonWrapper>();
        moddedButtonWrapper.localizedString.StringReference = new LocalizedString("Strings", "label.unknown");
        moddedButton.name = "ModdedEncyclopediaTabButton";
        moddedButton.SetActive(true);
        encyclopedia.zoneButtons.Add(moddedButtonWrapper);
        encyclopedia.SetZoneButtonPositions();
        var image = moddedButton.GetComponent<Image>();
        image.sprite = TextureUtil.GetSprite("EncyclopediaTabWinch");
    }


    public static void AddModdedItemData(IList<ItemData> list)
    {
        foreach (var item in ModdedItemDataDict.Values)
        {
            list.SafeAdd(item);
        }
    }

    public static void AddModdedFishItemData(IList<FishItemData> list)
    {
        foreach (var item in ModdedItemDataDict.Values.WhereType<ItemData, FishItemData>())
        {
            list.SafeAdd(item);
        }
    }

    public static List<ItemData> TryGetItems(List<string> ids)
    {
        List<ItemData> items = new List<ItemData>();

        if (ids == null)
            return items;

        foreach (var item in ids)
        {
            if (!string.IsNullOrWhiteSpace(item) && AllItemDataDict.TryGetValue(item, out var itemData))
            {
                items.Add(itemData);
            }
        }

        return items;
    }

    public static List<HarvestableItemData> TryGetHarvestables(List<string> ids)
    {
        List<HarvestableItemData> harvestables = new List<HarvestableItemData>();

        if (ids == null)
            return harvestables;

        foreach (var harvestable in ids)
        {
            if (!string.IsNullOrWhiteSpace(harvestable) && HarvestableItemDataDict.TryGetValue(harvestable, out var itemData))
            {
                harvestables.Add(itemData);
            }
        }

        return harvestables;
    }

    public static void PopulateItemData()
    {
        foreach (var item in GameManager.Instance.ItemManager.allItems)
        {
            AllItemDataDict.Add(item.id, item);
            WinchCore.Log.Debug($"Added item {item.id} to AllItemDataDict");
            if (item is HarvestableItemData hitem) // Fish and Relics
            {
                HarvestableItemDataDict.Add(item.id, hitem);
                WinchCore.Log.Debug($"Added item {item.id} to HarvestableItemDataDict");
                if (hitem is FishItemData fitem)
                {
                    FishItemDataDict.Add(item.id, fitem);
                    WinchCore.Log.Debug($"Added item {item.id} to FishItemDataDict");
                }
            }
        }
    }

    public static void ClearItemData()
    {
        AllItemDataDict.Clear();
        WinchCore.Log.Debug($"AllItemDataDict cleared");
        HarvestableItemDataDict.Clear();
        WinchCore.Log.Debug($"HarvestableItemDataDict cleared");
        FishItemDataDict.Clear();
        WinchCore.Log.Debug($"FishItemDataDict cleared");
    }

    internal static void AddItemFromMeta<T>(string metaPath) where T : ItemData
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }
        var item = UtilHelpers.GetScriptableObjectFromMeta<T>(meta, metaPath);
        if (item == null)
        {
            WinchCore.Log.Error($"Couldn't create {typeof(T).FullName}");
            return;
        }
        var id = (string)meta["id"];
        if (ModdedItemDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate item {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateObjectFromMetaWithConverters<T>(item, meta))
        {
            ModdedItemDataDict.Add(id, item);
        }
        else
        {
            WinchCore.Log.Error($"No item data converter found for type {typeof(T)}");
        }
    }
}
