using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using static ShopData;
using static ShopData.DialogueLinkedShopData;

namespace Winch.Serialization.Shop;

public class DialogueLinkedShopDataConverter : DredgeTypeConverter<DialogueLinkedShopData>
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemData", new(new List<ShopItemData>(), o=>DredgeTypeHelpers.ParseShopItemDataList((JArray)o)) },
        { "dialogueNodes", new( new List<string>(), o=>DredgeTypeHelpers.ParseStringList((JArray)o)) },
        { "requireMode", new( RequireMode.ANY, o => DredgeTypeHelpers.GetEnumValue<RequireMode>(o)) }
    };

    public DialogueLinkedShopDataConverter()
    {
        AddDefinitions(_definitions);
    }
}
