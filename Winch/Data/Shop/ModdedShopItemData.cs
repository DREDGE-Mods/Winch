using Winch.Util;
using static ShopData;

namespace Winch.Data.Shop;

public class ModdedShopItemData : ShopItemData
{
    public new string itemData = string.Empty;

    public SpatialItemData ItemData => ItemUtil.GetSpatialItemData(itemData);

    internal ModdedShopItemData()
    {
    }

    public ModdedShopItemData(string itemID)
    {
        itemData = itemID;
        Populate();
    }

    internal void Populate()
    {
        base.itemData = ItemData;
    }
}