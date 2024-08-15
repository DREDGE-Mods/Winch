using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Winch.Util;

namespace Winch.Serialization.Item;

public class GadgetItemDataConverter : SpatialItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "itemSubtype", new(ItemSubtype.GADGET, null) },
        { "itemTypeIcon", new(TextureUtil.GetSprite("GadgetIcon"), null) },
        { "effectMagnitude", new(decimal.Zero, o => decimal.Parse(o.ToString())) },
        { "effectType", new(GadgetEffect.NONE, o=> DredgeTypeHelpers.GetEnumValue<GadgetEffect>(o)) }
    };

    public GadgetItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}
