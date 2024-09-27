using System.Collections.Generic;
using Winch.Util;

namespace Winch.Serialization.Item;

public class MessageItemDataConverter : NonSpatialItemDataConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "chronologicalOrder", new(0, o=> int.Parse(o.ToString())) },
        { "messageBodyKey", new(LocalizationUtil.Empty, o=> CreateLocalizedString(o.ToString())) },
        { "set", new( (int)MessagesSet.MESSAGES, o=> (int)DredgeTypeHelpers.GetEnumValue<MessagesSet>(o) )}
    };

    public MessageItemDataConverter()
    {
        AddDefinitions(_definitions);
    }
}