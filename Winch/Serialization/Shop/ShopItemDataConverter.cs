using System.Collections.Generic;
using Winch.Data.Shop;

namespace Winch.Serialization.Shop;

public class ShopItemDataConverter : DredgeTypeConverter<ModdedShopData.ModdedShopItemData>
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemData", new(string.Empty, null) },
        { "count", new(1, o=>int.Parse(o.ToString())) },
        { "chance", new(1f, o=>float.Parse(o.ToString())) },
    };

    public ShopItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}
