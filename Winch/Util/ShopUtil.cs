using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AeLa.EasyFeedback.APIs;
using Winch.Core;
using Winch.Data.Shop;
using Winch.Serialization.Shop;
using static ShopData;
using static ShopRestocker;
using static Winch.Data.Shop.ModdedShopData;

namespace Winch.Util;

public static class ShopUtil
{
    private static ShopDataConverter ShopDataConverter = new ShopDataConverter();
    private static ShopItemDataConverter ShopItemDataConverter = new ShopItemDataConverter();
    private static PhaseLinkedShopDataConverter PhaseLinkedShopDataConverter = new PhaseLinkedShopDataConverter();
    private static DialogueLinkedShopDataConverter DialogueLinkedShopDataConverter = new DialogueLinkedShopDataConverter();

    internal static bool PopulateShopDataFromMetaWithConverter(ModdedShopData data, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(data, meta, ShopDataConverter);
    }

    internal static bool PopulateShopItemDataFromMetaWithConverter(ModdedShopData.ModdedShopItemData data, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(data, meta, ShopItemDataConverter);
    }

    internal static bool PopulatePhaseLinkedShopDataFromMetaWithConverter(PhaseLinkedShopData data, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(data, meta, PhaseLinkedShopDataConverter);
    }

    internal static bool PopulateDialogueLinkedShopDataFromMetaWithConverter(DialogueLinkedShopData data, Dictionary<string, object> meta)
    {
        return UtilHelpers.PopulateObjectFromMeta(data, meta, DialogueLinkedShopDataConverter);
    }

    internal static List<string> KeepInStockItems = new();
    internal static Dictionary<GridKey, ShopDataGridConfig> AllShopDataGridConfigDict = new();
    internal static Dictionary<string, ModdedShopData> ModdedShopDataDict = new();
    internal static Dictionary<string, ShopData> AllShopDataDict = new();

    public static void RegisterKeepInStockItem(string itemID) => KeepInStockItems.Add(itemID);

    public static ModdedShopData GetModdedShopData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (ModdedShopDataDict.TryGetValue(id, out ModdedShopData shopData))
            return shopData;
        else
            return null;
    }

    public static ShopData GetShopData(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        if (AllShopDataDict.TryGetValue(id, out var shop))
            return shop;

        if (ModdedShopDataDict.TryGetValue(id, out var moddedShop))
            return moddedShop;

        return null;
    }

    internal static void AddModdedShopData(ShopRestocker restocker)
    {
        restocker.itemIdsToKeep.AddRange(KeepInStockItems);
        foreach (var shopData in ModdedShopDataDict.Values)
        {
            shopData.Populate();
            restocker.shopDataGridConfigs.Add(shopData);
        }
    }

    internal static void PopulateShopData(IEnumerable<ShopDataGridConfig> result)
    {
        foreach (var shopDataGridConfig in result)
        {
            AllShopDataGridConfigDict.SafeAdd(shopDataGridConfig.gridKey, shopDataGridConfig);
            WinchCore.Log.Debug($"Added shop data {shopDataGridConfig.gridKey} to AllShopDataGridConfigDict");
            AllShopDataDict.SafeAdd(shopDataGridConfig.shopData.name, shopDataGridConfig.shopData);
            WinchCore.Log.Debug($"Added shop data {shopDataGridConfig.shopData.name} to AllShopDataDict");
        }
    }

    internal static void ClearShopData()
    {
        AllShopDataGridConfigDict.Clear();
        AllShopDataDict.Clear();
    }

    internal static void AddShopDataFromMeta(string metaPath)
    {
        var meta = UtilHelpers.ParseMeta(metaPath);
        if (meta == null)
        {
            WinchCore.Log.Error($"Meta file {metaPath} is empty");
            return;
        }
        var shopData = UtilHelpers.GetScriptableObjectFromMeta<ModdedShopData>(meta, metaPath);
        if (shopData == null)
        {
            WinchCore.Log.Error($"Couldn't create ModdedShopData");
            return;
        }
        var id = (string)meta["id"];
        if (ModdedShopDataDict.ContainsKey(id))
        {
            WinchCore.Log.Error($"Duplicate shop data {id} at {metaPath} failed to load");
            return;
        }
        if (PopulateShopDataFromMetaWithConverter(shopData, meta))
        {
            ModdedShopDataDict.Add(id, shopData);
        }
        else
        {
            WinchCore.Log.Error($"No shop data converter found");
        }
    }

    public static ShopData[] GetAllShopData()
    {
        return AllShopDataDict.Values.ToArray();
    }
}
