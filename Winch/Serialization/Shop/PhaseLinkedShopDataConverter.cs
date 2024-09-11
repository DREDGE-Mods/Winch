using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using static ShopData;

namespace Winch.Serialization.Shop;

public class PhaseLinkedShopDataConverter : DredgeTypeConverter<PhaseLinkedShopData>
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemData", new(new List<ShopItemData>(), o=>DredgeTypeHelpers.ParseShopItemDataList((JArray)o)) },
        { "phase", new(0, o=>int.Parse(o.ToString())) },
    };

    public PhaseLinkedShopDataConverter()
    {
        AddDefinitions(_definitions);
    }
}
