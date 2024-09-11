using Winch.Util;
using static ShopData;
using static ShopRestocker;

namespace Winch.Data.Shop;

public class ModdedShopDataGridConfig : ShopDataGridConfig
{
    public ModdedShopDataGridConfig(ShopData shopData, GridKey gridKey)
    {
        this.shopData = shopData;
        this.gridKey = gridKey;
    }

    public ModdedShopDataGridConfig(ModdedShopData shopData) : this(shopData, shopData.gridKey)
    {
    }
}