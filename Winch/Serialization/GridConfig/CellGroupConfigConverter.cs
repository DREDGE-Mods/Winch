using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UnityEngine;
using Winch.Core;

namespace Winch.Serialization.GridConfig;

public class CellGroupConfigConverter : DredgeTypeConverter<UnstructedCellGroupConfiguration>
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "cells", new(new List<Vector2Int>(){ new Vector2Int(0,0) }, o => DredgeTypeHelpers.ParseDimensions((JArray)o)) },
        { "itemType", new(ItemType.GENERAL, o => DredgeTypeHelpers.ParseFlagsEnum<ItemType>(o)) },
        { "itemSubtype", new(ItemSubtype.GENERAL, o => DredgeTypeHelpers.ParseFlagsEnum<ItemSubtype>(o)) },
        { "isHidden", new(false, o => bool.Parse(o.ToString())) },
        { "damageImmune", new(false, o => bool.Parse(o.ToString())) }
    };

    public CellGroupConfigConverter()
    {
        AddDefinitions(_definitions);
    }
}