using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using Winch.Core;
using Winch.Data;

namespace Winch.Serialization.GridConfig;

public class GridConfigConverter : DredgeTypeConverter<DeferredGridConfiguration>
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "cellGroupConfigs", new(new List<CellGroupConfiguration>(), o => DredgeTypeHelpers.ParseCellGroupConfigurations((JArray)o)) },
        { "mainItemData", new(string.Empty, null) },
        { "mainItemType", new(ItemType.GENERAL, o => DredgeTypeHelpers.ParseFlagsEnum<ItemType>(o)) },
        { "mainItemSubtype", new(ItemSubtype.FISH, o => DredgeTypeHelpers.ParseFlagsEnum<ItemSubtype>(o)) },
        { "itemsInThisBelongToPlayer", new(false, o => bool.Parse(o.ToString())) },
        { "canAddItemsInQuestMode", new(false, o => bool.Parse(o.ToString())) },
        { "hasUnderlay", new(false, o => bool.Parse(o.ToString())) }, //Does this grid have an underlay (used for damage and reinforcement
        { "columns", new(0, o => int.Parse(o.ToString())) },
        { "rows", new(0, o => int.Parse(o.ToString())) },
    };

    public GridConfigConverter()
    {
        AddDefinitions(_definitions);
    }
}