using System.Collections.Generic;
using UnityEngine;
using Winch.Data.POI.Dock.Destinations;

namespace Winch.Serialization.POI.Dock.Destinations;

public class CustomConstructableDestinationConverter : CustomBaseDestinationConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "useFixedScreenPosition", new(true, null) }, // Default to using it or else some features won't work
        { "screenPosition", new(new Vector2(-675f, 200f), null) },
        { "useThisDestinationInsteadIfConstructed", new(null, null) },
        { "constructableDestinationData", new(new CustomConstructableDestinationData(), o=>DredgeTypeHelpers.ParseConstructableDestinationData(o)) },
    };

    public CustomConstructableDestinationConverter()
    {
        AddDefinitions(_definitions);
    }
}
