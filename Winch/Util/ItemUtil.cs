using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Winch.Core;
using Winch.Serialization;
using Winch.Serialization.Item;

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
        { typeof(FishItemData), new FishItemDataConverter() },
        { typeof(RelicItemData), new RelicItemDataConverter() },
        { typeof(DeployableItemData), new DeployableItemDataConverter() },
        { typeof(DredgeItemData), new DredgeItemDataConverter() },
        { typeof(RodItemData), new RodItemDataConverter() },
        { typeof(LightItemData), new LightItemDataConverter() },
        { typeof(DamageItemData), new DamageItemDataConverter() },
    };

    public static Dictionary<string, HarvestableItemData> HarvestableItemDataDict = new();
    public static Dictionary<string, ItemData> AllItemDataDict = new();
    public static Dictionary<string, ItemData> ModdedItemDataDict = new();

    public static void PopulateItemData()
    {
        foreach (var item in GameManager.Instance.ItemManager.allItems)
        {
            if (item is HarvestableItemData hitem) // Fish and Relics
            {
                HarvestableItemDataDict.Add(item.id, hitem);
                WinchCore.Log.Debug($"Added item {item.id} to HarvestableItemDataDict");
            }
            AllItemDataDict.Add(item.id, item);
            WinchCore.Log.Debug($"Added item {item.id} to AllItemDataDict");
        }
    }

    public static void ClearItemData()
    {
        AllItemDataDict.Clear();
        WinchCore.Log.Debug($"AllItemDataDict cleared");
        HarvestableItemDataDict.Clear();
        WinchCore.Log.Debug($"HarvestableItemDataDict cleared");
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
        var id = (string)meta["id"];
        if (ModdedItemDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate item {id} at {metaPath} failed to load");
            return;
        }
        if (UtilHelpers.PopulateObjectFromMeta<T>(item, meta, Converters))
        {
            ModdedItemDataDict.Add(id, item);
            GameManager.Instance.ItemManager.allItems.Add(item);
        }
    }
}
