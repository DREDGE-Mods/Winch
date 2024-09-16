using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Winch.Data.POI.Dock.Destinations;

namespace Winch.Serialization.POI.Dock.Destinations;
internal class CustomConstructableDestinationDataConverter : DredgeTypeConverter<CustomConstructableDestinationData>
{
    private readonly Dictionary<string, FieldDefinition> _definitions = new()
    {
        { "tiers", new(new List<CustomBaseDestinationTier>(), o=>DredgeTypeHelpers.ParseDestinationTiers((JArray)o)) },
        { "productQuestGrid", new(string.Empty, null) },
        { "itemProductPickupReminderDialogueNodeName", new(string.Empty, null) }
    };

    public CustomConstructableDestinationDataConverter()
    {
        AddDefinitions(_definitions);
    }
}
