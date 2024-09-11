using System;
using System.Linq;
using Winch.Util;

namespace Winch.Data.Shop;

public class ModdedShopData : ShopData
{
    public string id = string.Empty;

    public GridKey gridKey = GridKey.NONE;

    internal void Populate()
    {
        foreach (var itemData in alwaysInStock.Concat(phaseLinkedShopData.SelectMany(pl => pl.itemData)).Concat(dialogueLinkedShopData.SelectMany(pl => pl.itemData)))
        {
            if (itemData is ModdedShopItemData moddedItemData)
                moddedItemData.Populate();
        }
    }

    public static implicit operator ShopRestocker.ShopDataGridConfig(ModdedShopData shopData) => new ShopRestocker.ShopDataGridConfig
    {
        shopData = shopData,
        gridKey = shopData.gridKey,
    };

    public class ModdedShopItemData : ShopItemData
    {
        public new string itemData = string.Empty;

        public SpatialItemData ItemData => ItemUtil.GetSpatialItemData(itemData);

        internal void Populate()
        {
            base.itemData = ItemData;
        }
    }
}
