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
using Winch.Data.Item;
using UnityEngine.AddressableAssets;

namespace Winch.Util;

public static class ItemUtil
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
        { typeof(ThawableItemData), new ThawableItemDataConverter() },
        { typeof(GadgetItemData), new GadgetItemDataConverter() },
        { typeof(BaitItemData), new BaitItemDataConverter() },
    };

    internal static bool PopulateObjectFromMetaWithConverters<T>(T item, Dictionary<string, object> meta) where T : ItemData
    {
        return UtilHelpers.PopulateObjectFromMeta<T>(item, meta, Converters);
    }

    internal static List<string> VanillaItemIDList = new();

    internal static void Initialize()
    {
        Addressables.LoadAssetsAsync<ItemData>(AddressablesUtil.GetLocations<ItemData>("ItemData"), itemData => VanillaItemIDList.SafeAdd(itemData.id));
    }

    internal static Dictionary<string, ItemData> AllItemDataDict = new();
    internal static Dictionary<string, SpatialItemData> SpatialItemDataDict = new();
    internal static Dictionary<string, HarvestableItemData> HarvestableItemDataDict = new();
    internal static Dictionary<string, FishItemData> FishItemDataDict = new();
    internal static Dictionary<string, RelicItemData> RelicItemDataDict = new();
    internal static Dictionary<string, HarvesterItemData> HarvesterItemDataDict = new();
    internal static Dictionary<string, DeployableItemData> DeployableItemDataDict = new();
    internal static Dictionary<string, DeployableItemData> NetItemDataDict = new();
    internal static Dictionary<string, DeployableItemData> PotItemDataDict = new();
    internal static Dictionary<string, DredgeItemData> DredgeItemDataDict = new();
    internal static Dictionary<string, RodItemData> RodItemDataDict = new();
    internal static Dictionary<string, DurableItemData> DurableItemDataDict = new();
    internal static Dictionary<string, DurableItemData> ThawableItemDataDict = new();
    internal static Dictionary<string, GadgetItemData> GadgetItemDataDict = new();
    internal static Dictionary<string, EngineItemData> EngineItemDataDict = new();
    internal static Dictionary<string, LightItemData> LightItemDataDict = new();
    internal static Dictionary<string, SpatialItemData> BaitItemDataDict = new();
    internal static Dictionary<string, NonSpatialItemData> NonSpatialItemDataDict = new();
    internal static Dictionary<string, MessageItemData> MessageItemDataDict = new();
    internal static Dictionary<string, ResearchableItemData> ResearchableItemDataDict = new();
    internal static Dictionary<string, ItemData> ModdedItemDataDict = new();

    public static ItemData GetModdedItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedItemDataDict.TryGetValue(id, out ItemData itemData))
            return itemData;
        else
            return null;
    }

    public static ItemData GetItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (AllItemDataDict.TryGetValue(id, out ItemData itemData))
            return itemData;

        if (ModdedItemDataDict.TryGetValue(id, out ItemData moddedItemData))
            return moddedItemData;

        return null;
    }

    public static SpatialItemData GetSpatialItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (SpatialItemDataDict.TryGetValue(id, out SpatialItemData itemData))
            return itemData;

        return null;
    }

    public static HarvestableItemData GetHarvestableItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (HarvestableItemDataDict.TryGetValue(id, out HarvestableItemData itemData))
            return itemData;

        return null;
    }

    public static FishItemData GetFishItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (FishItemDataDict.TryGetValue(id, out FishItemData itemData))
            return itemData;

        return null;
    }

    public static RelicItemData GetRelicItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (RelicItemDataDict.TryGetValue(id, out RelicItemData itemData))
            return itemData;

        return null;
    }

    public static HarvesterItemData GetHarvesterItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (HarvesterItemDataDict.TryGetValue(id, out HarvesterItemData itemData))
            return itemData;

        return null;
    }

    public static DeployableItemData GetDeployableItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (DeployableItemDataDict.TryGetValue(id, out DeployableItemData itemData))
            return itemData;

        return null;
    }

    public static DeployableItemData GetTrawlNetItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (NetItemDataDict.TryGetValue(id, out DeployableItemData itemData))
            return itemData;

        return null;
    }

    public static DeployableItemData GetCrabPotItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (PotItemDataDict.TryGetValue(id, out DeployableItemData itemData))
            return itemData;

        return null;
    }

    public static DredgeItemData GetDredgeItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (DredgeItemDataDict.TryGetValue(id, out DredgeItemData itemData))
            return itemData;

        return null;
    }

    public static RodItemData GetRodItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (RodItemDataDict.TryGetValue(id, out RodItemData itemData))
            return itemData;

        return null;
    }

    public static DurableItemData GetDurableItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (DurableItemDataDict.TryGetValue(id, out DurableItemData itemData))
            return itemData;

        return null;
    }

    public static DurableItemData GetThawableItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ThawableItemDataDict.TryGetValue(id, out DurableItemData itemData))
            return itemData;

        return null;
    }

    public static GadgetItemData GetGadgetItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (GadgetItemDataDict.TryGetValue(id, out GadgetItemData itemData))
            return itemData;

        return null;
    }

    public static EngineItemData GetEngineItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (EngineItemDataDict.TryGetValue(id, out EngineItemData itemData))
            return itemData;

        return null;
    }

    public static LightItemData GetLightItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (LightItemDataDict.TryGetValue(id, out LightItemData itemData))
            return itemData;

        return null;
    }

    public static SpatialItemData GetBaitItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (BaitItemDataDict.TryGetValue(id, out SpatialItemData itemData))
            return itemData;

        return null;
    }

    public static NonSpatialItemData GetNonSpatialItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (NonSpatialItemDataDict.TryGetValue(id, out NonSpatialItemData itemData))
            return itemData;

        return null;
    }

    public static MessageItemData GetMessageItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (MessageItemDataDict.TryGetValue(id, out MessageItemData itemData))
            return itemData;

        return null;
    }

    public static ResearchableItemData GetResearchableItemData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ResearchableItemDataDict.TryGetValue(id, out ResearchableItemData itemData))
            return itemData;

        return null;
    }

    internal static void AddModdedItemData(IList<ItemData> list)
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

    /// <summary>
    /// Encyclopedia doesn't run <see cref="Encyclopedia.Awake"/> until it is opened so we just search for it with Resources and add the fish
    /// </summary>
    internal static void Encyclopedia()
    {
        WinchCore.Log.Info("[Encyclopedia] AddModdedFishItemData");
        var encyclopedia = Resources.FindObjectsOfTypeAll<Encyclopedia>().FirstOrDefault();
        AddModdedFishItemData(encyclopedia.allFish);
        AddModdedEncyclopediaButton(encyclopedia);
    }

    internal static void AddModdedEncyclopediaButton(Encyclopedia encyclopedia)
    {
        var container = encyclopedia.transform.parent.gameObject;
        container.SetActive(true);
        container.SetActive(false);
        var zones = encyclopedia.dlc1ZoneButton.transform.parent as RectTransform;
        zones.sizeDelta = new Vector2(zones.sizeDelta.x, zones.sizeDelta.y + 50);
        var moddedButton = encyclopedia.dlc1ZoneButton.gameObject.InstantiateInactive();
        moddedButton.transform.SetParent(zones, false);
        var moddedButtonWrapper = moddedButton.GetComponent<BasicButtonWrapper>();
        moddedButtonWrapper.localizedString.StringReference = LocalizationUtil.Unknown;
        moddedButton.name = "ModdedEncyclopediaTabButton";
        moddedButton.SetActive(true);
        encyclopedia.zoneButtons.Add(moddedButtonWrapper);
        encyclopedia.SetZoneButtonPositions();
        var image = moddedButton.GetComponent<Image>();
        image.sprite = TextureUtil.GetSprite("EncyclopediaTabWinch");
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

    public static List<FishItemData> TryGetFish(List<string> ids)
    {
        List<FishItemData> fishes = new List<FishItemData>();

        if (ids == null)
            return fishes;

        foreach (var fish in ids)
        {
            if (!string.IsNullOrWhiteSpace(fish) && FishItemDataDict.TryGetValue(fish, out var itemData))
            {
                fishes.Add(itemData);
            }
        }

        return fishes;
    }

    internal static void PopulateItemData(IList<ItemData> result)
    {
        foreach (var item in result)
        {
            AllItemDataDict.Add(item.id, item);
            WinchCore.Log.Debug($"Added item {item.id} to AllItemDataDict");
            if (item is SpatialItemData sitem)
            {
                SpatialItemDataDict.Add(item.id, sitem);
                WinchCore.Log.Debug($"Added item {item.id} to SpatialItemDataDict");
                if (item is HarvestableItemData hitem) // Fish and Relics
                {
                    HarvestableItemDataDict.Add(item.id, hitem);
                    WinchCore.Log.Debug($"Added item {item.id} to HarvestableItemDataDict");
                    if (hitem is FishItemData fitem)
                    {
                        FishItemDataDict.Add(item.id, fitem);
                        WinchCore.Log.Debug($"Added item {item.id} to FishItemDataDict");
                    }
                    else if (hitem is RelicItemData rcitem)
                    {
                        RelicItemDataDict.Add(item.id, rcitem);
                        WinchCore.Log.Debug($"Added item {item.id} to RelicItemDataDict");
                    }
                }
                else if (item is HarvesterItemData hritem)
                {
                    HarvesterItemDataDict.Add(item.id, hritem);
                    WinchCore.Log.Debug($"Added item {item.id} to HarvesterItemDataDict");
                    if (hritem is DeployableItemData deitem)
                    {
                        DeployableItemDataDict.Add(item.id, deitem);
                        WinchCore.Log.Debug($"Added item {item.id} to DeployableItemDataDict");
                        if (deitem.itemSubtype == ItemSubtype.NET || deitem is TrawlNetItemData)
                        {
                            NetItemDataDict.Add(item.id, deitem);
                            WinchCore.Log.Debug($"Added item {item.id} to NetItemDataDict");
                        }
                        else if (deitem.itemSubtype == ItemSubtype.POT || deitem is CrabPotItemData)
                        {
                            PotItemDataDict.Add(item.id, deitem);
                            WinchCore.Log.Debug($"Added item {item.id} to PotItemDataDict");
                        }
                    }
                    else if (hritem is DredgeItemData dritem)
                    {
                        DredgeItemDataDict.Add(item.id, dritem);
                        WinchCore.Log.Debug($"Added item {item.id} to DredgeItemDataDict");
                    }
                    else if (hritem is RodItemData rditem)
                    {
                        RodItemDataDict.Add(item.id, rditem);
                        WinchCore.Log.Debug($"Added item {item.id} to RodItemDataDict");
                    }
                }
                else if (item is DurableItemData ditem)
                {
                    if (ditem.IsDurable())
                    {
                        DurableItemDataDict.Add(item.id, ditem);
                        WinchCore.Log.Debug($"Added item {item.id} to DurableItemDataDict");
                    }
                    else if (ditem.IsThawable())
                    {
                        ThawableItemDataDict.Add(item.id, ditem);
                        WinchCore.Log.Debug($"Added item {item.id} to ThawableItemDataDict");
                    }
                }
                else if (item is GadgetItemData gitem)
                {
                    GadgetItemDataDict.Add(item.id, gitem);
                    WinchCore.Log.Debug($"Added item {item.id} to GadgetItemDataDict");
                }
                else if (item is EngineItemData eitem)
                {
                    EngineItemDataDict.Add(item.id, eitem);
                    WinchCore.Log.Debug($"Added item {item.id} to EngineItemDataDict");
                }
                else if (item is LightItemData litem)
                {
                    LightItemDataDict.Add(item.id, litem);
                    WinchCore.Log.Debug($"Added item {item.id} to LightItemDataDict");
                }
                else if (item.id.StartsWith("bait") || item is BaitItemData)
                {
                    BaitItemDataDict.Add(item.id, sitem);
                    WinchCore.Log.Debug($"Added item {item.id} to BaitItemDataDict");
                }
            }
            else if (item is NonSpatialItemData nsitem)
            {
                NonSpatialItemDataDict.Add(item.id, nsitem);
                WinchCore.Log.Debug($"Added item {item.id} to NonSpatialItemDataDict");
                if (nsitem is MessageItemData mitem)
                {
                    MessageItemDataDict.Add(item.id, mitem);
                    WinchCore.Log.Debug($"Added item {item.id} to MessageItemDataDict");
                }
                else if (nsitem is ResearchableItemData ritem)
                {
                    ResearchableItemDataDict.Add(item.id, ritem);
                    WinchCore.Log.Debug($"Added item {item.id} to ResearchableItemDataDict");
                }
            }
        }
    }

    internal static void ClearItemData()
    {
        AllItemDataDict.Clear();
        WinchCore.Log.Debug($"AllItemDataDict cleared");
        SpatialItemDataDict.Clear();
        WinchCore.Log.Debug($"SpatialItemDataDict cleared");
        HarvesterItemDataDict.Clear();
        WinchCore.Log.Debug($"HarvesterItemDataDict cleared");
        DeployableItemDataDict.Clear();
        WinchCore.Log.Debug($"DeployableItemDataDict cleared");
        NetItemDataDict.Clear();
        WinchCore.Log.Debug($"NetItemDataDict cleared");
        PotItemDataDict.Clear();
        WinchCore.Log.Debug($"PotItemDataDict cleared");
        DredgeItemDataDict.Clear();
        WinchCore.Log.Debug($"DredgeItemDataDict cleared");
        RodItemDataDict.Clear();
        WinchCore.Log.Debug($"RodItemDataDict cleared");
        DurableItemDataDict.Clear();
        WinchCore.Log.Debug($"DurableItemDataDict cleared");
        ThawableItemDataDict.Clear();
        WinchCore.Log.Debug($"ThawableItemDataDict cleared");
        GadgetItemDataDict.Clear();
        WinchCore.Log.Debug($"GadgetItemDataDict cleared");
        EngineItemDataDict.Clear();
        WinchCore.Log.Debug($"EngineItemDataDict cleared");
        LightItemDataDict.Clear();
        WinchCore.Log.Debug($"LightItemDataDict cleared");
        BaitItemDataDict.Clear();
        WinchCore.Log.Debug($"BaitItemDataDict cleared");
        HarvestableItemDataDict.Clear();
        WinchCore.Log.Debug($"HarvestableItemDataDict cleared");
        FishItemDataDict.Clear();
        WinchCore.Log.Debug($"FishItemDataDict cleared");
        RelicItemDataDict.Clear();
        WinchCore.Log.Debug($"RelicItemDataDict cleared");
        NonSpatialItemDataDict.Clear();
        WinchCore.Log.Debug($"NonSpatialItemDataDict cleared");
        MessageItemDataDict.Clear();
        WinchCore.Log.Debug($"MessageItemDataDict cleared");
        ResearchableItemDataDict.Clear();
        WinchCore.Log.Debug($"ResearchableItemDataDict cleared");
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
        if (VanillaItemIDList.Contains(id))
        {
            WinchCore.Log.Error($"Item {id} already exists in vanilla.");
            return;
        }
        if (ModdedItemDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate item {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateObjectFromMetaWithConverters<T>(item, meta))
        {
            ModdedItemDataDict.Add(id, item);
            AddressablesUtil.AddResourceAtLocation("ItemData", id, id, item);
        }
        else
        {
            WinchCore.Log.Error($"No item data converter found for type {typeof(T)}");
        }
    }

    public static ItemData[] GetAllItemData()
    {
        return AllItemDataDict.Values.ToArray();
    }

    public static SpatialItemData[] GetAllSpatialItemData()
    {
        return SpatialItemDataDict.Values.ToArray();
    }

    public static HarvestableItemData[] GetAllHarvestableItemData()
    {
        return HarvestableItemDataDict.Values.ToArray();
    }

    public static FishItemData[] GetAllFishItemData()
    {
        return FishItemDataDict.Values.ToArray();
    }

    public static RelicItemData[] GetAllRelicItemData()
    {
        return RelicItemDataDict.Values.ToArray();
    }

    public static HarvesterItemData[] GetAllHarvesterItemData()
    {
        return HarvesterItemDataDict.Values.ToArray();
    }

    public static DeployableItemData[] GetAllDeployableItemData()
    {
        return DeployableItemDataDict.Values.ToArray();
    }

    public static DeployableItemData[] GetAllTrawlNetItemData()
    {
        return NetItemDataDict.Values.ToArray();
    }

    public static DeployableItemData[] GetAllCrabPotItemData()
    {
        return PotItemDataDict.Values.ToArray();
    }

    public static DredgeItemData[] GetAllDredgeItemData()
    {
        return DredgeItemDataDict.Values.ToArray();
    }

    public static RodItemData[] GetAllRodItemData()
    {
        return RodItemDataDict.Values.ToArray();
    }

    public static DurableItemData[] GetAllDurableItemData()
    {
        return DurableItemDataDict.Values.ToArray();
    }

    public static DurableItemData[] GetAllThawableItemData()
    {
        return ThawableItemDataDict.Values.ToArray();
    }

    public static GadgetItemData[] GetAllGadgetItemData()
    {
        return GadgetItemDataDict.Values.ToArray();
    }

    public static EngineItemData[] GetAllEngineItemData()
    {
        return EngineItemDataDict.Values.ToArray();
    }

    public static LightItemData[] GetAllLightItemData()
    {
        return LightItemDataDict.Values.ToArray();
    }

    public static SpatialItemData[] GetAllBaitItemData()
    {
        return BaitItemDataDict.Values.ToArray();
    }

    public static NonSpatialItemData[] GetAllNonSpatialItemData()
    {
        return NonSpatialItemDataDict.Values.ToArray();
    }

    public static MessageItemData[] GetAllMessageItemData()
    {
        return MessageItemDataDict.Values.ToArray();
    }

    public static ResearchableItemData[] GetAllResearchableItemData()
    {
        return ResearchableItemDataDict.Values.ToArray();
    }
}
