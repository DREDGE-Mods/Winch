using Winch.Util;
using static ShopData;

namespace Winch.Data.Shop;

public class ModdedShopItemData : ShopItemData
{
    public new string itemData = string.Empty;

    public SpatialItemData ItemData => ItemUtil.GetSpatialItemData(itemData);

    internal ModdedShopItemData()
    {
        count = 1;
        chance = 1;
    }

    public ModdedShopItemData(string itemID) : this()
    {
        itemData = itemID;
        Populate();
    }

    public ModdedShopItemData(string itemID, int count) : this(itemID)
    {
        this.count = count;
    }

    public ModdedShopItemData(string itemID, int count, float chance) : this(itemID, count)
    {
        this.chance = chance;
    }

    internal void Populate()
    {
        base.itemData = ItemData;
    }
}