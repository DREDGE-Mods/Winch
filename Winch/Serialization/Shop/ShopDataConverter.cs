using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Winch.Data.Shop;
using static ShopData;

namespace Winch.Serialization.Shop;

public class ShopDataConverter : DredgeTypeConverter<ModdedShopData>
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "id", new(string.Empty, null) },
        { "alwaysInStock", new(new List<ShopItemData>(), o=>DredgeTypeHelpers.ParseShopItemDataList((JArray)o)) },
        { "phaseLinkedShopData", new(new List<PhaseLinkedShopData>(), o=>DredgeTypeHelpers.ParsePhaseLinkedShopDataList((JArray)o)) },
        { "dialogueLinkedShopData", new(new List<DialogueLinkedShopData>(), o=>DredgeTypeHelpers.ParseDialogueLinkedShopDataList((JArray)o)) },
        { "itemSubtypesFromResearchPool", new(new List<ItemSubtype>(), o=>DredgeTypeHelpers.GetEnumValues<ItemSubtype>((JArray)o)) },
        { "countOfEachItemFromResearchPool", new(0, o=>int.Parse(o.ToString())) },
        { "gridKey", new(GridKey.NONE, o=>DredgeTypeHelpers.GetEnumValue<GridKey>(o)) },
    };

    public ShopDataConverter()
    {
        AddDefinitions(_definitions);
    }
}
