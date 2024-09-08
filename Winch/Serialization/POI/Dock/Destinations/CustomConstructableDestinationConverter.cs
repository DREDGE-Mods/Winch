using System.Collections.Generic;

namespace Winch.Serialization.POI.Dock.Destinations;

public class CustomConstructableDestinationConverter : CustomBaseDestinationConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "useThisDestinationInsteadIfConstructed", new(null, null) },
        { "constructableDestinationData", new(null, null) },
    };

    public CustomConstructableDestinationConverter()
    {
        AddDefinitions(_definitions);
    }
}
