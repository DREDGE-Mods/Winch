using System.Linq;

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

    private ModdedShopDataGridConfig shopDataGridConfig;
    public ModdedShopDataGridConfig ToShopDataGridConfig()
    {
        if (shopDataGridConfig == null)
            shopDataGridConfig = new ModdedShopDataGridConfig(this);
        else
        {
            shopDataGridConfig.gridKey = gridKey;
            shopDataGridConfig.shopData = this;
        }
        return shopDataGridConfig;
    }

    public static implicit operator ShopRestocker.ShopDataGridConfig(ModdedShopData shopData) => shopData.ToShopDataGridConfig();
    public static implicit operator ModdedShopDataGridConfig(ModdedShopData shopData) => shopData.ToShopDataGridConfig();
}
