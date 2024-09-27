using System.Collections.Generic;

namespace Winch.Serialization.POI.Dock.Destinations;

public class CustomCharacterDestinationConverter : CustomBaseDestinationConverter
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
    };

    public CustomCharacterDestinationConverter()
    {
        AddDefinitions(_definitions);
    }
}
