using System.Collections.Generic;
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
